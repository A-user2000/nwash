using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Wq_Surveillance.Models;
using Wq_Surveillance.Models.API;
using Wq_Surveillance.Service.Other;

namespace Wq_Surveillance.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ServiceController : ControllerBase
    {
        private readonly IWebHostEnvironment _hostEnvironment;
        private readonly WqsContext _WqsContext;
        private IOtherService _utc;


        public ServiceController(IWebHostEnvironment hostEnvironment, WqsContext WqsContext, IOtherService utc)
        {
            _hostEnvironment = hostEnvironment;
            _WqsContext = WqsContext;
            _utc = utc;

        }
        [HttpPost("FileCreation")] //for img folder in wqs_images
        public string FileCreationMain()
        {
            List<string> Folders = new List<string> { "wqs" };
            foreach (var folder in Folders)
            {
                string baseDirectory = Path.Combine(_hostEnvironment.ContentRootPath, "wqs_images", folder);
                int nestingLevels = 3;
                CreateFolders(baseDirectory, nestingLevels);
                Console.WriteLine("Folders created successfully.");
            }
            return "finish";
        }
        static void CreateFolders(string basePath, int levels)
        {
            if (levels == 0)
                return;

            for (int i = '0'; i <= 'f'; i++)
            {
                if (i == 58)
                {
                    i = 97;
                }
                string folderName = ((char)i).ToString();

                if (folderName != ":" && folderName != ">")
                {
                    string folderPath = Path.Combine(basePath, folderName);

                    if (!Directory.Exists(folderPath))
                    {
                        Directory.CreateDirectory(folderPath);
                    }
                    CreateFolders(folderPath, levels - 1);
                }
            }
        }
        [HttpPost("WqsSync")]
        public async Task<IActionResult> WqsPostAsync([FromForm] SyncFileCredential syncFileCredential)
        {
            if (!ModelState.IsValid)
                return BadRequest(new { result = false, message = "Insufficient Data" });

            var checkUser = _WqsContext.Users
                .FirstOrDefault(s => s.Email == syncFileCredential.Username && s.Status == 1);

            if (checkUser == null)
                return BadRequest(new { result = false, message = "Invalid or Unregistered User" });

            string sqliteFolder = Path.Combine(_hostEnvironment.WebRootPath, "sqlitedb");
            string sqliteDbPath = Path.Combine(sqliteFolder, syncFileCredential.DbFile.FileName);

            Directory.CreateDirectory(sqliteFolder);

            try
            {
                // Save uploaded SQLite file
                await using (var fileStream = new FileStream(sqliteDbPath, FileMode.Create, FileAccess.Write, FileShare.None))
                {
                    await syncFileCredential.DbFile.CopyToAsync(fileStream);
                }

                // Wait for file release if locked
                WaitForFileRelease(sqliteDbPath);

                // Process the SQLite file
                WqsSync wqsSync = new WqsSync(_hostEnvironment, _WqsContext, _utc);

                var returnTuple = await Task.Run(() => wqsSync.ReadAndSaveDBWqs(sqliteDbPath, checkUser.Name));

                bool dataSynced = returnTuple.Item1;

                if (dataSynced)
                {
                    string syncedPath = Path.Combine(sqliteFolder, "synceddb", "WqsSynced");
                    Directory.CreateDirectory(syncedPath);

                    string syncedFilePath = Path.Combine(syncedPath, syncFileCredential.DbFile.FileName);
                    MoveFileSafely(sqliteDbPath, syncedFilePath);
                }
                else
                {
                    string unsyncPath = Path.Combine(sqliteFolder, "unsyncdb", "Wqs");
                    Directory.CreateDirectory(unsyncPath);

                    string newFileName = $"{Path.GetFileNameWithoutExtension(syncFileCredential.DbFile.FileName)}_{checkUser.Name}{Path.GetExtension(syncFileCredential.DbFile.FileName)}";
                    string unsyncedFilePath = Path.Combine(unsyncPath, newFileName);

                    MoveFileSafely(sqliteDbPath, unsyncedFilePath);
                }

                return Ok(new { result = returnTuple.Item1, message = returnTuple.Item2 });
            }
            catch (IOException ex)
            {
                return StatusCode(500, new { result = false, message = $"File error: {ex.Message}" });
            }
            catch (Exception ex)
            {
                var x = ex.ToString();
                return StatusCode(500, new { result = false, message = $"Error: {ex.Message}" });
            }
            finally
            {
                await CleanupFileWithRetries(sqliteDbPath);
            }
        }

        private void WaitForFileRelease(string filePath, int maxRetries = 10, int delayMilliseconds = 500)
        {
            for (int i = 0; i < maxRetries; i++)
            {
                try
                {
                    using (var stream = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.None))
                    {
                        return; // File is accessible
                    }
                }
                catch (IOException)
                {
                    Task.Delay(delayMilliseconds).Wait();
                }
            }

            throw new IOException("File is locked for too long.");
        }

        private void MoveFileSafely(string sourcePath, string destinationPath)
        {
            const int maxRetries = 3;
            const int delayBetweenRetries = 1000;

            for (int i = 0; i < maxRetries; i++)
            {
                try
                {
                    System.IO.File.Move(sourcePath, destinationPath, true);
                    return;
                }
                catch (IOException)
                {
                    if (i == maxRetries - 1) throw;
                    Task.Delay(delayBetweenRetries).Wait();
                }
            }
        }

        private async Task CleanupFileWithRetries(string filePath)
        {
            const int maxRetries = 5;
            const int delay = 500;

            for (int i = 0; i < maxRetries; i++)
            {
                try
                {
                    if (System.IO.File.Exists(filePath))
                    {
                        System.IO.File.Delete(filePath);
                    }
                    return;
                }
                catch (IOException)
                {
                    await Task.Delay(delay);
                }
            }
        }
    }
}





//using Microsoft.AspNetCore.Mvc;
//using Microsoft.Data.Sqlite;
//using Wq_Surveillance.Controllers;
//using Microsoft.EntityFrameworkCore;
//using System.Security.Policy;
//using Azure.Identity;
//using Wq_Surveillance.Service.OtherService;
//using Wq_Surveillance.Models;
//using Newtonsoft.Json;
//using Wq_Surveillance.Models.API;

//namespace Wq_Surveillance.Controllers
//{
//    [Route("[controller]")]
//    [ApiController]
//    public class ServiceController : ControllerBase
//    {
//        private static IWebHostEnvironment _hostEnvironment;
//        private readonly WqsContext _WqsContext;
//        public ServiceController(IWebHostEnvironment hostEnvironment, WqsContext WqsContext)
//        {
//            _hostEnvironment = hostEnvironment;
//            _WqsContext = WqsContext;
//        }

//        // GET: api/Service
//        [HttpGet]
//        public IEnumerable<string> Get()
//        {
//            return new string[] { "value1", "value2" };
//        }

//        // GET: api/Service/5
//        [HttpGet("{id}", Name = "GetService")]
//        public string Get(int id)
//        {
//            return "value";
//        }

