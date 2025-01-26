using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DocumentFormat.OpenXml.Spreadsheet;
using DocumentFormat.OpenXml.Wordprocessing;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Wq_Surveillance.Models;
using Wq_Surveillance.Models.QueryTables;
using Wq_Surveillance.Service.Project;
using Wq_Surveillance.Service.Users;
using Wq_Surveillance.Service.Project;

namespace Wq_Surveillance.Controllers
{
    public class UsersController : Controller
    {
        private ILogger _logger;
        private IUserService _service;
        private IProjectService _pservice;
        private readonly WqsContext _wqsContext;
        // private readonly training_dnContext _wqsContext;
        private readonly IHttpContextAccessor _sessionData;
        private string _sUID;

        public UsersController(ILogger<UsersController> logger, IUserService service, IProjectService pservice, IHttpContextAccessor contextAccessor, WqsContext wqsContext)
        {
            _logger = logger;
            _service = service;
            _pservice = pservice;

            _wqsContext = wqsContext;
            _sessionData = contextAccessor;

            _sUID = _sessionData.HttpContext.Session.GetString("SUserID");
        }

        // GET: Users
        //[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        //public ActionResult Index()
        //{
        //    if (_sUID == null) // Check if the user is not logged in
        //    {
        //        return RedirectToAction("Index", "Login", new { area = "" });
        //    }
        //    else
        //    {
        //        var sGrp = 1; // Hardcoded for testing
        //        if (sGrp == 1)
        //        {
        //            // Fetch the list of users from the service
        //            var userList = _service.GetAllUsers(); // Returns List<UserList>

        //            // Fetch additional data for ViewBag
        //            ViewBag.LabUsers = _service.GetLabUsers(); // Ensure this returns data
        //            ViewBag.WASHUsers = _service.GetWashUsers(); // Ensure this returns data
        //            ViewBag.InactiveUsers = _service.InactiveUsers(); // Ensure this returns data

        //            // Debugging: Log the counts of each list
        //            Console.WriteLine($"All Users: {userList?.Count}");
        //            Console.WriteLine($"Lab Users: {ViewBag.LabUsers?.Count}");
        //            Console.WriteLine($"WASH Users: {ViewBag.WASHUsers?.Count}");
        //            Console.WriteLine($"Inactive Users: {ViewBag.InactiveUsers?.Count}");

