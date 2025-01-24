using Wq_Surveillance.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Wq_Surveillance.Service;
using Wq_Surveillance.NwashModels;

namespace Wq_Surveillance.Service
{
    public class WQSservices : IWQSservices 
    {
        private readonly WqsContext _wqsContext;
        private readonly NwashContext _nwashContext;
        public WQSservices(WqsContext wqsContext, NwashContext nwashContext)
        {
            _wqsContext = wqsContext;
            _nwashContext = nwashContext;
        }

        public List<Models.Province> GetProvince()
        {
            return _wqsContext.Provinces.OrderBy(item => item.ProvinceCode).ToList();
        }

        public string ExtractNumber(string input)
        {
            if (string.IsNullOrEmpty(input))
                throw new ArgumentException("Input cannot be null or empty.");

            // Trim the input to remove any leading or trailing whitespace
            input = input.Trim();

            // Check if the entire input is a valid number
            if (int.TryParse(input, out int wholeNumber))
            {
                return wholeNumber.ToString();
            }

            // If the input contains a hyphen, try to extract the number from the first part
            if (input.Contains('-'))
            {
                var parts = input.Split('-');
                if (parts.Length < 2)
                    throw new FormatException("Input format is invalid. Expected format: '<<number>> - <<text>>'");

                if (int.TryParse(parts[0].Trim(), out int extractedNumber))
                {
                    return extractedNumber.ToString();
                }
                else
                {
                    throw new FormatException("The number part could not be parsed.");
                }
            }

            // If the input is not a number and does not contain a hyphen, throw an exception
            throw new FormatException("Input is not a valid number or in the expected format: '<<number>> - <<text>>'");
        }

        public (int?, decimal?) GetPopandHH(string ProCode)
        {
            int? totalPop = 0;
            decimal? totalHhServed = 0;
            var pd = _wqsContext.ProjectDetails.FirstOrDefault(p => p.ProCode.Equals(ProCode));
            if (pd != null)
            {
                var projectData = _nwashContext.Taps
                .Where(t => t.ProUuid.Equals(pd.Uuid)).ToList();

                if (projectData != null)
                {
                    totalPop = 0;
                    totalHhServed = 0;
                    foreach (var pdl in projectData)
                    {
                        totalPop += (pdl.MalePop ?? 0) + (pdl.FemalePop ?? 0);
                        totalHhServed += (pdl.HhServerd ?? 0);

                    }
                }
                else
                {
                    totalPop = null;  // Or 0 if it's an int
                    totalHhServed = null;  // Or 0 if it's an int
                }
            }
            else
            {
                totalPop = null;  // Or 0 if it's an int
                totalHhServed = null;  // Or 0 if it's an int
            }
            return (totalPop, totalHhServed);
        }
        //  public (int?, decimal?) GetPopandHH(string ProCode)
        //{
        //    int? totalPop = 0;
        //    decimal? totalHhServed = 0;
        //    var pd = _wqsContext.ProjectDetails.FirstOrDefault(p => p.ProCode.Equals(ProCode));
        //    if (pd != null)
        //    {
        //        var projectData = _wqsContext.Taps
        //        .Where(t => t.ProUuid.Equals(pd.Uuid)).ToList();

        //        if (projectData != null)
        //        {
        //            totalPop = 0;
        //            totalHhServed = 0;
        //            foreach (var pdl in projectData)
        //            {
        //                totalPop += (pdl.MalePop ?? 0) + (pdl.FemalePop ?? 0);
        //                totalHhServed += (pdl.HhServerd ?? 0);

        //            }
        //        }
        //        else
        //        {
        //            totalPop = null;  // Or 0 if it's an int
        //            totalHhServed = null;  // Or 0 if it's an int
        //        }
        //    }
        //    else
        //    {
        //        totalPop = null;  // Or 0 if it's an int
        //        totalHhServed = null;  // Or 0 if it's an int
        //    }
        //    return (totalPop, totalHhServed);
        //}