//        [HttpPost("WqsSync")]
//        //[HttpPost("WqsSync/{username}")]
//        public async Task<string> WqsPostAsync([FromForm] SyncFileCredential syncFileCredential)
//        //public string WqsPostAsync([FromForm] IFormFile file, string username)
//        {
//            // WqsSync handles reading SQLite DB and migrating data
//            WqsSync wqsSync = new WqsSync(_hostEnvironment, _WqsContext);
//            //// Get current app version
//            //var version = WqsContext.ApkDetails
//            //                .Where(s => s.AppName == "NWASH WQS")
//            //                .OrderBy(s => s.Id)
//            //                .Select(s => s.AppVersion)
//            //                .FirstOrDefault();

//            if (ModelState.IsValid)
//            {
//                // Create the folder to store SQLite DB if it doesn't exist
//                string sqliteFolder = Path.Combine(_hostEnvironment.WebRootPath, "sqlitedb");
//                if (!Directory.Exists(sqliteFolder))
//                {
//                    Directory.CreateDirectory(sqliteFolder);
//                }

//                // Save the uploaded SQLite file
//                string sqliteDbPath = Path.Combine(sqliteFolder, syncFileCredential.DbFile.FileName);

//                // Validate the user
//                var checkUser = _WqsContext.Users
//                                .FirstOrDefault(s => s.Email == syncFileCredential.Username && s.Status == 1);

//                if (checkUser != null)
//                {
//                    Tuple<bool, string> returnTuple = new Tuple<bool, string>(false, "No message");
//                    //Tuple<bool, string, string> returnTuple = new Tuple<bool, string, string>(false, "No message", version);

//                    using (var fileStream = new FileStream(sqliteDbPath, FileMode.Create))
//                    {
//                        await syncFileCredential.DbFile.CopyToAsync(fileStream);

//                        // Call to read and save SQLite DB data
//                        returnTuple = await wqsSync.ReadAndSaveDBWqs(sqliteDbPath, checkUser.Name);
//                    }

//                    // Prepare JSON response
//                    bool dataSynced = returnTuple.Item1;
//                    string json = JsonConvert.SerializeObject(returnTuple);
//                    json = json.Replace("Item1", "result")
//                               .Replace("Item2", "message")
//                               .Replace("Item3", "version");

//                    if (dataSynced)
//                    {
//                        // Move file to synceddb folder
//                        string syncedPath = Path.Combine(_hostEnvironment.WebRootPath, "sqlitedb", "synceddb", "WqsSynced");
//                        if (!Directory.Exists(syncedPath))
//                        {
//                            Directory.CreateDirectory(syncedPath);
//                        }

//                        string fileName = Path.GetFileName(syncFileCredential.DbFile.FileName);

//                       using (FileStream syncedFileStream = new FileStream(Path.Combine(syncedPath, fileName), FileMode.Create, FileAccess.Write, FileShare.None))
//{
//    await syncFileCredential.DbFile.CopyToAsync(syncedFileStream);
//}


//                        // Delete the temporary file
//                        if (System.IO.File.Exists(sqliteDbPath))
//                        {
//                            System.IO.File.Delete(sqliteDbPath);
//                        }

//                        return json;
//                    }
//                    else
//                    {
//                        // Move file to unsynceddb folder
//                        if (System.IO.File.Exists(sqliteDbPath))
//                        {
//                            string unsyncPath = Path.Combine(_hostEnvironment.WebRootPath, "sqlitedb", "unsyncdb", "Wqs");
//                            if (!Directory.Exists(unsyncPath))
//                            {
//                                Directory.CreateDirectory(unsyncPath);
//                            }

//                            string newFileName = $"{Path.GetFileNameWithoutExtension(syncFileCredential.DbFile.FileName)}_{checkUser.Name}{Path.GetExtension(syncFileCredential.DbFile.FileName)}";
//                            string newFilePath = Path.Combine(unsyncPath, newFileName);

//                            System.IO.File.Move(sqliteDbPath, newFilePath, true);
//                        }
//                        return json;
//                    }
//                }
//                else
//                {
//                    // User validation failed
//                    Tuple<bool, string> returnTuple = new Tuple<bool, string>(false, "Invalid or Unregistered User");
//                    string json = JsonConvert.SerializeObject(returnTuple);
//                    json = json.Replace("Item1", "result")
//                               .Replace("Item2", "message")
//                               .Replace("Item3", "version");
//                    return json;
//                }
//            }
//            else
//            {
//                // Model state invalid
//                Tuple<bool, string> returnTuple = new Tuple<bool, string>(false, "Insufficient Data");
//                string json = JsonConvert.SerializeObject(returnTuple);
//                json = json.Replace("Item1", "result")
//                           .Replace("Item2", "message")
//                           .Replace("Item3", "version");
//                return json;
//            }
//        }
//    }
//}

//        /*
//         * Household Sync
//         */

//        // POST: service/Service/HouseholdSync
//        [HttpPost("Wq_SurveillanceSync")]
//        public async Task<string> Wq_SurveillanceSync([FromForm] SyncFileCredential syncFileCredential)
//        {
//            Wq_SurveillanceSync sSync = new Wq_SurveillanceSync(_hostEnvironment, WqsContext, _utc);
//            var version = WqsContext.ApkDetails.Where(s => s.AppName == "Wq_Surveillance").OrderBy(s => s.Id).Select(s => s.AppVersion).FirstOrDefault();
//            if (ModelState.IsValid)
//            {
//                string sqliteFolder = Path.Combine(_hostEnvironment.WebRootPath, "sqlitedb");
//                if (!Directory.Exists(sqliteFolder))
//                {
//                    Directory.CreateDirectory(sqliteFolder);
//                }
//                string sqlitedbPath = Path.Combine(sqliteFolder, syncFileCredential.DbFile.FileName);

//                var checkUser = WqsContext.Users.OrderBy(S => S.UserId)
//                                .FirstOrDefault(s => s.Email == syncFileCredential.Username && s.Status == 1);

//                if (checkUser != null)
//                {
//                    Tuple<bool, string, string> returnTuple = new Tuple<bool, string, string>(false, "no message", version);

//                    using (var fileStream = new FileStream(sqlitedbPath, FileMode.Create))
//                    {
//                        await syncFileCredential.DbFile.CopyToAsync(fileStream);

//                        returnTuple = await sSync.ReadAndSaveDBWq_Surveillance(sqlitedbPath, (int)checkUser.TrainingUser);
//                    }

//                    bool DataSynced = returnTuple.Item1;
//                    string json = JsonConvert.SerializeObject(returnTuple);
//                    Console.WriteLine(json);
//                    json = json.Replace("Item1", "result");
//                    json = json.Replace("Item2", "message");
//                    json = json.Replace("Item3", "version");

//                    if (DataSynced)
//                    {
//                        string path = Path.Combine(_hostEnvironment.WebRootPath, "sqlitedb", "synceddb", "HHsSynced");

//                        string fileName = Path.GetFileName(syncFileCredential.DbFile.FileName);

//                        using (FileStream SyncFileUpload = new FileStream(Path.Combine(path, fileName), FileMode.Create))
//                        {
//                            syncFileCredential.DbFile.CopyTo(SyncFileUpload);
//                        }

//                        //Directory.Delete(Path.GetDirectoryName(sqlitedbPath),true); 

//                        //if (System.IO.File.Exists(sqlitedbPath))
//                        //{
//                        //    System.IO.File.Delete(sqlitedbPath);
//                        //}
//                        return json;
//                    }

