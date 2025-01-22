using Microsoft.Data.Sqlite;
using System.Data;
using Microsoft.AspNetCore.Hosting;
using Wq_Surveillance.Models;
using NetTopologySuite.Geometries;
using Microsoft.Extensions.Hosting.Internal;
using Wq_Surveillance.Controllers;
using Wq_Surveillance.Service.OtherService;
using System.Data.SQLite;

public class WqsSync
{
    private readonly IWebHostEnvironment _hostEnvironment;
    private readonly WqsContext _WqsContext;
    private IOtherService _utc;

    public WqsSync(IWebHostEnvironment hostEnvironment, WqsContext WqsContext, IOtherService utc)
    {
        _hostEnvironment = hostEnvironment;
        _WqsContext = WqsContext;
        _utc = utc;
    }

    public async Task<Tuple<bool, string>> ReadAndSaveDBWqs(string sqliteFilePath, string username)
    {
        string tempPath = null;
        try
        {
            // Step 1: Validate File Path
            if (string.IsNullOrEmpty(sqliteFilePath))
                return new Tuple<bool, string>(false, "SQLite file path is null or empty.");

            if (!File.Exists(sqliteFilePath))
                return new Tuple<bool, string>(false, "SQLite database file does not exist at the specified path.");

            // Step 2: Create a Unique Temporary Copy of the SQLite File
            tempPath = Path.Combine(Path.GetTempPath(), Path.GetRandomFileName());
            File.Copy(sqliteFilePath, tempPath, overwrite: true);

            // Step 3: Open SQLite Connection
            using (var sqliteConnection = await OpenSqliteConnectionWithRetry(tempPath))
            {
                // Step 4: Migrate Data - Table by Table
                var tables = new[]
                {
                "wqSurveillanceData", "form1AData", "form1BData", "form2Data", "form3Data",
                "reservoirSanitaryData", "sourceSanitaryData",
                "structureSanitaryData", "tapSanitaryData"
            };

                foreach (var table in tables)
                {
                    await MigrateTable(sqliteConnection, table, username);
                }
            }

            return new Tuple<bool, string>(true, "Data successfully migrated.");
        }
        catch (Exception ex)
        {
            // Step 6: Handle Errors and Log
            Console.WriteLine($"Error: {ex.Message}\nStackTrace: {ex.StackTrace}");
            return new Tuple<bool, string>(false, $"Error during migration: {ex.Message}");
        }
        finally
        {
            // Ensure Cleanup of Temporary File
            if (!string.IsNullOrEmpty(tempPath) && File.Exists(tempPath))
            {
                await CleanupFileWithRetries(tempPath);
            }
        }
    }

    private async Task<SqliteConnection> OpenSqliteConnectionWithRetry(string filePath, int maxRetries = 5, int delayMilliseconds = 500)
    {
        int retryCount = 0;

        while (retryCount < maxRetries)
        {
            try
            {
                var connection = new SqliteConnection($"Data Source={filePath}");
                await connection.OpenAsync();

                // Return the connection, but make sure it's closed and disposed of properly after use
                return connection;
            }
            catch (IOException ex) when (IsFileLocked(ex))
            {
                retryCount++;
                Console.WriteLine($"File is locked, retrying ({retryCount}/{maxRetries})...");
                await Task.Delay(delayMilliseconds);
            }
        }

        throw new IOException($"Unable to access the file after {maxRetries} retries.");
    }