        public Dictionary<string, string> GetFormId(string munCode)
        {
            return _wqsContext.WqSurveillanceMains
                .AsEnumerable()
                .Where(s => s.Municipality != null && ExtractNumber(s.Municipality) == munCode)
                .OrderByDescending(item => item.Id)
                .ToDictionary(item => item.Uuid, item => item.ProjectName);
        }
        public Dictionary<string, string> GetAddress(string munCode)
        {
            return _wqsContext.WqSurveillanceMains
                .AsEnumerable() // Converts to in-memory collection
                .Where(s => s.Municipality != null && ExtractNumber(s.Municipality) == munCode)
                .OrderByDescending(item => item.Id)
                .ToDictionary(item => item.Uuid, item => item.Address);
        }
        public Dictionary<string, int> GetHH(string munCode)
        {
            return _wqsContext.WqSurveillanceMains
                                .AsEnumerable() 

                .Where(s => s.Municipality != null && ExtractNumber(s.Municipality) == munCode)
                .OrderByDescending(item => item.Id) // Sort by Id in descending order
                .ToDictionary(item => item.Uuid, item => item.TotalHhServed ?? 0); // Handle null TotalHHServed
        }
        public Dictionary<string, int> GetPop(string munCode)
        {
            return _wqsContext.WqSurveillanceMains
                                .AsEnumerable() // Converts to in-memory collection

                .Where(s => s.Municipality != null && ExtractNumber(s.Municipality) == munCode)
                .OrderByDescending(item => item.Id) // Sort by Id in descending order
                .ToDictionary(item => item.Uuid, item => item.TotalBenificiaryPopulation ?? 0); // Handle null TotalHHServed
        }
          public Dictionary<string, string> GetName(string munCode)
        {
            return _wqsContext.ProjectDetails
                .AsEnumerable() // Converts to in-memory collection
                .Where(s => s.MunicipalityCode != null && ExtractNumber(s.MunicipalityCode) == munCode)
                .OrderByDescending(item => item.Id)
                .ToDictionary(item => item.Uuid, item => item.ProName);
        }

        public string GetName(string procode)
        {
            return _wqsContext.ProjectDetails
                .Where(s => s.ProCode != null && s.ProCode == procode)
                .Select(s => s.ProName)
                             .FirstOrDefault();
        }