//                    else
//                    {
//                        if (System.IO.File.Exists(sqlitedbPath))
//                        {
//                            var unsyncfile = Path.Combine(_hostEnvironment.WebRootPath, "sqlitedb", "unsyncdb", "HH");
//                            var Username = WqsContext.Users.Where(s => s.Email == syncFileCredential.Username).OrderBy(s => s.UserId).Select(s => s.Name).FirstOrDefault();
//                            var newFileName = syncFileCredential.DbFile.FileName.Split('.')[0] + "_" + Username + '.' + syncFileCredential.DbFile.FileName.Split('.')[1]; // New name for the file
//                            var newFilePath = Path.Combine(unsyncfile, newFileName);
//                            System.IO.File.Move(sqlitedbPath, newFilePath, true);
//                            if (System.IO.File.Exists(sqlitedbPath))
//                            {
//                                System.IO.File.Delete(sqlitedbPath);
//                            }
//                        }
//                        return json;
//                    }
//                }
//                else
//                {
//                    Tuple<bool, string, string> returnTuple = new Tuple<bool, string, string>(false, "Invalid or Unregistered User", version);
//                    string json = JsonConvert.SerializeObject(returnTuple);
//                    Console.WriteLine(json);
//                    json = json.Replace("Item1", "result");
//                    json = json.Replace("Item2", "message");
//                    json = json.Replace("Item3", "version");

//                    return json;
//                }
//            }
//            else
//            {
//                Tuple<bool, string, string> returnTuple = new Tuple<bool, string, string>(false, "Insufficient Data", version);
//                string json = JsonConvert.SerializeObject(returnTuple);
//                Console.WriteLine(json);
//                json = json.Replace("Item1", "result");
//                json = json.Replace("Item2", "message");
//                json = json.Replace("Item3", "version");

//                return json;
//            }
//        }
//    }

//    //    /*
//    //     * School Sync
//    //     */

//    //    // POST: service/Service/SchoolSync
//    //    [HttpPost("SchoolSync")]
//    //    public async Task<string> SchoolPostAsync([FromForm] SyncFileCredential syncFileCredential)
//    //    {
//    //        SchoolSync sSync = new SchoolSync(_hostEnvironment, _wqsContext, _trainingdnContext, _utc);
//    //        var version = _wqsContext.ApkDetails.Where(s => s.AppName == "NWASH School").OrderBy(s => s.Id).Select(s => s.AppVersion).FirstOrDefault();
//    //        if (ModelState.IsValid)
//    //        {
//    //            string sqliteFolder = Path.Combine(_hostEnvironment.WebRootPath, "sqlitedb");
//    //            if (!Directory.Exists(sqliteFolder))
//    //            {
//    //                Directory.CreateDirectory(sqliteFolder);
//    //            }
//    //            string sqlitedbPath = Path.Combine(sqliteFolder, syncFileCredential.DbFile.FileName);

//    //            var checkUser = _wqsContext.Users.OrderBy(S => S.UserId)
//    //                            .FirstOrDefault(s => s.Email == syncFileCredential.Username && s.Status == 1);

//    //            if (checkUser != null)
//    //            {
//    //                Tuple<bool, string, string> returnTuple = new Tuple<bool, string, string>(false, "no message", version);

//    //                using (var fileStream = new FileStream(sqlitedbPath, FileMode.Create))
//    //                {
//    //                    await syncFileCredential.DbFile.CopyToAsync(fileStream);

//    //                    returnTuple = await sSync.ReadAndSaveDBSchool(sqlitedbPath, (int)checkUser.TrainingUser, checkUser.Name);
//    //                }

//    //                bool DataSynced = returnTuple.Item1;
//    //                string json = JsonConvert.SerializeObject(returnTuple);
//    //                Console.WriteLine(json);
//    //                json = json.Replace("Item1", "result");
//    //                json = json.Replace("Item2", "message");
//    //                json = json.Replace("Item3", "version");

//    //                if (DataSynced)
//    //                {
//    //                    string path = Path.Combine(_hostEnvironment.WebRootPath, "sqlitedb", "synceddb", "SchoolSynced");

//    //                    string fileName = Path.GetFileName(syncFileCredential.DbFile.FileName);

//    //                    using (FileStream SyncFileUpload = new FileStream(Path.Combine(path, fileName), FileMode.Create))
//    //                    {
//    //                        syncFileCredential.DbFile.CopyTo(SyncFileUpload);
//    //                    }

//    //                    if (System.IO.File.Exists(sqlitedbPath))
//    //                    {
//    //                        System.IO.File.Delete(sqlitedbPath);
//    //                    }
//    //                    return json;
//    //                }
//    //                else
//    //                {
//    //                    if (System.IO.File.Exists(sqlitedbPath))
//    //                    {
//    //                        var unsyncfile = Path.Combine(_hostEnvironment.WebRootPath, "sqlitedb", "unsyncdb", "School");
//    //                        var Username = _wqsContext.Users.Where(s => s.Email == syncFileCredential.Username).OrderBy(s => s.UserId).Select(s => s.Name).FirstOrDefault();
//    //                        var newFileName = syncFileCredential.DbFile.FileName.Split('.')[0] + "_" + Username + '.' + syncFileCredential.DbFile.FileName.Split('.')[1]; // New name for the file
//    //                        var newFilePath = Path.Combine(unsyncfile, newFileName);
//    //                        System.IO.File.Move(sqlitedbPath, newFilePath, true);
//    //                        if (System.IO.File.Exists(sqlitedbPath))
//    //                        {
//    //                            System.IO.File.Delete(sqlitedbPath);
//    //                        }
//    //                    }
//    //                    return json;
//    //                }
//    //            }
//    //            else
//    //            {
//    //                Tuple<bool, string, string> returnTuple = new Tuple<bool, string, string>(false, "Invalid or Unregistered User", version);
//    //                string json = JsonConvert.SerializeObject(returnTuple);
//    //                Console.WriteLine(json);

//    //                json = json.Replace("Item1", "result");
//    //                json = json.Replace("Item2", "message");
//    //                json = json.Replace("Item3", "version");
//    //                return json;
//    //            }
//    //        }
//    //        else
//    //        {
//    //            Tuple<bool, string, string> returnTuple = new Tuple<bool, string, string>(false, "Insufficient Data", version);
//    //            string json = JsonConvert.SerializeObject(returnTuple);
//    //            Console.WriteLine(json);

//    //            json = json.Replace("Item1", "result");
//    //            json = json.Replace("Item2", "message");
//    //            json = json.Replace("Item3", "version");
//    //            return json;
//    //        }
//    //    }

//    //    /*
//    //     * Public Toilet Sync
//    //     */

//    //    // POST: service/Service/PTSync
//    //    [HttpPost("PTSync")]
//    //    public async Task<string> PTPostAsync([FromForm] SyncFileCredential syncFileCredential)
//    //    {
//    //        PublicToiletSync pt = new PublicToiletSync(_hostEnvironment, _wqsContext, _trainingdnContext, _utc);

//    //        if (ModelState.IsValid)
//    //        {
//    //            string sqliteFolder = Path.Combine(_hostEnvironment.WebRootPath, "sqlitedb");
//    //            if (!Directory.Exists(sqliteFolder))
//    //            {
//    //                Directory.CreateDirectory(sqliteFolder);
//    //            }
//    //            string sqlitedbPath = Path.Combine(sqliteFolder, syncFileCredential.DbFile.FileName);