        //            // Pass the userList as the model to the view
        //            return View(userList);
        //        }
        //        else
        //        {
        //            return RedirectToAction("Index", "Dashboard", new { area = "" });
        //        }
        //    }
        //}
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public ActionResult Index()
        {
            if (_sUID == null) // Check if the user is not logged in
            {
                return RedirectToAction("Index", "Login", new { area = "" });
            }
            else
            {
                var sGrp = 1; // Hardcoded for testing
                if (sGrp == 1)
                {
                    // Fetch the list of users from the service
                    var userList = _service.GetAllUsers();

                    // Fetch additional data for ViewBag
                    ViewBag.ActiveUsers = _service.ActiveUsers();
                    ViewBag.LabUsers = _service.GetLabUsers();
                    ViewBag.WASHUsers = _service.GetWashUsers();
                    ViewBag.InactiveUsers = _service.InactiveUsers();

                    // Pass the userList as the model to the view
                    return View(userList);
                }
                else
                {
                    return RedirectToAction("Index", "Dashboard", new { area = "" });
                }
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public ActionResult Details(int id)
        {
            if (_sUID != null)
            //if (_sUID == null)
            {
                return RedirectToAction("Index", "Login", new { area = "" });
            }
            else
            {
                var sGrp = _sessionData.HttpContext.Session.GetInt32("SGroups");
                if (sGrp == 1 || sGrp == 2 || sGrp == 5 || sGrp == 7)
                {
                    var AllUserList = _service.GetSelectedUser(id);
                    return View(AllUserList);
                }
                else
                {
                    return RedirectToAction("Index", "Dashboard", new { area = "" });
                }
            }
        }

        // GET: Users/Create
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public ActionResult Create()
        {
            if (_sUID != null)
            //if (_sUID == null)
            {
                return RedirectToAction("Index", "Login", new { area = "" });
            }
            else
            {
                var district = (_sessionData.HttpContext.Session.GetInt32("SDistrict")).ToString();
                var municipality = (_sessionData.HttpContext.Session.GetInt32("SMunicipality")).ToString();
                var sGrp = _sessionData.HttpContext.Session.GetInt32("SGroups");
                var SInv = _sessionData.HttpContext.Session.GetString("SInv");
                var SUser = Convert.ToInt32(_sessionData.HttpContext.Session.GetInt32("SUserID"));
                //  var SName = _sessionData.HttpContext.Session.GetString("SName");
                var userdetail = _wqsContext.Users.Where(s => s.UserId == SUser).OrderBy(s => s.UserId).FirstOrDefault();
                if (sGrp == 1 || sGrp == 2 || sGrp == 5 || sGrp == 7)
                {
                    var province = _wqsContext.Districts
                                    .Where(s => (s.DistrictCode == district))
                                    .Select(s => s.ProvinceCode).SingleOrDefault();

                    var provinceName = _wqsContext.Provinces
                                       .Where(s => (s.ProvinceCode == province))
                                       .Select(s => s.ProvinceName).SingleOrDefault();

                    var districtName = _wqsContext.Districts
                                        .Where(s => (s.DistrictCode == district))
                                        .Select(s => s.DistrictName).SingleOrDefault();

                    var municipalityName = _wqsContext.Municipalities
                                            .Where(s => (s.MunCode == municipality))
                                            .Select(s => s.MunName).SingleOrDefault();

                    ViewData["UserProvinceCode"] = "";
                    ViewData["UserDistrictCode"] = "";
                    ViewData["UserMunicipalityCode"] = "";

                    ViewData["UserProvince"] = "";
                    ViewData["UserDistrict"] = "";
                    ViewData["UserMunicipality"] = "";

                    ViewData["NextPcode"] = "";

                    if (sGrp == 7)
                    {
                        province = userdetail.Province;
                        provinceName = _wqsContext.Provinces
                                    .Where(s => (s.ProvinceCode == province))
                                    .Select(s => s.ProvinceName).SingleOrDefault();
                        ViewData["UserProvince"] = provinceName;
                        ViewData["UserProvinceCode"] = province;
                        SInv = userdetail.InvAgency;
                    }
                    else if (sGrp == 2 || sGrp == 5)
                    {
                        ViewData["UserProvince"] = provinceName;
                        ViewData["UserDistrict"] = districtName;
                        ViewData["UserProvinceCode"] = province;
                        ViewData["UserDistrictCode"] = district;

                        if (sGrp == 5)
                        {
                            ViewData["UserMunicipality"] = municipalityName;
                            ViewData["UserMunicipalityCode"] = municipality;
                        }
                    }
                    ViewData["UserAgency"] = SInv;
                    ViewData["ProvinceList"] = _pservice.GetProvince();
                    ViewData["DistrictList"] = _pservice.GetSelDistricts(province);
                    ViewData["MunicipalityList"] = _pservice.GetSelMunicipality(district);
                    ViewData["AgencyList"] = _pservice.GetInventoryAgency();

                    return View();
                }
                else
                {
                    return RedirectToAction("Index", "Dashboard", new { area = "" });
                }
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public ActionResult Create(User users, string generatePassword)
        {
            //if (ModelState.IsValid)
            //{
            /**to check if selected value exists or not**/
            var UserTypeList = _wqsContext.Users.Select(s => s.UserType).Distinct();
            var UserCatList = _wqsContext.Users.Select(s => s.UserCategory).Distinct();
            var AgencyList = _wqsContext.Organizations.Select(s => s.OrgName).Distinct();

            var checkExistingUser = _wqsContext.Users
                                    .Where(s => (s.Email == users.Email)).OrderBy(S => S.UserId)
                                    .FirstOrDefault();

            if (checkExistingUser == null)
            {
                if (UserTypeList.Contains(users.UserType) && UserCatList.Contains(users.UserCategory) && (AgencyList.Contains(users.InvAgency) || users.InvAgency == "ALL"))
                {
                    if (users.Password == null)
                    {
                        //string category;
                        //switch(users.UserCategory)
                        //{
                        //    case 1:
                        //        category = "wa";
                        //        break;
                        //    case 2:
                        //        category = "la";
                        //        break;
                        //    case 3:
                        //        category = "ws";
                        //        break;
                        //    default:
                        //        category = "";
                        //        break;
                        //}
                        //string pw = users.Name.Split(' ')[0].ToLower() + "#$" + category;
                        users.Password = generatePassword;
                    }
                    if (users.UserType == "Province Admin" || users.UserType == "Province Edit")
                    {
                        users.District = 0;
                        users.Municipality = 0;
                    }
                    var addUsers = _service.AddUsers(users);
                    if (addUsers != null)
                    {
                        TempData["SuccessMessage"] = "User Registered Successfully";
                        return RedirectToAction(nameof(Create));
                    }
                    else
                    {
                        TempData["ErrorMessage"] = "Something Went Wrong. Please try again later.";
                        return RedirectToAction(nameof(Create));
                    }
                }
                else
                {
                    TempData["ErrorMessage"] = "Select Valid User Type, User Category and Inventory Agency.";
                    return RedirectToAction(nameof(Create));
                }
            }
            else
            {
                TempData["ErrorMessage"] = "Email already Exist. Please update the email id to add user.";
                return RedirectToAction(nameof(Create));
            }
        }

        // GET: Details/5
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public ActionResult Edit(int id)
        {
            if (_sUID != null)
            //if (_sUID == null)
            {
                return RedirectToAction("Index", "Login", new { area = "" });
            }
            else
            {
                var district = (_sessionData.HttpContext.Session.GetInt32("SDistrict")).ToString();
                var municipality = (_sessionData.HttpContext.Session.GetInt32("SMunicipality")).ToString();
                var sGrp = _sessionData.HttpContext.Session.GetInt32("SGroups");
                var SInv = _sessionData.HttpContext.Session.GetString("SInv");

                if (sGrp == 1 || sGrp == 2 || sGrp == 5 || sGrp == 7)
                {
                    var AllUserList = _service.GetSelectedUser(id);

                    var EditUserProvince = _wqsContext.Districts
                                    .Where(s => (s.DistrictCode == (AllUserList.district).ToString()))
                                    .Select(s => s.ProvinceCode).SingleOrDefault();

                    var province = _wqsContext.Districts
                                    .Where(s => (s.DistrictCode == district))
                                    .Select(s => s.ProvinceCode).SingleOrDefault();

                    var provinceName = _wqsContext.Provinces
                                       .Where(s => (s.ProvinceCode == province))
                                       .Select(s => s.ProvinceName).SingleOrDefault();

                    var districtName = _wqsContext.Districts
                                        .Where(s => (s.DistrictCode == district))
                                        .Select(s => s.DistrictName).SingleOrDefault();

                    var municipalityName = _wqsContext.Municipalities
                                            .Where(s => (s.MunCode == municipality))
                                            .Select(s => s.MunName).SingleOrDefault();

                    ViewData["UserProvinceCode"] = "";
                    ViewData["UserDistrictCode"] = "";
                    ViewData["UserMunicipalityCode"] = "";

                    ViewData["UserProvince"] = "";
                    ViewData["UserDistrict"] = "";
                    ViewData["UserMunicipality"] = "";
                    ViewData["UserAgency"] = SInv;
                    ViewData["NextPcode"] = "";
                    ViewData["EditUserProvince"] = EditUserProvince;

                    if (sGrp == 2 || sGrp == 5 || sGrp == 7)
                    {
                        ViewData["UserProvince"] = provinceName;
                        ViewData["UserDistrict"] = districtName;
                        ViewData["UserProvinceCode"] = province;
                        ViewData["UserDistrictCode"] = district;

                        if (sGrp == 5)
                        {
                            ViewData["UserMunicipality"] = municipalityName;
                            ViewData["UserMunicipalityCode"] = municipality;
                        }
                    }
                    ViewData["ProvinceList"] = _pservice.GetProvince();
                    ViewData["DistrictList"] = _pservice.GetSelDistricts(EditUserProvince);
                    ViewData["MunicipalityList"] = _pservice.GetSelMunicipality((AllUserList.district).ToString());
                    ViewData["AgencyList"] = _pservice.GetInventoryAgency();

                    return View(AllUserList);
                }
                else
                {
                    return RedirectToAction("Index", "Dashboard", new { area = "" });
                }
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public ActionResult Edit(User users)
        {
            var updateUsers = _service.UpdateUser(users);
            if (updateUsers != null)
            {
                TempData["SuccessMessage"] = "User Updated Successfully";
                return RedirectToAction("Edit", "Users", new { @id = users.UserId });
            }
            else
            {
                TempData["ErrorMessage"] = "Something Went Wrong. Please try again later.";
                return RedirectToAction("Edit", "Users", new { @id = users.UserId });
            }
        }

        [HttpPost]
        public int DeleteUsers(int userID)
        {
            var userDel = _service.DeactivateUser(userID);
            return userDel;

        }
        [HttpPost]
        public int ActivateUsers(int userID)
        {
            var userActivate = _service.ActivateUser(userID);
            return userActivate;

        }

        [HttpPost]
        public int SetActualUser(int userId)
        {
            var userActivate = _service.SetActualUser(userId);
            return userActivate;
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public ActionResult ChangePassword()
        {
            if (_sUID == null)
            {
                return RedirectToAction("Index", "Login", new { area = "" });
            }
            else
            {
                return View();
            }

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ChangePassword(string Password, string NewPassword, string CNewPassword)
        {
            if (_sUID == null)
            {
                return RedirectToAction("Index", "Login", new { area = "" });
            }
            else
            {
                var UserID = _sessionData.HttpContext.Session.GetInt32("SUserID");
                var checkExistingPassword = _service.CheckExistingPassword((int)UserID, Password);

                if (checkExistingPassword == true)
                {
                    if (Password == NewPassword)
                    {
                        TempData["ErrorMessage"] = "New password matches the existing password. Please enter new password and try again";
                        return RedirectToAction(nameof(ChangePassword));
                    }
                    else if (NewPassword != CNewPassword)
                    {
                        TempData["ErrorMessage"] = "Confirm password does not match new password.";
                        return RedirectToAction(nameof(ChangePassword));

                    }
                    else if (NewPassword == CNewPassword)
                    {
                        var cngPassword = _service.ChangeUserPassword((int)UserID, NewPassword);

                        if (cngPassword == true)
                        {
                            TempData["SuccessMessage"] = "Password Updated Successfully";
                            return RedirectToAction(nameof(ChangePassword));
                        }
                        else
                        {
                            TempData["ErrorMessage"] = "Something went wrong. Please try again later.";
                            return RedirectToAction(nameof(ChangePassword));
                        }
                    }
                    else
                    {
                        TempData["ErrorMessage"] = "Something went wrong. Please try again later.";
                        return RedirectToAction(nameof(ChangePassword));
                    }
                }
                else
                {
                    TempData["ErrorMessage"] = "Current password does not match with the existing password.";
                    return RedirectToAction(nameof(ChangePassword));
                }
            }
        }

        [HttpPost]
        public JsonResult GetLabListForUsers(string munCode)
        {
           
            var dict = _wqsContext.LabRegistration
                        .Select(s => new { s.Uuid, s.LabName })
                        .OrderBy(item => item.LabName);
            return Json(dict);
       

        }
        [HttpPost]
        public JsonResult GetProjectListforWSUC(string munCode)
        {
            var dict = _wqsContext.ProjectDetails
                       .Where(s => (s.MunicipalityCode == munCode))
                       .Where(s => (s.TheGeom != null))      // checking for empty geometry.
                       .Select(s => new { s.ProCode, s.ProName, s.Uuid })
                       .OrderBy(item => item.ProCode);
            return Json(dict);
        }
    }
}