        public Form1a UpdateWQSDataFA (Form1a WData, string username)
        {
            var getData = _wqsContext.Form1as
                            .Where(s => s.FormId == WData.FormId)
                            .FirstOrDefault();

            if (getData != null)
            {
                getData.WspInitiativeStatus1 = WData.WspInitiativeStatus1;
                getData.WspInitiativeRemarks1 = WData.WspInitiativeRemarks1;
                getData.WspInitiativeStatus2 = WData.WspInitiativeStatus2;
                getData.WspInitiativeRemarks2 = WData.WspInitiativeRemarks2;
                getData.WspInitiativeStatus3 = WData.WspInitiativeStatus3;
                getData.WspInitiativeRemarks3 = WData.WspInitiativeRemarks3;
                getData.WspInitiativeStatus4 = WData.WspInitiativeStatus4;
                getData.WspInitiativeRemarks4 = WData.WspInitiativeRemarks4;
                getData.WspInitiativeStatus5 = WData.WspInitiativeStatus5;
                getData.WspInitiativeRemarks5 = WData.WspInitiativeRemarks5;
                getData.WspInitiativeStatus6 = WData.WspInitiativeStatus6;
                getData.WspInitiativeRemarks6 = WData.WspInitiativeRemarks6;
                getData.WspInitiativeStatus7 = WData.WspInitiativeStatus7;
                getData.WspInitiativeRemarks7 = WData.WspInitiativeRemarks7;
                getData.WspInitiativeSecurityPlan = WData.WspInitiativeSecurityPlan;
                getData.WspInitiativeWaterQualityStatus = WData.WspInitiativeWaterQualityStatus;
                getData.WspInitiativeInfectedByDiarrhea = WData.WspInitiativeInfectedByDiarrhea;
                getData.WspInitiativeDiedByDiarrhea = WData.WspInitiativeDiedByDiarrhea;
                getData.WspInitiativeWaterDisease = WData.WspInitiativeWaterDisease;
                getData.WspInitiativeNoticeSource = WData.WspInitiativeNoticeSource;
                getData.WspInitiativeWrittenResult = WData.WspInitiativeWrittenResult;
                getData.WspInitiativeSuggestion = WData.WspInitiativeSuggestion;
                getData.EditedBy = username; 
                getData.EditedOn = DateTime.UtcNow;


                _wqsContext.Update(getData);
                _wqsContext.SaveChanges();
                return getData;
            }
            else
            {
                return new Form1a();
            }
        }
        public Form1b UpdateWQSDataFB(Form1b WData, string username)
        {
            var getData = _wqsContext.Form1bs
                            .Where(s => s.FormId == WData.FormId)
                            .FirstOrDefault();

            if (getData != null)
            {
                getData.FormId = WData.FormId;
                getData.TeamFormationScore = WData.TeamFormationScore;
                getData.SystemAnalysisScore = WData.SystemAnalysisScore;
                getData.PollutionRiskControlMeasureScore = WData.PollutionRiskControlMeasureScore;
                getData.ImprovementPlanScore = WData.ImprovementPlanScore;
                getData.MonitoringScore = WData.MonitoringScore;
                getData.CertificationScore = WData.CertificationScore;
                getData.CollaborativeActivitiesScore = WData.CollaborativeActivitiesScore;
                getData.ReviewScore = WData.ReviewScore;
                getData.TotalScore = WData.TotalScore;
                getData.EditedBy = username;
                getData.EditedOn = DateTime.UtcNow;
                // Save changes
                _wqsContext.Update(getData);
                _wqsContext.SaveChanges();

                return getData;
            }
            else
            {
                // Return a new Form1b instance if no matching record is found
                return new Form1b();
            }
        }
        public Form2 UpdateWQSDataF2(Form2 WData, string username)
        {
            var getData = _wqsContext.Form2s
                            .Where(s => s.FormId == WData.FormId)
                            .FirstOrDefault();

            if (getData != null)
            {
                // Update properties with values from WData
                getData.FormId = WData.FormId;
                getData.SourceBasicEvaluation = WData.SourceBasicEvaluation;
                getData.SourceBasicEvaluationRemarks = WData.SourceBasicEvaluationRemarks;
                getData.TreatmentCenterBasicEvaluation = WData.TreatmentCenterBasicEvaluation;
                getData.TreatmentCenterBasicEvaluationRemarks = WData.TreatmentCenterBasicEvaluationRemarks;
                getData.WaterReservoirBasicEvaluation = WData.WaterReservoirBasicEvaluation;
                getData.WaterReservoirBasicEvaluationRemarks = WData.WaterReservoirBasicEvaluationRemarks;
                getData.PipelineBasicEvaluation = WData.PipelineBasicEvaluation;
                getData.PipelineBasicEvaluationRemarks = WData.PipelineBasicEvaluationRemarks;
                getData.StorageUsageBasicEvaluation = WData.StorageUsageBasicEvaluation;
                getData.StorageUsageBasicEvaluationRemarks = WData.StorageUsageBasicEvaluationRemarks;
                getData.PollutionPossibility = WData.PollutionPossibility;
                getData.PollutionPossibilityTypes = WData.PollutionPossibilityTypes;
                getData.DefInfectedByDiarrhea = WData.DefInfectedByDiarrhea;
                getData.DefDiedByDiarrhea = WData.DefDiedByDiarrhea;
                getData.DefWaterDisease = WData.DefWaterDisease;
                getData.DefNoticeSource = WData.DefNoticeSource;
                getData.DefWrittenResult = WData.DefWrittenResult;
                getData.DefSuggestion = WData.DefSuggestion;
                getData.EditedBy = username;
                getData.EditedOn = DateTime.UtcNow;
                // Save changes
                _wqsContext.Update(getData);
                _wqsContext.SaveChanges();

                return getData;
            }
            else
            {
                // Return a new Form2 instance if no matching record is found
                return new Form2();
            }
        }
        public string UpdateWQSDataF3(Form3 WData, string username)
        {
            var getData = _wqsContext.Form3s
                            .Where(s => s.Id == WData.Id)
                            .FirstOrDefault();

            if (getData != null)
            {
                getData.Month = WData.Month;
                getData.DiarrheaCount = WData.DiarrheaCount;
                getData.CholeraCount = WData.CholeraCount;
                getData.TyphoidCount = WData.TyphoidCount;
                getData.DysenteryCount = WData.DysenteryCount;
                getData.HepatitisCount = WData.HepatitisCount;
                getData.EditedBy = username;
                getData.EditedOn = DateTime.UtcNow;
                // Save changes
                _wqsContext.Update(getData);
                _wqsContext.SaveChanges();

                return getData.FormId;
            }
            else
            {
                // Return a new Form3 instance if no matching record is found
                return string.Empty;
            }
        }
        public ReservoirSanitary UpdateWQSDataRes(ReservoirSanitary WData, string username)
        {
            var getData = _wqsContext.ReservoirSanitaries
                            .Where(s => s.FormId == WData.FormId)
                            .FirstOrDefault();

            if (getData != null)
            {
                getData.ResorvoirSanitationCondition1 = WData.ResorvoirSanitationCondition1;
                getData.ResorvoirSanitationCondition2 = WData.ResorvoirSanitationCondition2;
                getData.ResorvoirSanitationCondition3 = WData.ResorvoirSanitationCondition3;
                getData.ResorvoirSanitationCondition4 = WData.ResorvoirSanitationCondition4;
                getData.ResorvoirSanitationCondition5 = WData.ResorvoirSanitationCondition5;
                getData.EditedBy = username;
                getData.EditedOn = DateTime.UtcNow;
                _wqsContext.Update(getData);
                _wqsContext.SaveChanges();
                return getData;
            }
            else
            {
                return new ReservoirSanitary();
            }
        }