//    //            var checkUser = _wqsContext.Users.OrderBy(S => S.UserId)
//    //                            .FirstOrDefault(s => s.Email == syncFileCredential.Username && s.Status == 1);

//    //            if (checkUser != null)
//    //            {

//    //                Tuple<bool, string> returnTuple = new Tuple<bool, string>(false, "no message");

//    //                using (var fileStream = new FileStream(sqlitedbPath, FileMode.Create))
//    //                {
//    //                    await syncFileCredential.DbFile.CopyToAsync(fileStream);

//    //                    returnTuple = await pt.ReadAndSaveDBPublicToilet(sqlitedbPath, (int)checkUser.TrainingUser, checkUser.Name);
//    //                }

//    //                bool DataSynced = returnTuple.Item1;
//    //                string json = JsonConvert.SerializeObject(returnTuple);
//    //                Console.WriteLine(json);
//    //                json = json.Replace("Item1", "result");
//    //                json = json.Replace("Item2", "message");

//    //                if (DataSynced)
//    //                {
//    //                    string path = Path.Combine(_hostEnvironment.WebRootPath, "sqlitedb", "synceddb", "PublicToiletSynced");

//    //                    string fileName = Path.GetFileName(syncFileCredential.DbFile.FileName);

//    //                    using (FileStream SyncFileUpload = new FileStream(Path.Combine(path, fileName), FileMode.Create))
//    //                    {
//    //                        syncFileCredential.DbFile.CopyTo(SyncFileUpload);

//    //                    }

//    //                    if (System.IO.File.Exists(sqlitedbPath))
//    //                    {
//    //                        System.IO.File.Delete(sqlitedbPath);
//    //                    }
//    //                    return json;
//    //                }
//    //                else
//    //                {
//    //                    if (System.IO.File.Exists(sqlitedbPath))
//    //                    {
//    //                        var unsyncfile = Path.Combine(_hostEnvironment.WebRootPath, "sqlitedb", "unsyncdb", "PublicToilet");
//    //                        var Username = _wqsContext.Users.Where(s => s.Email == syncFileCredential.Username).OrderBy(s => s.UserId).Select(s => s.Name).FirstOrDefault();
//    //                        var newFileName = syncFileCredential.DbFile.FileName.Split('.')[0] + "_" + Username + '.' + syncFileCredential.DbFile.FileName.Split('.')[1]; // New name for the file
//    //                        var newFilePath = Path.Combine(unsyncfile, newFileName);
//    //                        System.IO.File.Move(sqlitedbPath, newFilePath, true);
//    //                        if (System.IO.File.Exists(sqlitedbPath))
//    //                        {
//    //                            System.IO.File.Delete(sqlitedbPath);
//    //                        }
//    //                    }
//    //                    return json;
//    //                }
//    //            }
//    //            else
//    //            {
//    //                Tuple<bool, string> returnTuple = new Tuple<bool, string>(false, "Invalid or Unregistered User");
//    //                string json = JsonConvert.SerializeObject(returnTuple);
//    //                Console.WriteLine(json);

//    //                json = json.Replace("Item1", "result");
//    //                json = json.Replace("Item2", "message");

//    //                return json;
//    //            }
//    //        }
//    //        else
//    //        {
//    //            Tuple<bool, string> returnTuple = new Tuple<bool, string>(false, "Insufficient Data");
//    //            string json = JsonConvert.SerializeObject(returnTuple);
//    //            Console.WriteLine(json);

//    //            json = json.Replace("Item1", "result");
//    //            json = json.Replace("Item2", "message");

//    //            return json;
//    //        }
//    //    }



//    //    /*
//    //     * Health Care Facilities Sync
//    //     */

//    //    // POST: service/Service/HCFSync
//    //    [HttpPost("HCFSync")]
//    //    public async Task<string> HCFPostAsync([FromForm] SyncFileCredential syncFileCredential)
//    //    {
//    //        HCFSync HcfSync = new HCFSync(_hostEnvironment, _wqsContext, _trainingdnContext, _utc);
//    //        var version = _wqsContext.ApkDetails.Where(s => s.AppName == "NWASH Health Care").OrderBy(s => s.Id).Select(s => s.AppVersion).FirstOrDefault();
//    //        if (ModelState.IsValid)
//    //        {
//    //            string sqliteFolder = Path.Combine(_hostEnvironment.WebRootPath, "sqlitedb");
//    //            if (!Directory.Exists(sqliteFolder))
//    //            {
//    //                Directory.CreateDirectory(sqliteFolder);
//    //            }
//    //            string sqlitedbPath = Path.Combine(sqliteFolder, syncFileCredential.DbFile.FileName);

//    //            var checkUser = _wqsContext.Users.OrderBy(S => S.UserId)
//    //                            .FirstOrDefault(s => s.Email == syncFileCredential.Username && s.Status == 1);

//    //            if (checkUser != null)
//    //            {
//    //                Tuple<bool, string, string> returnTuple = new Tuple<bool, string, string>(false, "no message", version);

//    //                using (var fileStream = new FileStream(sqlitedbPath, FileMode.Create))
//    //                {
//    //                    await syncFileCredential.DbFile.CopyToAsync(fileStream);
//    //                }

//    //                returnTuple = await HcfSync.ReadAndSaveDBHCF(sqlitedbPath, (int)checkUser.TrainingUser, checkUser.Name);

//    //                bool DataSynced = returnTuple.Item1;
//    //                string json = JsonConvert.SerializeObject(returnTuple);
//    //                Console.WriteLine(json);
//    //                json = json.Replace("Item1", "result");
//    //                json = json.Replace("Item2", "message");
//    //                json = json.Replace("Item3", "version");

//    //                if (DataSynced)
//    //                {
//    //                    string path = Path.Combine(_hostEnvironment.WebRootPath, "sqlitedb", "synceddb", "HCFSynced");
//    //                    string fileName = Path.GetFileName(syncFileCredential.DbFile.FileName);

//    //                    var destFile = Path.Combine(path, fileName);
//    //                    if (System.IO.File.Exists(destFile)) System.IO.File.Delete(destFile);
//    //                    System.IO.File.Move(sqlitedbPath, destFile);

//    //                    /*  using (FileStream SyncFileUpload = new FileStream(Path.Combine(path, fileName), FileMode.Create))
//    //                      {
//    //                          syncFileCredential.DbFile.CopyTo(SyncFileUpload);
//    //                      }

//    //                      if (System.IO.File.Exists(sqlitedbPath))
//    //                      {
//    //                          System.IO.File.Delete(sqlitedbPath);
//    //                      }*/
//    //                    return json;
//    //                }
//    //                else
//    //                {
//    //                    if (System.IO.File.Exists(sqlitedbPath))
//    //                    {
//    //                        var unsyncfile = Path.Combine(_hostEnvironment.WebRootPath, "sqlitedb", "unsyncdb", "HCF");
//    //                        var Username = _wqsContext.Users.Where(s => s.Email == syncFileCredential.Username).OrderBy(s => s.UserId).Select(s => s.Name).FirstOrDefault();
//    //                        var newFileName = syncFileCredential.DbFile.FileName.Split('.')[0] + "_" + Username + '.' + syncFileCredential.DbFile.FileName.Split('.')[1]; // New name for the file
//    //                        var newFilePath = Path.Combine(unsyncfile, newFileName);
//    //                        System.IO.File.Move(sqlitedbPath, newFilePath, true);
//    //                        if (System.IO.File.Exists(sqlitedbPath))
//    //                        {
//    //                            System.IO.File.Delete(sqlitedbPath);
//    //                        }
//    //                    }
//    //                    return json;
//    //                }
//    //            }
//    //            else
//    //            {
//    //                Tuple<bool, string, string> returnTuple = new Tuple<bool, string, string>(false, "Invalid or Unregistered User", version);
//    //                string json = JsonConvert.SerializeObject(returnTuple);
//    //                Console.WriteLine(json);