    // Ensure to close and dispose the connection explicitly when done
    private async Task MigrateTable(SqliteConnection sqliteConnection, string tableName, string username)
    {


        var commandText = $"SELECT * FROM {tableName}";
        try
        {
            using (var sqliteCommand = new SqliteCommand(commandText, sqliteConnection))
            {
                using (var reader = await sqliteCommand.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        // Read values from SQLite
                        var values = new Dictionary<string, object>();
                        for (int i = 0; i < reader.FieldCount; i++)
                        {
                            values[reader.GetName(i)] = reader.GetValue(i);
                        }
                        
                        
                            await SaveDataToPostgres(tableName, values, username);
                        
                        // Save to Postgres
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error processing table {tableName}: {ex.Message}");
            throw;
        }
    }
    public async Task MigrateTableTbl3(SqliteConnection sqliteConnection)
    {
        string selectQuery = "SELECT id, name FROM form3Data";

        using (var sqliteCommand = new SqliteCommand(selectQuery, sqliteConnection))
        {
            using (var sqliteReader = sqliteCommand.ExecuteReader())
            {
                while (sqliteReader.Read())
                {
                    await Console.Out.WriteLineAsync(sqliteReader.ToString());
                }
            }
        }
    }



    private async Task CleanupFileWithRetries(string filePath)
    {
        const int maxRetries = 5;
        const int delayMilliseconds = 500;

        for (int i = 0; i < maxRetries; i++)
        {
            try
            {
                GC.Collect();
                GC.WaitForPendingFinalizers();

                if (File.Exists(filePath))
                {
                    File.Delete(filePath);
                    Console.WriteLine("File successfully deleted.");
                    return;
                }
            }
            catch (IOException ex)
            {
                if (IsFileLocked(ex))
                {
                    Console.WriteLine($"Attempt {i + 1}/{maxRetries} failed: File is locked. \n {ex.ToString()}");
                    await Task.Delay(delayMilliseconds);
                }
                else
                {
                    Console.WriteLine($"Attempt {i + 1}/{maxRetries} failed: File is locked. \n {ex.ToString()}");
                    await Task.Delay(delayMilliseconds);
                }
            }
        }

        //throw new IOException($"Unable to delete file after {maxRetries} retries.");
    }





    private bool IsFileLocked(IOException ex)
    {
        return ex.Message.Contains("being used by another process");
    }


    BlobImageWriter Img = new BlobImageWriter();


    private async Task SaveDataToPostgres(string tableName, Dictionary<string, object> values, string username)

    {
         

        switch (tableName)
        {
            case "wqSurveillanceData":
                try
                {
                    var existingWqSurveillance = _WqsContext.WqSurvellianceMains
                        .FirstOrDefault(f => f.Uuid == GetValueOrDefault(values, "uuid"));
                    var latitude = values.ContainsKey("latitude") ? Convert.ToDouble(values["latitude"]) : (double?)null;
                    var longitude = values.ContainsKey("longitude") ? Convert.ToDouble(values["longitude"]) : (double?)null;
                    if (existingWqSurveillance == null)
                    {


                        // Add new record if not found
                        _WqsContext.WqSurvellianceMains.Add(new WqSurvellianceMain
                        {
                            Uuid = values["uuid"]?.ToString(),
                            DbName = values["dbName"]?.ToString(),
                            Surveyor = values["surveyor"]?.ToString(),
                            Province = values["province"]?.ToString(),
                            District = values["district"]?.ToString(),
                            Municipality = values["municipality"]?.ToString(),
                            FiscalYear = values["fiscalYear"]?.ToString(),
                            ProjectName = values["projectName"]?.ToString(),
                            SystemType = values["systemType"]?.ToString(),
                            Address = values["address"]?.ToString(),
                            SourceName = values["sourceName"]?.ToString(),
                            SourceType = values["sourceType"]?.ToString(),
                            Others = values["others"]?.ToString(),
                            TotalBenificiaryPopulation = values.ContainsKey("totalBenificiaryPopulation") ? Convert.ToInt32(values["totalBenificiaryPopulation"]) : (int?)null,
                            TotalHhServed = values.ContainsKey("totalHhServed") ? Convert.ToInt32(values["totalBenificiaryPopulation"]) : (int?)null,

                            SopCondition = values["sopCondition"]?.ToString(),
                            WspCondtion = values["wspCondition"]?.ToString(),
                            Latitude = latitude,
                            Longitude = longitude,
                            VisitDate = values["visitDate"]?.ToString(),
                            TheGeom = latitude.HasValue && longitude.HasValue
                                ? new Point(longitude.Value, latitude.Value) { SRID = 4326 }
                                : null,
                            EditedBy = username,
                            EditedOn = values.ContainsKey("editedOn") ? (DateTime?)Convert.ToDateTime(values["editedOn"]) : null,
                            AddedBy = username,
                            AddedOn = DateTime.UtcNow,
                            SopPhoto = MapImage((byte[])(values["sopPhoto"])),
                            WspPhoto = MapImage((byte[])(values["wspPhoto"])),
                            Altitude = values.ContainsKey("altitude") ? Convert.ToDouble(values["altitude"]) : (double?)null
                        });
                    }
                    else
                    {
                        // Update existing record if found
                        existingWqSurveillance.DbName = values["dbName"]?.ToString();
                        existingWqSurveillance.Surveyor = values["surveyor"]?.ToString();
                        existingWqSurveillance.Province = values["province"]?.ToString();
                        existingWqSurveillance.District = values["district"]?.ToString();
                        existingWqSurveillance.Municipality = values["municipality"]?.ToString();
                        existingWqSurveillance.FiscalYear = values["fiscalYear"]?.ToString();
                        existingWqSurveillance.ProjectName = values["projectName"]?.ToString();
                        existingWqSurveillance.SystemType = values["systemType"]?.ToString();
                        existingWqSurveillance.Address = values["address"]?.ToString();
                        existingWqSurveillance.SourceName = values["sourceName"]?.ToString();
                        existingWqSurveillance.SourceType = values["sourceType"]?.ToString();
                        existingWqSurveillance.Others = values["others"]?.ToString();
                        existingWqSurveillance.TotalBenificiaryPopulation = values.ContainsKey("totalBenificiaryPopulation") ? Convert.ToInt32(values["totalBenificiaryPopulation"]) : (int?)null;
                        existingWqSurveillance.SopCondition = values["sopCondition"]?.ToString();
                        existingWqSurveillance.WspCondtion = values["wspCondition"]?.ToString();
                        existingWqSurveillance.Latitude = latitude;
                        existingWqSurveillance.Longitude = longitude;
                        existingWqSurveillance.VisitDate = values["visitDate"]?.ToString();
                        existingWqSurveillance.TheGeom = latitude.HasValue && longitude.HasValue
                            ? new Point(longitude.Value, latitude.Value) { SRID = 4326 }
                            : null;
                        existingWqSurveillance.EditedBy = username;
                        existingWqSurveillance.EditedOn = DateTime.UtcNow;
                        existingWqSurveillance.SopPhoto = MapImage((byte[])(values["sopPhoto"]));
                        existingWqSurveillance.WspPhoto = MapImage((byte[])(values["wspPhoto"]));
                        existingWqSurveillance.Altitude = values.ContainsKey("altitude") ? Convert.ToDouble(values["altitude"]) : (double?)null;
                    }

                    await _WqsContext.SaveChangesAsync();
                }
                catch (Exception ex)
                {
                    await Console.Out.WriteLineAsync(ex.ToString());
                }
                break;


            case "form1AData":
                try
                {
                    var existingRecord = _WqsContext.Form1as.FirstOrDefault(f => f.FormId == GetValueOrDefault(values, "formId") && f.Uuid == GetValueOrDefault(values, "uuid"));
                    if (existingRecord == null)
                    {
                        // Add new record if it doesn't exist
                        _WqsContext.Form1as.Add(new Form1a
                        {
                            FormId = GetValueOrDefault(values, "formId"),
                            Uuid = values["uuid"]?.ToString(),
                            AddedBy = username,
                            AddedOn = DateTime.UtcNow,
                            WspInitiativeStatus1 = GetValueOrDefault(values, "wspInitiativeStatus1"),
                            WspInitiativeRemarks1 = GetValueOrDefault(values, "wspInitiativeRemarks1"),
                            WspInitiativeStatus2 = GetValueOrDefault(values, "wspInitiativeStatus2"),
                            WspInitiativeRemarks2 = GetValueOrDefault(values, "wspInitiativeRemarks2"),
                            WspInitiativeStatus3 = GetValueOrDefault(values, "wspInitiativeStatus3"),
                            WspInitiativeRemarks3 = GetValueOrDefault(values, "wspInitiativeRemarks3"),
                            WspInitiativeStatus4 = GetValueOrDefault(values, "wspInitiativeStatus4"),
                            WspInitiativeRemarks4 = GetValueOrDefault(values, "wspInitiativeRemarks4"),
                            WspInitiativeStatus5 = GetValueOrDefault(values, "wspInitiativeStatus5"),
                            WspInitiativeRemarks5 = GetValueOrDefault(values, "wspInitiativeRemarks5"),
                            WspInitiativeStatus6 = GetValueOrDefault(values, "wspInitiativeStatus6"),
                            WspInitiativeRemarks6 = GetValueOrDefault(values, "wspInitiativeRemarks6"),
                            WspInitiativeStatus7 = GetValueOrDefault(values, "wspInitiativeStatus7"),
                            WspInitiativeRemarks7 = GetValueOrDefault(values, "wspInitiativeRemarks7"),
                            WspInitiativeSecurityPlan = GetValueOrDefault(values, "wspInitiativeSecurityPan"),
                            WspInitiativeWaterQualityStatus = GetValueOrDefault(values, "wspInitiativeWaterQualityStatus"),
                            WspInitiativeInfectedByDiarrhea = GetValueOrDefault(values, "wspInitiativeInfectedByDiarrhea"),
                            WspInitiativeDiedByDiarrhea = GetValueOrDefault(values, "wspInitiativeDiedByDiarrhea"),
                            WspInitiativeWaterDisease = GetValueOrDefault(values, "wspInitiativeWaterDisease"),
                            WspInitiativeNoticeSource = GetValueOrDefault(values, "wspInitiativeNoticeSource"),
                            WspInitiativeWrittenResult = GetValueOrDefault(values, "wspInitiativeWrittenResult"),
                            WspInitiativeSuggestion = GetValueOrDefault(values, "wspInitiativeSuggestion")

                        });
                    }
                    else
                    {
                        // Update existing record if it exists
                        existingRecord.WspInitiativeStatus1 = GetValueOrDefault(values, "wspInitiativeStatus1");
                        existingRecord.WspInitiativeRemarks1 = GetValueOrDefault(values, "wspInitiativeRemarks1");
                        existingRecord.WspInitiativeStatus2 = GetValueOrDefault(values, "wspInitiativeStatus2");
                        existingRecord.WspInitiativeRemarks2 = GetValueOrDefault(values, "wspInitiativeRemarks2");
                        existingRecord.WspInitiativeStatus3 = GetValueOrDefault(values, "wspInitiativeStatus3");
                        existingRecord.WspInitiativeRemarks3 = GetValueOrDefault(values, "wspInitiativeRemarks3");
                        existingRecord.WspInitiativeStatus4 = GetValueOrDefault(values, "wspInitiativeStatus4");
                        existingRecord.WspInitiativeRemarks4 = GetValueOrDefault(values, "wspInitiativeRemarks4");
                        existingRecord.WspInitiativeStatus5 = GetValueOrDefault(values, "wspInitiativeStatus5");
                        existingRecord.WspInitiativeRemarks5 = GetValueOrDefault(values, "wspInitiativeRemarks5");
                        existingRecord.WspInitiativeStatus6 = GetValueOrDefault(values, "wspInitiativeStatus6");
                        existingRecord.WspInitiativeRemarks6 = GetValueOrDefault(values, "wspInitiativeRemarks6");
                        existingRecord.WspInitiativeStatus7 = GetValueOrDefault(values, "wspInitiativeStatus7");
                        existingRecord.WspInitiativeRemarks7 = GetValueOrDefault(values, "wspInitiativeRemarks7");
                        existingRecord.WspInitiativeSecurityPlan = GetValueOrDefault(values, "wspInitiativeSecurityPan");
                        existingRecord.WspInitiativeWaterQualityStatus = GetValueOrDefault(values, "wspInitiativeWaterQualityStatus");
                        existingRecord.WspInitiativeInfectedByDiarrhea = GetValueOrDefault(values, "wspInitiativeInfectedByDiarrhea");
                        existingRecord.WspInitiativeDiedByDiarrhea = GetValueOrDefault(values, "wspInitiativeDiedByDiarrhea");
                        existingRecord.WspInitiativeWaterDisease = GetValueOrDefault(values, "wspInitiativeWaterDisease");
                        existingRecord.WspInitiativeNoticeSource = GetValueOrDefault(values, "wspInitiativeNoticeSource");
                        existingRecord.WspInitiativeWrittenResult = GetValueOrDefault(values, "wspInitiativeWrittenResult");
                        existingRecord.WspInitiativeSuggestion = GetValueOrDefault(values, "wspInitiativeSuggestion");
                        existingRecord.EditedBy = username;
                        existingRecord.EditedOn = DateTime.UtcNow;
                    }

                    await _WqsContext.SaveChangesAsync();
                }
                catch(Exception ex)
                {
                    var exc = ex.ToString();
                    await Console.Out.WriteLineAsync(exc);
                }
                break;


            case "form1BData":
                try
                {
                    var existingRecord = _WqsContext.Form1bs.FirstOrDefault(f => f.FormId == GetValueOrDefault(values, "formId") && f.Uuid == GetValueOrDefault(values, "uuid"));

                    if (existingRecord == null)
                    {
                        // Add new record if it doesn't exist
                        var form1b = new Form1b
                        {
                            FormId = GetValueOrDefault(values, "formId"),
                            Uuid = values["uuid"]?.ToString(),
                            AddedBy = username,
                            AddedOn = DateTime.UtcNow,
                            TeamFormationScore = GetValueOrDefault(values, "teamFormationScore"),
                            TeamFormationPhoto = MapImage((byte[])(values["teamFormationPhoto"])),
                            SystemAnalysisScore = GetValueOrDefault(values, "systemAnalysisScore"),
                            SystemAnalysisPhoto = MapImage((byte[])(values["systemAnalysisPhoto"])),
                            PollutionRiskControlMeasureScore = GetValueOrDefault(values, "pollutionRiskControlMeasureScore"),
                            PollutionRiskControlPhoto = MapImage((byte[])(values["pollutionControlPhoto"])),
                            ImprovementPlanScore = GetValueOrDefault(values, "improvementPlanScore"),
                            ImprovementPlanPhoto = MapImage((byte[])(values["improvementPlanPhoto"])),
                            MonitoringScore = GetValueOrDefault(values, "monitoringScore"),
                            MonitoringPhoto = MapImage((byte[])(values["monitoringPhoto"])),
                            CertificationScore = GetValueOrDefault(values, "certificationScore"),
                            CertificationPhoto = MapImage((byte[])(values["certificationPhoto"])),
                            CollaborativeActivitiesScore = GetValueOrDefault(values, "collaborativeActivitiesScore"),
                            CollaborativeActivitiesPhoto = MapImage((byte[])(values["collaborativeActivityPhoto"])),
                            ReviewScore = GetValueOrDefault(values, "reviewScore"),
                            ReviewPhoto = MapImage((byte[])(values["reviewPhoto"])),
                            TotalScore = int.Parse(GetValueOrDefault(values, "totalScore"))
                        };
                        _WqsContext.Form1bs.Add(form1b);
                    }
                    else
                    {
                        // Update existing record if it exists
                        existingRecord.TeamFormationScore = GetValueOrDefault(values, "teamFormationScore");
                        existingRecord.TeamFormationPhoto = MapImage((byte[])(values["teamFormationPhoto"]));
                        existingRecord.SystemAnalysisScore = GetValueOrDefault(values, "systemAnalysisScore");
                        existingRecord.SystemAnalysisPhoto = MapImage((byte[])(values["systemAnalysisPhoto"]));
                        existingRecord.PollutionRiskControlMeasureScore = GetValueOrDefault(values, "pollutionRiskControlMeasureScore");
                        existingRecord.PollutionRiskControlPhoto = MapImage((byte[])(values["pollutionControlPhoto"]));
                        existingRecord.ImprovementPlanScore = GetValueOrDefault(values, "improvementPlanScore");
                        existingRecord.ImprovementPlanPhoto = MapImage((byte[])(values["improvementPlanPhoto"]));
                        existingRecord.MonitoringScore = GetValueOrDefault(values, "monitoringScore");
                        existingRecord.MonitoringPhoto = MapImage((byte[])(values["monitoringPhoto"]));
                        existingRecord.CertificationScore = GetValueOrDefault(values, "certificationScore");
                        existingRecord.CertificationPhoto = MapImage((byte[])(values["certificationPhoto"]));
                        existingRecord.CollaborativeActivitiesScore = GetValueOrDefault(values, "collaborativeActivitiesScore");
                        existingRecord.CollaborativeActivitiesPhoto = MapImage((byte[])(values["collaborativeActivityPhoto"]));
                        existingRecord.ReviewScore = GetValueOrDefault(values, "reviewScore");
                        existingRecord.ReviewPhoto = MapImage((byte[])(values["reviewPhoto"]));
                        existingRecord.TotalScore = int.Parse(GetValueOrDefault(values, "totalScore"));
                        existingRecord.EditedBy = username;
                        existingRecord.EditedOn = DateTime.UtcNow;
                    }

                    await _WqsContext.SaveChangesAsync();
                }
                catch (Exception ex)
                {
                    var message = ex.ToString();
                    await Console.Out.WriteLineAsync(message);
                }

                break;




            case "form2Data":
                try
                {
                    var formId = GetValueOrDefault(values, "formId");
                    var existingForm = _WqsContext.Form2s.FirstOrDefault(f => f.FormId == GetValueOrDefault(values, "formId") && f.Uuid == GetValueOrDefault(values, "uuid"));

                    if (existingForm != null)
                    {
                        // Update existing fields
                        existingForm.SourceBasicEvaluation = values["sourceBasicEvaluation"]?.ToString();
                        existingForm.SourceBasicEvaluationRemarks = values["sourceBasicEvaluationRemarks"]?.ToString();
                        existingForm.TreatmentCenterBasicEvaluation = values["treatmentCenterBasicEvaluation"]?.ToString();
                        existingForm.TreatmentCenterBasicEvaluationRemarks = values["treatmentCenterBasicEvaluationRemarks"]?.ToString();
                        existingForm.WaterReservoirBasicEvaluation = values["waterReservoirBasicEvaluation"]?.ToString();
                        existingForm.WaterReservoirBasicEvaluationRemarks = values["waterReservoirBasicEvaluationRemarks"]?.ToString();
                        existingForm.PipelineBasicEvaluation = values["pipelineBasicEvaluation"]?.ToString();
                        existingForm.PipelineBasicEvaluationRemarks = values["pipelineBasicEvaluationRemarks"]?.ToString();
                        existingForm.StorageUsageBasicEvaluation = values["storageUsageBasicEvaluation"]?.ToString();
                        existingForm.StorageUsageBasicEvaluationRemarks = values["storageUsageBasicEvaluationRemarks"]?.ToString();
                        existingForm.PollutionPossibility = values["pollutionPossibility"]?.ToString();
                        existingForm.PollutionPossibilityTypes = values["pollutionPossibilityTypes"]?.ToString();
                        existingForm.DefInfectedByDiarrhea = values["defInfectedByDiarrhea"]?.ToString();
                        existingForm.DefDiedByDiarrhea = values["defDiedByDiarrhea"]?.ToString();
                        existingForm.DefWaterDisease = values["defWaterDisease"]?.ToString();
                        existingForm.DefNoticeSource = values["defNoticeSource"]?.ToString();
                        existingForm.DefWrittenResult = values["defWrittenResult"]?.ToString();
                        existingForm.DefSuggestion = values["defSuggestion"]?.ToString();
                        existingForm.EditedBy = username;
                        existingForm.EditedOn = DateTime.UtcNow;
                    }
                    else
                    {
                        // Add new record
                        _WqsContext.Form2s.Add(new Form2
                        {
                            FormId = formId,
                            AddedBy = username,
                            AddedOn = DateTime.UtcNow,
                            Uuid = values["uuid"]?.ToString(),
                            SourceBasicEvaluation = values["sourceBasicEvaluation"]?.ToString(),
                            SourceBasicEvaluationRemarks = values["sourceBasicEvaluationRemarks"]?.ToString(),
                            TreatmentCenterBasicEvaluation = values["treatmentCenterBasicEvaluation"]?.ToString(),
                            TreatmentCenterBasicEvaluationRemarks = values["treatmentCenterBasicEvaluationRemarks"]?.ToString(),
                            WaterReservoirBasicEvaluation = values["waterReservoirBasicEvaluation"]?.ToString(),
                            WaterReservoirBasicEvaluationRemarks = values["waterReservoirBasicEvaluationRemarks"]?.ToString(),
                            PipelineBasicEvaluation = values["pipelineBasicEvaluation"]?.ToString(),
                            PipelineBasicEvaluationRemarks = values["pipelineBasicEvaluationRemarks"]?.ToString(),
                            StorageUsageBasicEvaluation = values["storageUsageBasicEvaluation"]?.ToString(),
                            StorageUsageBasicEvaluationRemarks = values["storageUsageBasicEvaluationRemarks"]?.ToString(),
                            PollutionPossibility = values["pollutionPossibility"]?.ToString(),
                            PollutionPossibilityTypes = values["pollutionPossibilityTypes"]?.ToString(),
                            DefInfectedByDiarrhea = values["defInfectedByDiarrhea"]?.ToString(),
                            DefDiedByDiarrhea = values["defDiedByDiarrhea"]?.ToString(),
                            DefWaterDisease = values["defWaterDisease"]?.ToString(),
                            DefNoticeSource = values["defNoticeSource"]?.ToString(),
                            DefWrittenResult = values["defWrittenResult"]?.ToString(),
                            DefSuggestion = values["defSuggestion"]?.ToString()
                        });
                    }

                    await _WqsContext.SaveChangesAsync();
                }
                catch (Exception ex)
                {
                    var exc = ex.ToString();
                    await Console.Out.WriteLineAsync(exc);
                }
                break;
                ;

            case "form3Data":
                try
                {
                    var existingForm3 = _WqsContext.Form3s.FirstOrDefault(f => f.FormId == GetValueOrDefault(values, "formId") && f.Uuid == GetValueOrDefault(values, "uuid") && f.Month == GetValueOrDefault(values, "month"));

                    if (existingForm3 == null)
                    {
                        // Add new record
                        _WqsContext.Form3s.Add(new Form3
                        {
                            FormId = values["formId"]?.ToString(),
                            Uuid = values["uuid"]?.ToString(),
                            AddedBy = username,
                            AddedOn = DateTime.UtcNow,
                            Month = values["month"]?.ToString(),
                            DiarrheaCount = values["diarrheaCount"]?.ToString(),
                            CholeraCount = values["choleraCount"]?.ToString(),
                            TyphoidCount = values["typhoidCount"]?.ToString(),
                            DysenteryCount = values["dysenteryCount"]?.ToString(),
                            HepatitisCount = values["hepatitisACount"]?.ToString()
                        });
                    }
                    else
                    {
                        // Update existing record
                        existingForm3.DiarrheaCount = values["diarrheaCount"]?.ToString();
                        existingForm3.CholeraCount = values["choleraCount"]?.ToString();
                        existingForm3.DysenteryCount = values["dysenteryCount"]?.ToString();
                        existingForm3.TyphoidCount = values["typhoidCount"]?.ToString();
                        existingForm3.HepatitisCount = values["hepatitisACount"]?.ToString();
                        existingForm3.EditedBy = username;
                        existingForm3.EditedOn = DateTime.UtcNow;
                    }

                    await _WqsContext.SaveChangesAsync();
                }
                catch (Exception ex)
                {
                    var exc = ex.ToString();
                    await Console.Out.WriteLineAsync(exc);
                }
                break;

            case "reservoirSanitaryData":
                try
                {
                    var existingReservoirSanitary = _WqsContext.ReservoirSanitaries
                        .FirstOrDefault(f => f.FormId == GetValueOrDefault(values, "formId") && f.Uuid == GetValueOrDefault(values, "uuid"));

                    var latitude = values.ContainsKey("latitude") ? Convert.ToDouble(values["latitude"]) : (double?)null;
                    var longitude = values.ContainsKey("longitude") ? Convert.ToDouble(values["longitude"]) : (double?)null;

                    if (existingReservoirSanitary == null)
                    {
                        // Add new record
                        _WqsContext.ReservoirSanitaries.Add(new ReservoirSanitary
                        {
                            FormId = values["formId"]?.ToString(),
                            Uuid = values["uuid"]?.ToString(),
                            AddedBy = username,
                            AddedOn = DateTime.UtcNow,
                            ResorvoirSanitationCondition1 = values["reservoirSanitationCondition1"]?.ToString(),
                            ResorvoirSanitationCondition2 = values["reservoirSanitationCondition2"]?.ToString(),
                            ResorvoirSanitationCondition3 = values["reservoirSanitationCondition3"]?.ToString(),
                            ResorvoirSanitationCondition4 = values["reservoirSanitationCondition4"]?.ToString(),
                            ResorvoirSanitationCondition5 = values["reservoirSanitationCondition5"]?.ToString(),
                            Latitude = latitude,
                            Longitude = longitude,
                            VisitDate = values["visitDate"]?.ToString(),
                            TheGeom = latitude.HasValue && longitude.HasValue
                                ? new Point(longitude.Value, latitude.Value) { SRID = 4326 }
                                : null
                        });
                    }
                    else
                    {
                        // Update existing record
                        existingReservoirSanitary.ResorvoirSanitationCondition1 = values["reservoirSanitationCondition1"]?.ToString();
                        existingReservoirSanitary.ResorvoirSanitationCondition2 = values["reservoirSanitationCondition2"]?.ToString();
                        existingReservoirSanitary.ResorvoirSanitationCondition3 = values["reservoirSanitationCondition3"]?.ToString();
                        existingReservoirSanitary.ResorvoirSanitationCondition4 = values["reservoirSanitationCondition4"]?.ToString();
                        existingReservoirSanitary.ResorvoirSanitationCondition5 = values["reservoirSanitationCondition5"]?.ToString();
                        existingReservoirSanitary.Latitude = latitude;
                        existingReservoirSanitary.Longitude = longitude;
                        existingReservoirSanitary.VisitDate = values["visitDate"]?.ToString();
                        existingReservoirSanitary.TheGeom = latitude.HasValue && longitude.HasValue
                            ? new Point(longitude.Value, latitude.Value) { SRID = 4326 }
                            : null;
                        existingReservoirSanitary.EditedBy = username;
                        existingReservoirSanitary.EditedOn = DateTime.UtcNow;
                    }

                    await _WqsContext.SaveChangesAsync();
                }
                catch (Exception ex)
                {
                    var exc = ex.ToString();
                    await Console.Out.WriteLineAsync(exc);
                }
                break;


            case "sourceSanitaryData":
                try
                {
                    var formId = GetValueOrDefault(values, "formId");
                    var existingSourceSanitary = _WqsContext.SourceSanitaries
                        .FirstOrDefault(f => f.FormId == formId && f.Uuid == GetValueOrDefault(values, "uuid"));

                    var latitude = values.ContainsKey("latitude") ? Convert.ToDouble(values["latitude"]) : (double?)null;
                    var longitude = values.ContainsKey("longitude") ? Convert.ToDouble(values["longitude"]) : (double?)null;

                    if (existingSourceSanitary != null)
                    {
                        // Update existing fields
                        existingSourceSanitary.SourceSanitationCondition1 = values["sourceSanitationCondition1"]?.ToString();
                        existingSourceSanitary.SourceSanitationCondition2 = values["sourceSanitationCondition2"]?.ToString();
                        existingSourceSanitary.SourceSanitationCondition3 = values["sourceSanitationCondition3"]?.ToString();
                        existingSourceSanitary.SourceSanitationCondition4 = values["sourceSanitationCondition4"]?.ToString();
                        existingSourceSanitary.SourceSanitationCondition5 = values["sourceSanitationCondition5"]?.ToString();
                        existingSourceSanitary.SourceSanitationCondition6 = values["sourceSanitationCondition6"]?.ToString();
                        existingSourceSanitary.SourceSanitationCondition7 = values["sourceSanitationCondition7"]?.ToString();
                        existingSourceSanitary.SourceSanitationCondition8 = values["sourceSanitationCondition8"]?.ToString();
                        existingSourceSanitary.SourceSanitationCondition9 = values["sourceSanitationCondition9"]?.ToString();
                        existingSourceSanitary.SourceSanitationCondition10 = values["sourceSanitationCondition10"]?.ToString();
                        existingSourceSanitary.SourceSanitationCondition11 = values["sourceSanitationCondition11"]?.ToString();
                        existingSourceSanitary.SourceSanitationCondition12 = values["sourceSanitationCondition12"]?.ToString();
                        existingSourceSanitary.SourceSanitationCondition13 = values["sourceSanitationCondition13"]?.ToString();
                        existingSourceSanitary.SourceSanitationCondition14 = values["sourceSanitationCondition14"]?.ToString();
                        existingSourceSanitary.SourceSanitationCondition15 = values["sourceSanitationCondition15"]?.ToString();
                        existingSourceSanitary.Latitude = latitude;
                        existingSourceSanitary.Longitude = longitude;
                        existingSourceSanitary.VisitDate = values["visitDate"]?.ToString();
                        existingSourceSanitary.TheGeom = latitude.HasValue && longitude.HasValue
                            ? new Point(longitude.Value, latitude.Value) { SRID = 4326 }
                            : null;
                        existingSourceSanitary.EditedBy = username;
                        existingSourceSanitary.EditedOn = DateTime.UtcNow;
                    }
                    else
                    {
                        // Add new record
                        _WqsContext.SourceSanitaries.Add(new SourceSanitary
                        {
                            FormId = formId,
                            Uuid = values["uuid"]?.ToString(),
                            AddedBy = username,
                            AddedOn = DateTime.UtcNow,
                            SourceSanitationCondition1 = values["sourceSanitationCondition1"]?.ToString(),
                            SourceSanitationCondition2 = values["sourceSanitationCondition2"]?.ToString(),
                            SourceSanitationCondition3 = values["sourceSanitationCondition3"]?.ToString(),
                            SourceSanitationCondition4 = values["sourceSanitationCondition4"]?.ToString(),
                            SourceSanitationCondition5 = values["sourceSanitationCondition5"]?.ToString(),
                            SourceSanitationCondition6 = values["sourceSanitationCondition6"]?.ToString(),
                            SourceSanitationCondition7 = values["sourceSanitationCondition7"]?.ToString(),
                            SourceSanitationCondition8 = values["sourceSanitationCondition8"]?.ToString(),
                            SourceSanitationCondition9 = values["sourceSanitationCondition9"]?.ToString(),
                            SourceSanitationCondition10 = values["sourceSanitationCondition10"]?.ToString(),
                            SourceSanitationCondition11 = values["sourceSanitationCondition11"]?.ToString(),
                            SourceSanitationCondition12 = values["sourceSanitationCondition12"]?.ToString(),
                            SourceSanitationCondition13 = values["sourceSanitationCondition13"]?.ToString(),
                            SourceSanitationCondition14 = values["sourceSanitationCondition14"]?.ToString(),
                            SourceSanitationCondition15 = values["sourceSanitationCondition15"]?.ToString(),
                            Latitude = latitude,
                            Longitude = longitude,
                            VisitDate = values["visitDate"]?.ToString(),
                            TheGeom = latitude.HasValue && longitude.HasValue
                                ? new Point(longitude.Value, latitude.Value) { SRID = 4326 }
                                : null

                        });
                    }

                    await _WqsContext.SaveChangesAsync();
                }
                catch (Exception ex)
                {
                    var exc = ex.ToString();
                    await Console.Out.WriteLineAsync(exc);
                }
                break;

            case "structureSanitaryData":
                try
                {
                    var formId = GetValueOrDefault(values, "formId");
                    var existingStructureSanitary = _WqsContext.StructureSanitaries
                        .FirstOrDefault(f => f.FormId == formId && f.Uuid == GetValueOrDefault(values, "uuid"));

                    var latitude = values.ContainsKey("latitude") ? Convert.ToDouble(values["latitude"]) : (double?)null;
                    var longitude = values.ContainsKey("longitude") ? Convert.ToDouble(values["longitude"]) : (double?)null;

                    if (existingStructureSanitary != null)
                    {
                        // Update existing fields
                        existingStructureSanitary.StructureSanitationCondition1 = values["structureSanitationCondition1"]?.ToString();
                        existingStructureSanitary.StructureSanitationCondition2 = values["structureSanitationCondition2"]?.ToString();
                        existingStructureSanitary.StructureSanitationCondition3 = values["structureSanitationCondition3"]?.ToString();
                        existingStructureSanitary.StructureSanitationCondition4 = values["structureSanitationCondition4"]?.ToString();
                        existingStructureSanitary.StructureSanitationCondition5 = values["structureSanitationCondition5"]?.ToString();
                        existingStructureSanitary.StructureSanitationCondition6 = values["structureSanitationCondition6"]?.ToString();
                        existingStructureSanitary.StructureSanitationCondition7 = values["structureSanitationCondition7"]?.ToString();
                        existingStructureSanitary.StructureSanitationCondition8 = values["structureSanitationCondition8"]?.ToString();
                        existingStructureSanitary.StructureSanitationCondition9 = values["structureSanitationCondition9"]?.ToString();
                        existingStructureSanitary.StructureSanitationCondition10 = values["structureSanitationCondition10"]?.ToString();
                        existingStructureSanitary.Latitude = latitude;
                        existingStructureSanitary.Longitude = longitude;
                        existingStructureSanitary.VisitDate = values["visitDate"]?.ToString();
                        existingStructureSanitary.TheGeom = latitude.HasValue && longitude.HasValue
                            ? new Point(longitude.Value, latitude.Value) { SRID = 4326 }
                            : null;
                        existingStructureSanitary.EditedBy = username;
                        existingStructureSanitary.EditedOn = DateTime.UtcNow;
                    }
                    else
                    {
                        // Add new record
                        _WqsContext.StructureSanitaries.Add(new StructureSanitary
                        {
                            FormId = formId,
                            Uuid = values["uuid"]?.ToString(),
                            AddedBy = username,
                            AddedOn = DateTime.UtcNow,
                            StructureSanitationCondition1 = values["structureSanitationCondition1"]?.ToString(),
                            StructureSanitationCondition2 = values["structureSanitationCondition2"]?.ToString(),
                            StructureSanitationCondition3 = values["structureSanitationCondition3"]?.ToString(),
                            StructureSanitationCondition4 = values["structureSanitationCondition4"]?.ToString(),
                            StructureSanitationCondition5 = values["structureSanitationCondition5"]?.ToString(),
                            StructureSanitationCondition6 = values["structureSanitationCondition6"]?.ToString(),
                            StructureSanitationCondition7 = values["structureSanitationCondition7"]?.ToString(),
                            StructureSanitationCondition8 = values["structureSanitationCondition8"]?.ToString(),
                            StructureSanitationCondition9 = values["structureSanitationCondition9"]?.ToString(),
                            StructureSanitationCondition10 = values["structureSanitationCondition10"]?.ToString(),
                            Latitude = latitude,
                            Longitude = longitude,
                            VisitDate = values["visitDate"]?.ToString(),
                            TheGeom = latitude.HasValue && longitude.HasValue
                                ? new Point(longitude.Value, latitude.Value) { SRID = 4326 }
                                : null
                        });
                    }

                    await _WqsContext.SaveChangesAsync();
                }
                catch (Exception ex)
                {
                    var exc = ex.ToString();
                    await Console.Out.WriteLineAsync(exc);
                }
                break;


            case "tapSanitaryData":
                try
                {
                    var existingTapSanitary = _WqsContext.TapSanitaries
                        .FirstOrDefault(f => f.FormId == GetValueOrDefault(values, "formId") && f.Uuid == GetValueOrDefault(values, "uuid"));

                    var latitude = values.ContainsKey("latitude") ? Convert.ToDouble(values["latitude"]) : (double?)null;
                    var longitude = values.ContainsKey("longitude") ? Convert.ToDouble(values["longitude"]) : (double?)null;

                    if (existingTapSanitary == null)
                    {
                        // Add new record if not found
                        _WqsContext.TapSanitaries.Add(new TapSanitary
                        {
                            FormId = values["formId"]?.ToString(),
                            Uuid = values["uuid"]?.ToString(),
                            AddedBy = username,
                            AddedOn = DateTime.UtcNow,
                            TapSanitationCondition1 = values["tapSanitationCondition1"]?.ToString(),
                            TapSanitationCondition2 = values["tapSanitationCondition2"]?.ToString(),
                            TapSanitationCondition3 = values["tapSanitationCondition3"]?.ToString(),
                            TapSanitationCondition4 = values["tapSanitationCondition4"]?.ToString(),
                            TapSanitationCondition5 = values["tapSanitationCondition5"]?.ToString(),
                            TapSanitationCondition6 = values["tapSanitationCondition6"]?.ToString(),
                            TapSanitationCondition7 = values["tapSanitationCondition7"]?.ToString(),
                            Latitude = latitude,
                            Longitude = longitude,
                            VisitDate = values["visitDate"]?.ToString(),
                            TheGeom = latitude.HasValue && longitude.HasValue
                                ? new Point(longitude.Value, latitude.Value) { SRID = 4326 }
                                : null
                        });
                    }
                    else
                    {
                        // Update existing record if found
                        existingTapSanitary.TapSanitationCondition1 = values["tapSanitationCondition1"]?.ToString();
                        existingTapSanitary.TapSanitationCondition2 = values["tapSanitationCondition2"]?.ToString();
                        existingTapSanitary.TapSanitationCondition3 = values["tapSanitationCondition3"]?.ToString();
                        existingTapSanitary.TapSanitationCondition4 = values["tapSanitationCondition4"]?.ToString();
                        existingTapSanitary.TapSanitationCondition5 = values["tapSanitationCondition5"]?.ToString();
                        existingTapSanitary.TapSanitationCondition6 = values["tapSanitationCondition6"]?.ToString();
                        existingTapSanitary.TapSanitationCondition7 = values["tapSanitationCondition7"]?.ToString();
                        existingTapSanitary.Latitude = latitude;
                        existingTapSanitary.Longitude = longitude;
                        existingTapSanitary.VisitDate = values["visitDate"]?.ToString();
                        existingTapSanitary.TheGeom = latitude.HasValue && longitude.HasValue
                            ? new Point(longitude.Value, latitude.Value) { SRID = 4326 }
                            : null;
                        existingTapSanitary.EditedBy = username;
                        existingTapSanitary.EditedOn = DateTime.UtcNow;
                    }

                    await _WqsContext.SaveChangesAsync();
                }
                catch (Exception ex)
                {
                    await Console.Out.WriteLineAsync(ex.ToString());
                }
                break;

           


            // Add cases for other tables...
            default:
                Console.WriteLine($"Table '{tableName}' is not mapped for migration.");
                break;
        }

    }

    public string MapImage(byte[] base64Image)
    {
        string imgUuid = String.Empty;
        try
        {
            if (base64Image == null) return null;
            //var hello = _utc.ImgGetUUid("tbl_");

            imgUuid = _utc.ImgGetUUid("tbl_");
            var path = _utc.GetImgPath(imgUuid);

            // Define file paths
            var originalPath = Path.Combine(_hostEnvironment.ContentRootPath, "wqs_images", "wqs", path, $"{imgUuid}_original.jpg");
            var resizedPath = Path.Combine(_hostEnvironment.ContentRootPath, "wqs_images", "wqs", path, $"{imgUuid}.jpg");

            // Convert base64 string to byte array
            //byte[] imageBytes = Convert.FromBase64String(base64Image);

            // Save the original image
            Img.SaveImageFile(base64Image, originalPath);

            // Resize and save the resized image
            _utc.ResizeImgMain(originalPath, resizedPath);
        }
        catch(Exception ex)
        {
            var exp = ex.ToString();
            Console.WriteLine(exp);
        }
        return $"{imgUuid}.jpg";
    }
    private string GetValueOrDefault(Dictionary<string, object> values, string key)
    {
        return values.TryGetValue(key, out var value) ? value?.ToString() : null;
    }
}