        public SourceSanitary UpdateWQSDataSou(SourceSanitary WData, string username)
        {
            var getData = _wqsContext.SourceSanitaries
                            .Where(s => s.FormId == WData.FormId)
                            .FirstOrDefault();

            if (getData != null)
            {
                getData.SourceSanitationCondition1 = WData.SourceSanitationCondition1;
                getData.SourceSanitationCondition2 = WData.SourceSanitationCondition2;
                getData.SourceSanitationCondition3 = WData.SourceSanitationCondition3;
                getData.SourceSanitationCondition4 = WData.SourceSanitationCondition4;
                getData.SourceSanitationCondition5 = WData.SourceSanitationCondition5;
                getData.SourceSanitationCondition6 = WData.SourceSanitationCondition6;
                getData.SourceSanitationCondition7 = WData.SourceSanitationCondition7;
                getData.SourceSanitationCondition8 = WData.SourceSanitationCondition8;
                getData.SourceSanitationCondition9 = WData.SourceSanitationCondition9;
                getData.SourceSanitationCondition10 = WData.SourceSanitationCondition10;
                getData.SourceSanitationCondition11 = WData.SourceSanitationCondition11;
                getData.SourceSanitationCondition12 = WData.SourceSanitationCondition12;
                getData.SourceSanitationCondition13 = WData.SourceSanitationCondition13;
                getData.SourceSanitationCondition14 = WData.SourceSanitationCondition14;
                getData.SourceSanitationCondition15 = WData.SourceSanitationCondition15;
                getData.EditedBy = username;
                getData.EditedOn = DateTime.UtcNow;
                _wqsContext.Update(getData);
                _wqsContext.SaveChanges();
                return getData;
            }
            else
            {
                return new SourceSanitary();
            }
        }