//    //                json = json.Replace("Item1", "result");
//    //                json = json.Replace("Item2", "message");
//    //                json = json.Replace("Item3", "version");
//    //                return json;

//    //            }
//    //        }
//    //        else
//    //        {
//    //            Tuple<bool, string, string> returnTuple = new Tuple<bool, string, string>(false, "Insufficient Data", version);
//    //            string json = JsonConvert.SerializeObject(returnTuple);
//    //            Console.WriteLine(json);

//    //            json = json.Replace("Item1", "result");
//    //            json = json.Replace("Item2", "message");
//    //            json = json.Replace("Item3", "version");

//    //            return json;
//    //        }
//    //    }

//    //    /*
//    //     * Community Sanitation Sync
//    //     */

//    //    // POST: service/Service/CSSync
//    //    [HttpPost("CSSync")]
//    //    public async Task<string> CSPostAsync([FromForm] SyncFileCredential syncFileCredential)
//    //    {
//    //        CommunitySanitationSync csSync = new CommunitySanitationSync(_hostEnvironment, _wqsContext, _trainingdnContext, _utc);

//    //        if (ModelState.IsValid)
//    //        {
//    //            string sqliteFolder = Path.Combine(_hostEnvironment.WebRootPath, "sqlitedb");
//    //            if (!Directory.Exists(sqliteFolder))
//    //            {
//    //                Directory.CreateDirectory(sqliteFolder);
//    //            }
//    //            string sqlitedbPath = Path.Combine(sqliteFolder, syncFileCredential.DbFile.FileName);

//    //            var checkUser = _wqsContext.Users.OrderBy(S => S.UserId)
//    //                            .FirstOrDefault(s => s.Email == syncFileCredential.Username && s.Status == 1);

//    //            if (checkUser != null)
//    //            {
//    //                Tuple<bool, string> returnTuple = new Tuple<bool, string>(false, "no message");

//    //                using (var fileStream = new FileStream(sqlitedbPath, FileMode.Create))
//    //                {
//    //                    await syncFileCredential.DbFile.CopyToAsync(fileStream);

//    //                    returnTuple = await csSync.ReadAndSaveDBCS(sqlitedbPath, (int)checkUser.TrainingUser);
//    //                }

//    //                bool DataSynced = returnTuple.Item1;
//    //                string json = JsonConvert.SerializeObject(returnTuple);
//    //                Console.WriteLine(json);
//    //                json = json.Replace("Item1", "result");
//    //                json = json.Replace("Item2", "message");

//    //                if (DataSynced)
//    //                {
//    //                    string path = Path.Combine(_hostEnvironment.WebRootPath, "sqlitedb", "synceddb", "CommunitySanSynced");

//    //                    string fileName = Path.GetFileName(syncFileCredential.DbFile.FileName);

//    //                    using (FileStream SyncFileUpload = new FileStream(Path.Combine(path, fileName), FileMode.Create))
//    //                    {
//    //                        syncFileCredential.DbFile.CopyTo(SyncFileUpload);
//    //                    }
//    //                    if (System.IO.File.Exists(sqlitedbPath))
//    //                    {
//    //                        System.IO.File.Delete(sqlitedbPath);
//    //                    }
//    //                    return json;
//    //                }
//    //                else
//    //                {
//    //                    if (System.IO.File.Exists(sqlitedbPath))
//    //                    {
//    //                        var unsyncfile = Path.Combine(_hostEnvironment.WebRootPath, "sqlitedb", "unsyncdb", "ComSan");
//    //                        var Username = _wqsContext.Users.Where(s => s.Email == syncFileCredential.Username).OrderBy(s => s.UserId).Select(s => s.Name).FirstOrDefault();
//    //                        var newFileName = syncFileCredential.DbFile.FileName.Split('.')[0] + "_" + Username + '.' + syncFileCredential.DbFile.FileName.Split('.')[1]; // New name for the file
//    //                        var newFilePath = Path.Combine(unsyncfile, newFileName);
//    //                        System.IO.File.Move(sqlitedbPath, newFilePath, true);
//    //                        if (System.IO.File.Exists(sqlitedbPath))
//    //                        {
//    //                            System.IO.File.Delete(sqlitedbPath);
//    //                        }
//    //                    }
//    //                    return json;
//    //                }
//    //            }
//    //            else
//    //            {
//    //                Tuple<bool, string> returnTuple = new Tuple<bool, string>(false, "Invalid or Unregistered User");
//    //                string json = JsonConvert.SerializeObject(returnTuple);
//    //                Console.WriteLine(json);
//    //                json = json.Replace("Item1", "result");
//    //                json = json.Replace("Item2", "message");
//    //                return json;
//    //            }
//    //        }
//    //        else
//    //        {
//    //            Tuple<bool, string> returnTuple = new Tuple<bool, string>(false, "Insufficient Data");
//    //            string json = JsonConvert.SerializeObject(returnTuple);
//    //            Console.WriteLine(json);

//    //            json = json.Replace("Item1", "result");
//    //            json = json.Replace("Item2", "message");

//    //            return json;
//    //        }
//    //    }


//    //    /*
//    //     * Unserved Community Sync
//    //     */

//    //    // POST: service/Service/UnservedSync
//    //    [HttpPost("UnservedSync")]
//    //    public async Task<string> UnservedPostAsync([FromForm] SyncFileCredential syncFileCredential)
//    //    {
//    //        var version = _wqsContext.ApkDetails.Where(s => s.AppName == "NWASH Unserved").OrderBy(s => s.Id).Select(s => s.AppVersion).FirstOrDefault();
//    //        UnservedPopulationSync csSync = new UnservedPopulationSync(_hostEnvironment, _wqsContext, _trainingdnContext, _utc);

//    //        if (ModelState.IsValid)
//    //        {
//    //            try
//    //            {
//    //                string sqliteFolder = Path.Combine(_hostEnvironment.WebRootPath, "sqlitedb");
//    //                if (!Directory.Exists(sqliteFolder))
//    //                {
//    //                    Directory.CreateDirectory(sqliteFolder);
//    //                }
//    //                string sqlitedbPath = Path.Combine(sqliteFolder, syncFileCredential.DbFile.FileName);

//    //                var checkUser = _wqsContext.Users.OrderBy(S => S.UserId)
//    //                                .FirstOrDefault(s => s.Email == syncFileCredential.Username && s.Status == 1);

//    //                if (checkUser != null)
//    //                {
//    //                    Tuple<bool, string, string> returnTuple = new Tuple<bool, string, string>(false, "no message", version);

//    //                    using (var fileStream = new FileStream(sqlitedbPath, FileMode.Create))
//    //                    {
//    //                        await syncFileCredential.DbFile.CopyToAsync(fileStream);

