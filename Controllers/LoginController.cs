using Microsoft.AspNetCore.Mvc;
using System.Data.Common;
using System.Data;
using System.Security.Cryptography;
using System.Text;
using Wq_Surveillance.Models;
using Microsoft.EntityFrameworkCore;

namespace Wq_Surveillance.Controllers
{
    public class LoginController : Controller
    {
        private ILogger _logger;
        private readonly WqsContext _wqsContext;

        private readonly ISession session;
        const string SUserID = "";
        const string SName = "";
        const string SEmail = "";
        const string SUserType = "";
        const string SGroups = "";
        const string SInv = "";
        const string SDistrict = "";
        const string SMunicipality = "";
        const string SProvince = "";
        const string SUserCat = "";
        const string SStatus = "";
        public LoginController(ILogger<LoginController> logger, WqsContext dnContext, IHttpContextAccessor HttpContextAccessor)
        {
            _logger = logger;
            _wqsContext = dnContext;
            this.session = HttpContextAccessor.HttpContext.Session;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login([Bind("Email,Password")] Login users)
        {
            if (ModelState.IsValid)
            {
                var checkUser = _wqsContext.Users.SingleOrDefault(x => x.Email == users.Email);
                if (checkUser == null)
                {
                    TempData["ErrorMessage"] = "Email or Password Does not Exist.";
                    return RedirectToAction("Index");
                }
                else
                {
                    var password = users.Password;
                    var encPassword = HashPassword(password);
                    var labUUid = "";

                    if (checkUser.Password == encPassword)
                    {
                        if (checkUser.Status == 1)
                        {
                                if (checkUser.AssignedLab == null)
                                {
                                    labUUid = "";
                                }
                                else
                                {
                                    labUUid = checkUser.AssignedLab;
                                }
                                this.session.SetInt32("SUserID", Convert.ToInt32(checkUser.UserId));
                                this.session.SetString("SName", checkUser.Name);
                                this.session.SetString("SEmail", checkUser.Email);
                                this.session.SetString("SUserType", checkUser.UserType);
                                this.session.SetInt32("SGroups", (int)checkUser.Groups);
                                this.session.SetString("SInv", checkUser.InvAgency);
                                this.session.SetInt32("SDistrict", Convert.ToInt32(checkUser.District));
                                this.session.SetInt32("SMunicipality", Convert.ToInt32(checkUser.Municipality));
                                this.session.SetString("SProvince", checkUser.Province);
                                this.session.SetInt32("SUserCat", Convert.ToInt32(checkUser.UserCategory));
                                this.session.SetInt32("SStatus", Convert.ToInt32(checkUser.Status));
                                this.session.SetInt32("STrainingUser", Convert.ToInt32(checkUser.TrainingUser));
                                this.session.SetString("SLabUuid", labUUid);                                     //LabUUid or Project Id for WSUC User.

                                /*
                                 * save login data
                                 */

                                DbConnection connection = _wqsContext.Database.GetDbConnection();
                                DbProviderFactory dbFactory = DbProviderFactories.GetFactory(connection);
                                connection.Open();
                                var query = "update system.users set last_login=extract(epoch from now()) where user_id=" + checkUser.UserId;

                                using (var cmd = dbFactory.CreateCommand())
                                {
                                    cmd.Connection = connection;
                                    cmd.CommandType = CommandType.Text;
                                    cmd.CommandText = query;
                                    cmd.ExecuteNonQuery();
                                }
                                connection.Close();
                                TempData["SuccessMessage"] = "Login Successful";
                                return RedirectToAction("Index", "WqsDashboard", new { area = "" });                            
                        }
                        else
                        {
                            TempData["ErrorMessage"] = checkUser.Name + " is deactivated. You have no permission to login to the system. Please contact your respective Admin.";
                            return RedirectToAction("Index");
                        }
                    }
                    else
                    {
                        TempData["ErrorMessage"] = "Email or Password is Incorrect.";
                        return RedirectToAction("Index");
                    }
                }
            }
            else
            {
                TempData["ErrorMessage"] = "Something went wrong. Please Try Again";
                return RedirectToAction("Index");
            }
        }

        public ActionResult Logout()
        {
            this.session.Clear();
            return RedirectToAction("Index");
        }

        public ActionResult ChangePassword()
        {
            return View();
        }

        [HttpPost]
        public JsonResult ResetPassword(string email)
        {
            var password = "wqsnwash123";
            var encPassword = HashPassword(password);
            var checkUser = _wqsContext.Users.SingleOrDefault(x => x.Email == email);
            string returnresult;
            var result = 0;
            if (checkUser != null)
            {
                checkUser.Password = encPassword;
                result = _wqsContext.SaveChanges();

                if (result == 1)
                {
                    returnresult = "Changed";
                }
                else
                {
                    returnresult = "Error";
                }
            }
            else
            {
                returnresult = "NoUser";
            }

            return Json(returnresult);
        }


        public string HashPassword(string Password)
        {
            HashAlgorithm MD5 = new MD5CryptoServiceProvider();
            byte[] bs = Encoding.UTF8.GetBytes(Password);
            bs = MD5.ComputeHash(bs);
            StringBuilder s = new StringBuilder();
            foreach (byte b in bs)
                s.Append(b.ToString("x2").ToLower());
            string hash = s.ToString();
            return hash;
        }

        public void AutoInactive(string email)
        {
            var loginUserQ = @$"select * from system.users where email = '{@email}' order by user_id";
            var loginUSer = _wqsContext.Users.FromSqlRaw(loginUserQ).OrderBy(s => s.UserId).FirstOrDefault();
            var todayDate = DateTime.Now.Date;
            System.DateTime dat_Time = new System.DateTime(1970, 1, 1, 0, 0, 0, 0).ToLocalTime();
            var UlastLogin = dat_Time.AddSeconds((double)loginUSer.LastLogin);
            var UlastloginDateOnly = UlastLogin.ToShortDateString();
            var Alluser = _wqsContext.Users.OrderBy(s => s.UserId).ToList();

            if (loginUSer.Email == "dev@mail.com" && UlastloginDateOnly != todayDate.Date.ToString())
            {
                foreach (var item in Alluser)
                {
                    var cuser = _wqsContext.Users.Where(s => s.Email == item.Email).OrderBy(s => s.UserId).FirstOrDefault();
                    if (item.LastLogin != null)
                    {
                        var lastLogin = dat_Time.AddSeconds((double)item.LastLogin);

                        var diffDays = (todayDate - lastLogin).TotalDays;
                        // Console.WriteLine((Convert.ToDateTime(todayDate.ToShortDateString()) - Convert.ToDateTime(UlastloginDateOnly)).TotalDays);
                        if (Convert.ToInt32(diffDays) >= 90)
                        {
                            item.Status = 0;
                            _wqsContext.Update(item);
                            _wqsContext.SaveChanges();
                        }
                    }
                    else
                    {
                        item.Status = 0;
                        _wqsContext.Update(item);
                    }
                }
                _wqsContext.SaveChanges();
            }
        }

    }
}