        public StructureSanitary UpdateWQSDataStr(StructureSanitary WData, string username)
        {
            var getData = _wqsContext.StructureSanitaries
                            .Where(s => s.FormId == WData.FormId)
                            .FirstOrDefault();

            if (getData != null)
            {
                getData.StructureSanitationCondition1 = WData.StructureSanitationCondition1;
                getData.StructureSanitationCondition2 = WData.StructureSanitationCondition2;
                getData.StructureSanitationCondition3 = WData.StructureSanitationCondition3;
                getData.StructureSanitationCondition4 = WData.StructureSanitationCondition4;
                getData.StructureSanitationCondition5 = WData.StructureSanitationCondition5;
                getData.StructureSanitationCondition6 = WData.StructureSanitationCondition6;
                getData.StructureSanitationCondition7 = WData.StructureSanitationCondition7;
                getData.StructureSanitationCondition8 = WData.StructureSanitationCondition8;
                getData.StructureSanitationCondition9 = WData.StructureSanitationCondition9;
                getData.StructureSanitationCondition10 = WData.StructureSanitationCondition10;
                getData.EditedBy = username;
                getData.EditedOn = DateTime.UtcNow;
                _wqsContext.Update(getData);
                _wqsContext.SaveChanges();
                return getData;
            }
            else
            {
                return new StructureSanitary();
            }
        }
        public TapSanitary UpdateWQSDataTap(TapSanitary WData, string username)
        {
            var getData = _wqsContext.TapSanitaries
                            .Where(s => s.FormId == WData.FormId)
                            .FirstOrDefault();

            if (getData != null)
            {
                getData.TapSanitationCondition1 = WData.TapSanitationCondition1;
                getData.TapSanitationCondition2 = WData.TapSanitationCondition2;
                getData.TapSanitationCondition3 = WData.TapSanitationCondition3;
                getData.TapSanitationCondition4 = WData.TapSanitationCondition4;
                getData.TapSanitationCondition5 = WData.TapSanitationCondition5;
                getData.TapSanitationCondition6 = WData.TapSanitationCondition6;
                getData.TapSanitationCondition7 = WData.TapSanitationCondition7;
                getData.EditedBy = username;
                getData.EditedOn = DateTime.UtcNow;
                _wqsContext.Update(getData);
                _wqsContext.SaveChanges();
                return getData;
            }
            else
            {
                return new TapSanitary();
            }
        }



        public int DeleteFA(string FormId)
        {
            var delData = _wqsContext.Form1as
                            .Where(s => (s.FormId == FormId))
                            .FirstOrDefault();
            var delValue = 0;

            if (delData != null)
            {
                _wqsContext.Form1as.Remove(delData);
                delValue = _wqsContext.SaveChanges();
            }

            return delValue;
        }
        public int DeleteFB(string FormId)
        {
            var delData = _wqsContext.Form1bs
                            .Where(s => (s.FormId == FormId))
                            .FirstOrDefault();
            var delValue = 0;

            if (delData != null)
            {
                _wqsContext.Form1bs.Remove(delData);
                delValue = _wqsContext.SaveChanges();
            }

            return delValue;
        }
        public int Delete2(string FormId)
        {
            var delData = _wqsContext.Form2s
                            .Where(s => (s.FormId == FormId))
                            .FirstOrDefault();
            var delValue = 0;

            if (delData != null)
            {
                _wqsContext.Form2s.Remove(delData);
                delValue = _wqsContext.SaveChanges();
            }

            return delValue;
        }
        public int Delete3(string FormId)
        {
            var delData = _wqsContext.Form3s
                            .Where(s => (s.FormId == FormId))
                            .FirstOrDefault();
            var delValue = 0;

            if (delData != null)
            {
                _wqsContext.Form3s.Remove(delData);
                delValue = _wqsContext.SaveChanges();
            }

            return delValue;
        }
        public int DeleteRes(string FormId)
        {
            var delData = _wqsContext.ReservoirSanitaries
                            .Where(s => (s.FormId == FormId))
                            .FirstOrDefault();
            var delValue = 0;

            if (delData != null)
            {
                _wqsContext.ReservoirSanitaries.Remove(delData);
                delValue = _wqsContext.SaveChanges();
            }

            return delValue;
        }
        public int DeleteSou(string FormId)
        {
            var delData = _wqsContext.SourceSanitaries
                            .Where(s => (s.FormId == FormId))
                            .FirstOrDefault();
            var delValue = 0;

            if (delData != null)
            {
                _wqsContext.SourceSanitaries.Remove(delData);
                delValue = _wqsContext.SaveChanges();
            }

            return delValue;
        }
        public int DeleteStr(string FormId)
        {
            var delData = _wqsContext.StructureSanitaries
                            .Where(s => (s.FormId == FormId))
                            .FirstOrDefault();
            var delValue = 0;

            if (delData != null)
            {
                _wqsContext.StructureSanitaries.Remove(delData);
                delValue = _wqsContext.SaveChanges();
            }

            return delValue;
        }
        public int DeleteTap(string FormId)
        {
            var delData = _wqsContext.TapSanitaries
                            .Where(s => (s.FormId == FormId))
                            .FirstOrDefault();
            var delValue = 0;

            if (delData != null)
            {
                _wqsContext.TapSanitaries.Remove(delData);
                delValue = _wqsContext.SaveChanges();
            }

            return delValue;
        }

    }
}
