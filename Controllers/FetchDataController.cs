using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Wq_Surveillance.Models;
using Wq_Surveillance.Models.API;
using Newtonsoft.Json;
using Wq_Surveillance.NwashModels;


namespace Nwash.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class FetchDataController : ControllerBase
    {
        private readonly WqsContext _wqsContext;
        private readonly NwashContext  _nwashContext;
        private static IWebHostEnvironment _hostEnvironment;
        private readonly IHttpContextAccessor _sessionData;
        public FetchDataController(WqsContext wqsContext, IWebHostEnvironment hostEnvironment, IHttpContextAccessor contextAccessor, NwashContext nwashContext)
        {
            _wqsContext = wqsContext;
            _nwashContext = nwashContext;
            _hostEnvironment = hostEnvironment;
            _sessionData = contextAccessor;
        }

        // GET: api/Service
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Service/5
        [HttpGet("{id}", Name = "GetUser")]
        public string Get(int id)
        {
            return "value";
        }

        /*
         * Login
         */

        // POST: api/fetchData/CheckUser
        [HttpPost("CheckUser")]
        public string CheckUser([FromForm] Login loginData)
        {
            var username = (loginData.Email).Trim();
            var userPass = loginData.Password;

            var getPwd = _wqsContext.Users
                           .Where(s => (s.Email == username))
                           .Where(s => (s.Status == 1))
                           .Select(s => new { s.Password, s.Municipality, s.InvAgency })
                           .SingleOrDefault();


            Tuple<bool, string, string, string, string> returnTuple = new Tuple<bool, string, string, string, string>(false, "no message", "0", "0", "0");

            if (getPwd != null)
            {
                var userID = _wqsContext.Users
                           .Where(s => (s.Email == username))
                           .Select(s => s.UserId)
                           .SingleOrDefault().ToString();

                var hashedPwd = HashPassword(userPass);

                if (hashedPwd == getPwd.Password)
                {
                    /*
                     * save login data
                     */

                    DbConnection connection = _wqsContext.Database.GetDbConnection();
                    DbProviderFactory dbFactory = DbProviderFactories.GetFactory(connection);
                    connection.Open();
                    var query = "update system.users set last_login=extract(epoch from now()) where user_id=" + userID;

                    using (var cmd = dbFactory.CreateCommand())
                    {
                        cmd.Connection = connection;
                        cmd.CommandType = CommandType.Text;
                        cmd.CommandText = query;
                        cmd.ExecuteNonQuery();
                    }
                    connection.Close();

                    returnTuple = new Tuple<bool, string, string, string, string>(true, "Login Successful", userID, getPwd.Municipality.ToString(), getPwd.InvAgency.ToString());
                }
                else
                {
                    returnTuple = new Tuple<bool, string, string, string, string>(false, "Incorrect Password", "0", getPwd.Municipality.ToString(), getPwd.InvAgency.ToString());
                }
            }
            else
            {
                returnTuple = new Tuple<bool, string, string, string, string>(false, "Invalid or Unregistered User", "0", "0", "0");

            }
            string json = JsonConvert.SerializeObject(returnTuple);
            Console.WriteLine(json);

            json = json.Replace("Item1", "result");
            json = json.Replace("Item2", "message");
            json = json.Replace("Item3", "UserID");
            json = json.Replace("Item4", "MunCode");
            json = json.Replace("Item5", "InvAgency");

            return json;
        }

        //Cost estimation --->> to get excel for cost estimation total cost and the pop (only for developer use)
       
        private string HashPassword(string password)
        {
            HashAlgorithm MD5 = new MD5CryptoServiceProvider();
            byte[] bs = Encoding.UTF8.GetBytes(password);
            bs = MD5.ComputeHash(bs);
            StringBuilder s = new StringBuilder();
            foreach (byte b in bs)
                s.Append(b.ToString("x2").ToLower());
            string hash = s.ToString();
            return hash;
        }

        /*
         * Sync Data
         */
        // POST: api/fetchData/SyncData
        [HttpPost("SyncData")]

        public string SyncData([FromForm] CheckUser UserData)
        {
            var Email = (UserData.Email).Trim();

            var checkUser = _wqsContext.Users
                          .Where(s => (s.Email == Email))
                          .Where(s => (s.Status == 1))
                          .SingleOrDefault();

            if (checkUser != null)
            {
                if (checkUser.Groups == 5 || checkUser.Groups == 6)
                {
                    var province = _wqsContext.Provinces.Where(s => s.ProvinceCode == checkUser.Province).OrderBy(item => item.ProvinceCode).ToList();
                    var district = _wqsContext.Districts.Where(s => s.DistrictCode == checkUser.District.ToString()).OrderBy(item => item.DistrictCode).ToList();
                    var municipality = _wqsContext.Municipalities.Where(s => s.MunCode == checkUser.Municipality.ToString()).OrderBy(item => item.MunCode).ToList();
                    // var agency = checkUser.InvAgency;
                    var agency = _wqsContext.Organizations.Where(s => s.OrgName == checkUser.InvAgency).OrderBy(item => item.OrgName).ToList();

                    Tuple<bool, List<Wq_Surveillance.Models.Province>, List<Wq_Surveillance.Models.District>, List<Wq_Surveillance.Models.Municipality>, List<Wq_Surveillance.Models.Organization>> returnTuple =
         new Tuple<bool, List<Wq_Surveillance.Models.Province>, List<Wq_Surveillance.Models.District>, List<Wq_Surveillance.Models.Municipality>, List<Wq_Surveillance.Models.Organization>>(
             true, province, district, municipality, agency);
                    string json = JsonConvert.SerializeObject(returnTuple);
                    Console.WriteLine(json);

                    json = json.Replace("Item1", "result");
                    json = json.Replace("Item2", "Province");
                    json = json.Replace("Item3", "District");
                    json = json.Replace("Item4", "Municipality");
                    json = json.Replace("Item5", "Agency");
                    return json;
                }
                else
                {
                    var province = _wqsContext.Provinces.OrderBy(item => item.ProvinceCode).ToList();
                    var district = _wqsContext.Districts.OrderBy(item => item.DistrictCode).ToList();
                    var municipality = _wqsContext.Municipalities.OrderBy(item => item.MunCode).ToList();
                    var agency = _wqsContext.Organizations.OrderBy(item => item.OrgName).ToList();

                    Tuple<bool, List<Wq_Surveillance.Models.Province>, List<Wq_Surveillance.Models.District>, List<Wq_Surveillance.Models.Municipality>, List<Wq_Surveillance.Models.Organization>> returnTuple =
        new Tuple<bool, List<Wq_Surveillance.Models.Province>, List<Wq_Surveillance.Models.District>, List<Wq_Surveillance.Models.Municipality>, List<Wq_Surveillance.Models.Organization>>(
            true, province, district, municipality, agency);

                    string json = JsonConvert.SerializeObject(returnTuple);
                    Console.WriteLine(json);

                    json = json.Replace("Item1", "result");
                    json = json.Replace("Item2", "Province");
                    json = json.Replace("Item3", "District");
                    json = json.Replace("Item4", "Municipality");
                    json = json.Replace("Item5", "Agency");
                    return json;
                }
            }
            else
            {
                Tuple<bool, string> returnTuple = new Tuple<bool, string>(false, "Invalid or Unregistered User");
                string json = JsonConvert.SerializeObject(returnTuple);
                Console.WriteLine(json);

                json = json.Replace("Item1", "result");
                json = json.Replace("Item2", "message");

                return json;
            }
        }

        /***
         * 
         * Get Project --> sustanibility
         * **/
        [HttpPost("GetProjects")]
        public string GetProjects([FromForm] string MuniCode)
        {
            if (MuniCode == null || MuniCode == "")
            {
                return "{result:0, Msg:Invalid Input}";
            }
            else
            {
                var projectList = _wqsContext.ProjectDetails
                    .Where(s => s.MunicipalityCode == MuniCode && s.ProName.Length != 0)
                    .OrderBy(s => s.ProCode)
                    .Select(s => new { s.Uuid, s.ProCode, s.ProName })
                    .ToList(); // Convert to a List of anonymous objects

                // Serialize the list of projects to JSON
                var projectJson = JsonConvert.SerializeObject(projectList);
                return "{result:1,data:" + projectJson + "}";
            }
        }

        public static string? ReplaceDoubleQuotes(string? input)
        {
            // Check if the string contains double quotes
            if (input == null)
                return null;

            if (input.Contains("\""))
            {
                // Replace all double quotes with single quotes
                return input.Replace("\"", "'");
            }
            else
            {
                // Return the original string if no double quotes are found
                return input;
            }
        }

        [HttpPost("ProjectList")]
        public string ProjectList([FromForm] CheckUser UserData)
        {
            var Email = (UserData.Email).Trim();

            var checkUser = _wqsContext.Users
                       .Where(s => (s.Email == Email))
                       .Where(s => (s.Status == 1))
                       .SingleOrDefault();

            if (checkUser != null)
            {
                if (checkUser.Groups == 1)
                {
                    var projectList = _wqsContext.ProjectDetails
                    .OrderBy(s => s.ProCode)
                    .Select(s => new { s.Uuid, s.ProCode, ProName = ReplaceDoubleQuotes(s.ProName), s.MunicipalityCode })
                    .ToList(); // Convert to a List of anonymous objects


                    //foreach(var item in projectList)
                    //{

                    //}

                    // Serialize the list of projects to JSON and adjust the result format
                    var projectJson = JsonConvert.SerializeObject(new
                    {
                        result = true,  // Changed result to true as a boolean
                        data = projectList
                    });

                    return projectJson;
                }
                else
                {
                    return "{result:0, Msg:Invalid Input}";
                }
            }
            return "{result:0, Msg:Invalid Input}";
        }


        [HttpPost("Source")]
        public string Source([FromForm] CheckUser UserData)
        {
            var Email = (UserData.Email).Trim();

            var checkUser = _wqsContext.Users
                       .Where(s => (s.Email == Email))
                       .Where(s => (s.Status == 1))
                       .SingleOrDefault();

            if (checkUser != null)
            {
                if (checkUser.Groups == 1)
                {
                    var SourceName = _nwashContext.WaterSources
                    .OrderBy(s => s.Uuid)
                    .Select(s => new { s.Uuid, s.ProUuid, SouName = ReplaceDoubleQuotes(s.SouName) })
                    .ToList(); // Convert to a List of anonymous objects

                    // Serialize the list of sources to JSON and modify the result format
                    var SourceJson = JsonConvert.SerializeObject(new
                    {
                        result = true,
                        data = SourceName
                    });

                    return SourceJson;
                }
                else
                {
                    return "{result:0, Msg:Invalid Input}";
                }
            }
            return "{result:0, Msg:Invalid Input}";
        }


        [HttpPost("HH")]
        public string HH([FromForm] CheckUser UserData)
        {
            var Email = (UserData.Email).Trim();

            var checkUser = _wqsContext.Users
                .Where(s => s.Email == Email && s.Status == 1)
                .SingleOrDefault();

            if (checkUser != null)
            {
                if (checkUser.Groups == 1)
                {
                    // Group taps by ProUuid and calculate TotalPop and HhServed
                    var projectData = _nwashContext.Taps
                        .GroupBy(tap => tap.ProUuid)
                        .Select(group => new
                        {
                            ProUuid = group.Key,
                            TotalPop = group.Sum(tap => tap.MalePop + tap.FemalePop),
                            TotalHhServed = group.Sum(tap => tap.HhServerd)
                        })
                        .ToList();

                    // Serialize the grouped data to JSON and modify the result format
                    var serializedData = JsonConvert.SerializeObject(new
                    {
                        result = true,
                        data = projectData
                    });

                    // Return the JSON response
                    return serializedData;
                }
                else
                {
                    return "{result:0, Msg:Invalid Input}";
                }
            }

            return "{result:0, Msg:Invalid Input}";
        }


        [HttpPost("GetVersion")]
        public string GetVersion([FromForm] string ApkName)
        {
            if (ApkName == null || ApkName == "")
            {
                return "{result:0, Msg:Invalid Input}";
            }
            else
            {
                var versionList = _wqsContext.ApkDetails.Where(s => s.ApkPath == ApkName).OrderBy(s => s.Id).Select(s => s.AppVersion).FirstOrDefault().ToString();

                return "{result:1,data:" + "'" + versionList + "'" + "}";
            }
        }

        [HttpPost("GetVersion2")]
        public string GetVersion2([FromForm] string ApkName)
        {
            if (ApkName == null || ApkName == "")
            {
                return "{result:0, Msg:Invalid Input}";
            }
            else
            {
                var versionList = _wqsContext.ApkDetails.Where(s => s.ApkPath == ApkName).OrderBy(s => s.Id).FirstOrDefault();

                string scheme = _sessionData.HttpContext.Request.Scheme;
                string host = _sessionData.HttpContext.Request.Host.Value;
                string siteUrl = $"{scheme}://{host}/Apks/{versionList.ApkPath}";
                Tuple<bool, string, int, string> returnTuple = new Tuple<bool, string, int, string>(true, versionList.AppVersion, versionList.VersionCode, siteUrl);
                string json = JsonConvert.SerializeObject(returnTuple);
                json = json.Replace("Item1", "result");
                json = json.Replace("Item2", "latestVersion");
                json = json.Replace("Item3", "latestVersionCode");
                json = json.Replace("Item4", "url");
                return json;
            }
        }

    }
}