//    //                        returnTuple = await csSync.ReadAndSaveDBUnserved(sqlitedbPath, (int)checkUser.TrainingUser);
//    //                    }

//    //                    bool DataSynced = returnTuple.Item1;
//    //                    string json = JsonConvert.SerializeObject(returnTuple);
//    //                    Console.WriteLine(json);
//    //                    json = json.Replace("Item1", "result");
//    //                    json = json.Replace("Item2", "message");
//    //                    json = json.Replace("Item3", "version");

//    //                    if (DataSynced)
//    //                    {
//    //                        string path = Path.Combine(_hostEnvironment.WebRootPath, "sqlitedb", "synceddb", "UnservedSynced");

//    //                        string fileName = Path.GetFileName(syncFileCredential.DbFile.FileName);

//    //                        using (FileStream SyncFileUpload = new FileStream(Path.Combine(path, fileName), FileMode.Create))
//    //                        {
//    //                            syncFileCredential.DbFile.CopyTo(SyncFileUpload);
//    //                        }

//    //                        if (System.IO.File.Exists(sqlitedbPath))
//    //                        {
//    //                            System.IO.File.Delete(sqlitedbPath);
//    //                        }
//    //                        return json;
//    //                    }
//    //                    else
//    //                    {
//    //                        if (System.IO.File.Exists(sqlitedbPath))
//    //                        {
//    //                            var unsyncfile = Path.Combine(_hostEnvironment.WebRootPath, "sqlitedb", "unsyncdb", "Unserved");
//    //                            var Username = _wqsContext.Users.Where(s => s.Email == syncFileCredential.Username).OrderBy(s => s.UserId).Select(s => s.Name).FirstOrDefault();
//    //                            var newFileName = syncFileCredential.DbFile.FileName.Split('.')[0] + "_" + Username + '.' + syncFileCredential.DbFile.FileName.Split('.')[1]; // New name for the file
//    //                            var newFilePath = Path.Combine(unsyncfile, newFileName);
//    //                            System.IO.File.Move(sqlitedbPath, newFilePath, true);
//    //                            if (System.IO.File.Exists(sqlitedbPath))
//    //                            {
//    //                                System.IO.File.Delete(sqlitedbPath);
//    //                            }
//    //                        }
//    //                        return json;
//    //                    }
//    //                }
//    //                else
//    //                {
//    //                    Tuple<bool, string, string> returnTuple = new Tuple<bool, string, string>(false, "Invalid or Unregistered User", version);
//    //                    string json = JsonConvert.SerializeObject(returnTuple);
//    //                    Console.WriteLine(json);

//    //                    json = json.Replace("Item1", "result");
//    //                    json = json.Replace("Item2", "message");
//    //                    json = json.Replace("Item3", "version");
//    //                    return json;
//    //                }
//    //            }
//    //            catch (Exception ex)
//    //            {
//    //                Tuple<bool, string, string> returnTuple = new Tuple<bool, string, string>(false, ex.Message, version);
//    //                string json = JsonConvert.SerializeObject(returnTuple);
//    //                Console.WriteLine(json);

//    //                json = json.Replace("Item1", "result");
//    //                json = json.Replace("Item2", "message");
//    //                json = json.Replace("Item3", "version");
//    //                return json;
//    //            }
//    //        }
//    //        else
//    //        {
//    //            Tuple<bool, string, string> returnTuple = new Tuple<bool, string, string>(false, "Insufficient Data", version);
//    //            string json = JsonConvert.SerializeObject(returnTuple);
//    //            Console.WriteLine(json);

//    //            json = json.Replace("Item1", "result");
//    //            json = json.Replace("Item2", "message");
//    //            json = json.Replace("Item3", "version");
//    //            return json;
//    //        }

//    //    }

//    //    // POST: service/Service/UrbanSanitationSync
//    //    [HttpPost("UrbanSanitationSync")]
//    //    public async Task<string> UrbanSanitationSync([FromForm] SyncFileCredential syncFileCredential)
//    //    {
//    //        UrbanSanSync csSync = new UrbanSanSync(_hostEnvironment, _wqsContext, _trainingdnContext, _utc);

//    //        if (ModelState.IsValid)
//    //        {
//    //            string sqliteFolder = Path.Combine(_hostEnvironment.WebRootPath, "sqlitedb");
//    //            if (!Directory.Exists(sqliteFolder))
//    //            {
//    //                Directory.CreateDirectory(sqliteFolder);
//    //            }
//    //            string sqlitedbPath = Path.Combine(sqliteFolder, syncFileCredential.DbFile.FileName);

//    //            var checkUser = _wqsContext.Users.OrderBy(S => S.UserId)
//    //                            .FirstOrDefault(s => s.Email == syncFileCredential.Username && s.Status == 1);

//    //            if (checkUser != null)
//    //            {
//    //                Tuple<bool, string> returnTuple = new Tuple<bool, string>(false, "no message");

//    //                using (var fileStream = new FileStream(sqlitedbPath, FileMode.Create))
//    //                {
//    //                    await syncFileCredential.DbFile.CopyToAsync(fileStream);

//    //                    returnTuple = await csSync.ReadAndSaveDBUrbanSan(sqlitedbPath, (int)checkUser.TrainingUser);
//    //                }

//    //                bool DataSynced = returnTuple.Item1;
//    //                string json = JsonConvert.SerializeObject(returnTuple);
//    //                Console.WriteLine(json);
//    //                json = json.Replace("Item1", "result");
//    //                json = json.Replace("Item2", "message");

//    //                if (DataSynced)
//    //                {
//    //                    string path = Path.Combine(_hostEnvironment.WebRootPath, "sqlitedb", "synceddb", "UrbanSanSynced");

//    //                    string fileName = Path.GetFileName(syncFileCredential.DbFile.FileName);

//    //                    using (FileStream SyncFileUpload = new FileStream(Path.Combine(path, fileName), FileMode.Create))
//    //                    {
//    //                        syncFileCredential.DbFile.CopyTo(SyncFileUpload);
//    //                    }
//    //                    if (System.IO.File.Exists(sqlitedbPath))
//    //                    {
//    //                        System.IO.File.Delete(sqlitedbPath);
//    //                    }
//    //                    return json;
//    //                }
//    //                else
//    //                {

//    //                    if (System.IO.File.Exists(sqlitedbPath))
//    //                    {
//    //                        var unsyncfile = Path.Combine(_hostEnvironment.WebRootPath, "sqlitedb", "unsyncdb", "UrbanSan");
//    //                        var Username = _wqsContext.Users.Where(s => s.Email == syncFileCredential.Username).OrderBy(s => s.UserId).Select(s => s.Name).FirstOrDefault();
//    //                        var newFileName = syncFileCredential.DbFile.FileName.Split('.')[0] + "_" + Username + '.' + syncFileCredential.DbFile.FileName.Split('.')[1]; // New name for the file
//    //                        var newFilePath = Path.Combine(unsyncfile, newFileName);
//    //                        System.IO.File.Move(sqlitedbPath, newFilePath, true);
//    //                        if (System.IO.File.Exists(sqlitedbPath))
//    //                        {
//    //                            System.IO.File.Delete(sqlitedbPath);
//    //                        }
//    //                    }
//    //                    return json;
//    //                }
//    //            }
//    //            else
//    //            {
//    //                Tuple<bool, string> returnTuple = new Tuple<bool, string>(false, "Invalid or Unregistered User");
//    //                string json = JsonConvert.SerializeObject(returnTuple);
//    //                Console.WriteLine(json);

//    //                json = json.Replace("Item1", "result");
//    //                json = json.Replace("Item2", "message");

//    //                return json;
//    //            }
//    //        }
//    //        else
//    //        {
//    //            Tuple<bool, string> returnTuple = new Tuple<bool, string>(false, "Insufficient Data");
//    //            string json = JsonConvert.SerializeObject(returnTuple);
//    //            Console.WriteLine(json);

//    //            json = json.Replace("Item1", "result");
//    //            json = json.Replace("Item2", "message");

//    //            return json;
//    //        }
//    //    }

//    //    /*
//	   //* SWM godawari Sync
//	   //*/

//    //    // POST: service/Service/SWMSync
//    //    [HttpPost("SWMSync")]
//    //    public async Task<string> SWMPostAsync([FromForm] SyncFileCredential syncFileCredential)
//    //    {
//    //        SolidwasteMngSync sSync = new SolidwasteMngSync(_hostEnvironment, _wqsContext, _trainingdnContext, _utc);

//    //        if (ModelState.IsValid)
//    //        {
//    //            string sqliteFolder = Path.Combine(_hostEnvironment.WebRootPath, "sqlitedb");
//    //            if (!Directory.Exists(sqliteFolder))
//    //            {
//    //                Directory.CreateDirectory(sqliteFolder);
//    //            }
//    //            string sqlitedbPath = Path.Combine(sqliteFolder, syncFileCredential.DbFile.FileName);

//    //            var checkUser = _wqsContext.Users.OrderBy(S => S.UserId)
//    //                            .FirstOrDefault(s => s.Email == syncFileCredential.Username && s.Status == 1);

//    //            if (checkUser != null)
//    //            {
//    //                Tuple<bool, string> returnTuple = new Tuple<bool, string>(false, "no message");

//    //                using (var fileStream = new FileStream(sqlitedbPath, FileMode.Create))
//    //                {
//    //                    await syncFileCredential.DbFile.CopyToAsync(fileStream);

//    //                    returnTuple = await sSync.ReadAndSaveDBSWM(sqlitedbPath, (int)checkUser.TrainingUser, checkUser.Name);
//    //                }

//    //                bool DataSynced = returnTuple.Item1;
//    //                string json = JsonConvert.SerializeObject(returnTuple);
//    //                Console.WriteLine(json);
//    //                json = json.Replace("Item1", "result");
//    //                json = json.Replace("Item2", "message");

//    //                if (DataSynced)
//    //                {
//    //                    string path = Path.Combine(_hostEnvironment.WebRootPath, "sqlitedb", "synceddb", "SWM");

//    //                    string fileName = Path.GetFileName(syncFileCredential.DbFile.FileName);

//    //                    using (FileStream SyncFileUpload = new FileStream(Path.Combine(path, fileName), FileMode.Create))
//    //                    {
//    //                        syncFileCredential.DbFile.CopyTo(SyncFileUpload);
//    //                    }

//    //                    if (System.IO.File.Exists(sqlitedbPath))
//    //                    {
//    //                        System.IO.File.Delete(sqlitedbPath);
//    //                    }
//    //                    return json;
//    //                }
//    //                else
//    //                {
//    //                    if (System.IO.File.Exists(sqlitedbPath))
//    //                    {
//    //                        var unsyncfile = Path.Combine(_hostEnvironment.WebRootPath, "sqlitedb", "unsyncdb", "SWM");
//    //                        var Username = _wqsContext.Users.Where(s => s.Email == syncFileCredential.Username).OrderBy(s => s.UserId).Select(s => s.Name).FirstOrDefault();
//    //                        var newFileName = syncFileCredential.DbFile.FileName.Split('.')[0] + "_" + Username + '.' + syncFileCredential.DbFile.FileName.Split('.')[1]; // New name for the file
//    //                        var newFilePath = Path.Combine(unsyncfile, newFileName);
//    //                        System.IO.File.Move(sqlitedbPath, newFilePath, true);
//    //                        if (System.IO.File.Exists(sqlitedbPath))
//    //                        {
//    //                            System.IO.File.Delete(sqlitedbPath);
//    //                        }
//    //                    }
//    //                    return json;
//    //                }
//    //            }
//    //            else
//    //            {
//    //                Tuple<bool, string> returnTuple = new Tuple<bool, string>(false, "Invalid or Unregistered User");
//    //                string json = JsonConvert.SerializeObject(returnTuple);
//    //                Console.WriteLine(json);

//    //                json = json.Replace("Item1", "result");
//    //                json = json.Replace("Item2", "message");

//    //                return json;
//    //            }
//    //        }
//    //        else
//    //        {
//    //            Tuple<bool, string> returnTuple = new Tuple<bool, string>(false, "Insufficient Data");
//    //            string json = JsonConvert.SerializeObject(returnTuple);
//    //            Console.WriteLine(json);

//    //            json = json.Replace("Item1", "result");
//    //            json = json.Replace("Item2", "message");

//    //            return json;
//    //        }
//    //    }


//    //    /*
//    //     * Sources Sync
//    //     */

//    //    // POST: service/Service/SourcesSync
//    //    [HttpPost("SourcesSync")]
//    //    public async Task<string> SourcesPostAsync([FromForm] SyncFileCredential syncFileCredential)
//    //    {
//    //        SourcesSync SSync = new SourcesSync(_hostEnvironment, _wqsContext, _utc);

//    //        if (ModelState.IsValid)
//    //        {
//    //            string sqliteFolder = Path.Combine(_hostEnvironment.WebRootPath, "sqlitedb");
//    //            if (!Directory.Exists(sqliteFolder))
//    //            {
//    //                Directory.CreateDirectory(sqliteFolder);
//    //            }
//    //            string sqlitedbPath = Path.Combine(sqliteFolder, syncFileCredential.DbFile.FileName);

//    //            var checkUser = _wqsContext.Users.OrderBy(S => S.UserId)
//    //                            .FirstOrDefault(s => s.Email == syncFileCredential.Username && s.Status == 1);

//    //            if (checkUser != null)
//    //            {
//    //                Tuple<bool, string> returnTuple = new Tuple<bool, string>(false, "no message");

//    //                using (var fileStream = new FileStream(sqlitedbPath, FileMode.Create))
//    //                {
//    //                    await syncFileCredential.DbFile.CopyToAsync(fileStream);
//    //                }

//    //                returnTuple = await SSync.ReadAndSaveDBSource(sqlitedbPath, checkUser.Name);

//    //                bool DataSynced = returnTuple.Item1;
//    //                string json = JsonConvert.SerializeObject(returnTuple);
//    //                Console.WriteLine(json);
//    //                json = json.Replace("Item1", "result");
//    //                json = json.Replace("Item2", "message");

//    //                if (DataSynced)
//    //                {
//    //                    string path = Path.Combine(_hostEnvironment.WebRootPath, "sqlitedb", "synceddb", "SourcesSynced");
//    //                    string fileName = Path.GetFileName(syncFileCredential.DbFile.FileName);

//    //                    var destFile = Path.Combine(path, fileName);
//    //                    if (System.IO.File.Exists(destFile)) System.IO.File.Delete(destFile);
//    //                    System.IO.File.Move(sqlitedbPath, destFile);

//    //                    /*  using (FileStream SyncFileUpload = new FileStream(Path.Combine(path, fileName), FileMode.Create))
//    //                      {
//    //                          syncFileCredential.DbFile.CopyTo(SyncFileUpload);
//    //                      }

//    //                      if (System.IO.File.Exists(sqlitedbPath))
//    //                      {
//    //                          System.IO.File.Delete(sqlitedbPath);
//    //                      }*/
//    //                    return json;
//    //                }
//    //                else
//    //                {
//    //                    if (System.IO.File.Exists(sqlitedbPath))
//    //                    {
//    //                        var unsyncfile = Path.Combine(_hostEnvironment.WebRootPath, "sqlitedb", "unsyncdb", "Sources");
//    //                        var Username = _wqsContext.Users.Where(s => s.Email == syncFileCredential.Username).OrderBy(s => s.UserId).Select(s => s.Name).FirstOrDefault();
//    //                        var newFileName = syncFileCredential.DbFile.FileName.Split('.')[0] + "_" + Username + '.' + syncFileCredential.DbFile.FileName.Split('.')[1]; // New name for the file
//    //                        var newFilePath = Path.Combine(unsyncfile, newFileName);
//    //                        System.IO.File.Move(sqlitedbPath, newFilePath, true);
//    //                        if (System.IO.File.Exists(sqlitedbPath))
//    //                        {
//    //                            System.IO.File.Delete(sqlitedbPath);
//    //                        }
//    //                    }
//    //                    return json;
//    //                }
//    //            }
//    //            else
//    //            {
//    //                Tuple<bool, string> returnTuple = new Tuple<bool, string>(false, "Invalid or Unregistered User");
//    //                string json = JsonConvert.SerializeObject(returnTuple);
//    //                Console.WriteLine(json);

//    //                json = json.Replace("Item1", "result");
//    //                json = json.Replace("Item2", "message");

//    //                return json;

//    //            }
//    //        }
//    //        else
//    //        {
//    //            Tuple<bool, string> returnTuple = new Tuple<bool, string>(false, "Insufficient Data");
//    //            string json = JsonConvert.SerializeObject(returnTuple);
//    //            Console.WriteLine(json);

//    //            json = json.Replace("Item1", "result");
//    //            json = json.Replace("Item2", "message");
//    //            return json;
//    //        }
//    //    }

//    //    /*
//	   //* Waste Private Sync
//	   //*/

//    //    // POST: service/Service/SWMSync
//    //    [HttpPost("WastePrivateSync")]
//    //    public async Task<string> WastePrivatePostAsync([FromForm] SyncFileCredential syncFileCredential)
//    //    {
//    //        WasteMngPrivateSync sSync = new WasteMngPrivateSync(_hostEnvironment, _wqsContext, _trainingdnContext, _utc);

//    //        if (ModelState.IsValid)
//    //        {
//    //            string sqliteFolder = Path.Combine(_hostEnvironment.WebRootPath, "sqlitedb");
//    //            if (!Directory.Exists(sqliteFolder))
//    //            {
//    //                Directory.CreateDirectory(sqliteFolder);
//    //            }
//    //            string sqlitedbPath = Path.Combine(sqliteFolder, syncFileCredential.DbFile.FileName);

//    //            var checkUser = _wqsContext.Users.OrderBy(S => S.UserId)
//    //                            .FirstOrDefault(s => s.Email == syncFileCredential.Username && s.Status == 1);

//    //            if (checkUser != null)
//    //            {
//    //                Tuple<bool, string> returnTuple = new Tuple<bool, string>(false, "no message");

//    //                using (var fileStream = new FileStream(sqlitedbPath, FileMode.Create))
//    //                {
//    //                    await syncFileCredential.DbFile.CopyToAsync(fileStream);

//    //                    returnTuple = await sSync.ReadAndSaveDBWastePrivate(sqlitedbPath, (int)checkUser.TrainingUser, checkUser.Name);
//    //                }

//    //                bool DataSynced = returnTuple.Item1;
//    //                string json = JsonConvert.SerializeObject(returnTuple);
//    //                Console.WriteLine(json);
//    //                json = json.Replace("Item1", "result");
//    //                json = json.Replace("Item2", "message");

//    //                if (DataSynced)
//    //                {
//    //                    string path = Path.Combine(_hostEnvironment.WebRootPath, "sqlitedb", "synceddb", "WastePrivate");

//    //                    string fileName = Path.GetFileName(syncFileCredential.DbFile.FileName);

//    //                    using (FileStream SyncFileUpload = new FileStream(Path.Combine(path, fileName), FileMode.Create))
//    //                    {
//    //                        syncFileCredential.DbFile.CopyTo(SyncFileUpload);
//    //                    }

//    //                    if (System.IO.File.Exists(sqlitedbPath))
//    //                    {
//    //                        System.IO.File.Delete(sqlitedbPath);
//    //                    }
//    //                    return json;
//    //                }

//    //                else
//    //                {
//    //                    if (System.IO.File.Exists(sqlitedbPath))
//    //                    {
//    //                        var unsyncfile = Path.Combine(_hostEnvironment.WebRootPath, "sqlitedb", "unsyncdb", "WastePrivate");
//    //                        var Username = _wqsContext.Users.Where(s => s.Email == syncFileCredential.Username).OrderBy(s => s.UserId).Select(s => s.Name).FirstOrDefault();
//    //                        var newFileName = syncFileCredential.DbFile.FileName.Split('.')[0] + "_" + Username + '.' + syncFileCredential.DbFile.FileName.Split('.')[1]; // New name for the file
//    //                        var newFilePath = Path.Combine(unsyncfile, newFileName);
//    //                        System.IO.File.Move(sqlitedbPath, newFilePath, true);
//    //                        if (System.IO.File.Exists(sqlitedbPath))
//    //                        {
//    //                            System.IO.File.Delete(sqlitedbPath);
//    //                        }
//    //                    }
//    //                    return json;
//    //                }
//    //            }
//    //            else
//    //            {
//    //                Tuple<bool, string> returnTuple = new Tuple<bool, string>(false, "Invalid or Unregistered User");
//    //                string json = JsonConvert.SerializeObject(returnTuple);
//    //                Console.WriteLine(json);

//    //                json = json.Replace("Item1", "result");
//    //                json = json.Replace("Item2", "message");

//    //                return json;
//    //            }
//    //        }
//    //        else
//    //        {
//    //            Tuple<bool, string> returnTuple = new Tuple<bool, string>(false, "Insufficient Data");
//    //            string json = JsonConvert.SerializeObject(returnTuple);
//    //            Console.WriteLine(json);

//    //            json = json.Replace("Item1", "result");
//    //            json = json.Replace("Item2", "message");

//    //            return json;
//    //        }
//    //    }




//    //    // PUT: api/Service/5
//    //    [HttpPut("{id}")]
//    //    public void Put(int id, [FromBody] string value)
//    //    {
//    //    }

//    //    // DELETE: api/ApiWithActions/5
//    //    [HttpDelete("{id}")]
//    //    public void Delete(int id)
//    //    {

//    //    }


//    //  
//    //}
//}
