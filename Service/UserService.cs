using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Wq_Surveillance.Models;
using Wq_Surveillance.Service;

namespace Nwash.Service
{
    public class UserService : IUserService
    {
        private readonly WqsContext _wqsContext;
        private readonly IHttpContextAccessor _sessionData;
        private string bUrl = "";
        public UserService(WqsContext wqsContext, IHttpContextAccessor contextAccessor)
        {
            _wqsContext = wqsContext;
            _sessionData = contextAccessor;
            bUrl = (contextAccessor.HttpContext.Request.Host).ToString();
            //if (bUrl.Host.Contains("training-frmasm"))
        }

        public User AddUsers(User users)
        {
            int TUser = 0;
            if (bUrl.Contains("training"))
            {
                TUser = 1;
            }
            var SName = _sessionData.HttpContext.Session.GetString("SName");
            var password = users.Password;
            var encryptedPassword = HashPassword(password);
            users.Password = encryptedPassword;

            DateTime date = DateTime.Now; // will give the date for today
            users.CreatedDate = DateOnly.FromDateTime(date);
            var userType = users.UserType;

            var group = 3;

            switch (userType)
            {
                case "Admin":
                    group = 1;
                    users.District = 0;
                    users.Municipality = 0;
                    users.Province = "0";
                    break;
                case "District Admin": //not in use right now
                    group = 2;
                    users.Municipality = 0;
                    break;
                case "District Edit": //not in use right now
                    group = 0;
                    users.Municipality = 0;
                    break;
                case "Municipality Admin":
                    group = 5;
                    break;
                case "Municipality Edit":
                    group = 6;
                    break;
                case "ReadOnly":
                    group = 3;
                    break;
                case "Province Admin":
                    group = 7;
                    users.District = 0;
                    users.Municipality = 0;
                    break;
                case "Province Edit":
                    group = 8;
                    users.District = 0;
                    users.Municipality = 0;
                    break;
            }

            users.Groups = group;
            users.Status = 1;
            users.CreatedBy = SName;
            users.TrainingUser = TUser;
            var basetime = new DateTime(1970, 1, 1);

            users.LastLogin = DateTime.Now.Subtract(basetime).TotalSeconds;

            if (users.UserCategory == 1)
            {
                users.AssignedArea = null;
            }
            else
            {
                users.Groups = 3;
                users.UserType = "ReadOnly";
            }
            _wqsContext.Add(users);
            _wqsContext.SaveChanges();

            return users;
        }

        public User UpdateUser(User users)
        {
            var existingUserData = _wqsContext.Users
                                    .Where(s => (s.UserId == users.UserId))
                                    .FirstOrDefault();

            if (existingUserData != null)
            {
                var userType = users.UserType;

                var group = 3;

                if (userType == "Admin")
                {
                    group = 1;
                    users.Municipality = 0;
                    users.Province = "0";
                    users.District = 0;
                }
                else if (userType == "District Admin")
                {
                    group = 2;
                    users.Municipality = 0;
                }
                else if (userType == "District Edit")
                {
                    group = 0;
                    users.Municipality = 0;
                }
                else if (userType == "Municipality Admin")
                {
                    group = 5;
                }
                else if (userType == "Municipality Edit")
                {
                    group = 6;
                }
                else if (userType == "ReadOnly")
                {
                    group = 3;
                }
                else if (userType == "Province Admin")
                {
                    group = 7;
                    users.Municipality = 0;
                    users.District = 0;
                }
                else if (userType == "Province Edit")
                {
                    group = 8;
                    users.Municipality = 0;
                    users.District = 0;
                }

                if (users.Password != null)
                {
                    existingUserData.Password = HashPassword(users.Password);
                }

                existingUserData.Groups = group;
                existingUserData.Name = users.Name;
                existingUserData.Email = users.Email;
                existingUserData.InvAgency = users.InvAgency;
                existingUserData.District = users.District;
                existingUserData.Municipality = users.Municipality;
                existingUserData.UserType = userType;
                existingUserData.Province = users.Province;
                _wqsContext.Update(existingUserData);
                _wqsContext.SaveChanges();
                return existingUserData;
            }
            else
            {
                return new User();
            }
        }

        public bool CheckExistingPassword(int sUID, string Password)
        {
            var UserData = _wqsContext.Users
                            .Where(s => (s.UserId == sUID))
                            .FirstOrDefault();

            var checkPwdHash = HashPassword(Password);

            if (checkPwdHash == UserData.Password)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool ChangeUserPassword(int sUID, string NewPassword)
        {
            var HashNewPassword = HashPassword(NewPassword);

            var UserData = _wqsContext.Users
                            .Where(s => (s.UserId == sUID))
                            .FirstOrDefault();

            UserData.Password = HashNewPassword;
            var result = _wqsContext.SaveChanges();

            if (result == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
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

        public List<UserList> GetUsers()
        {
            var sGrp = _sessionData.HttpContext.Session.GetInt32("SGroups");
            var sInv = _sessionData.HttpContext.Session.GetString("SInv");
            var sProvince = _sessionData.HttpContext.Session.GetString("SProvince");
            var sDistrict = _sessionData.HttpContext.Session.GetInt32("SDistrict");
            var sMun = _sessionData.HttpContext.Session.GetInt32("SMunicipality");

            var where = "";
            if (sGrp == 1)
            {
                where = " where status = 1 ";
            }
            else if (sGrp == 7)
            {
                where = " where u.groups <> 1 and u.province = '" + sProvince + "' and u.inv_agency = '" + sInv + "' and status = 1";
            }
            else if (sGrp == 2)
            {
                where = " where u.groups <> 1 and u.district = '" + sDistrict + "' and u.inv_agency = '" + sInv + "' and status = 1";
            }
            else if (sGrp == 5)
            {
                where = " where u.groups <> 1 and u.municipality = '" + sMun + "' and u.inv_agency = '" + sInv + "' and status = 1";
            }

            var query = @"select u.*,d.district_name,m.mun_name,
                            CASE WHEN last_login is null THEN '-'
		                        ELSE (to_timestamp(u.last_login)::date)::text
		                        END AS last_login_date
                            from system.users u
                            left join system.district d on d.district_code::int = u.district
                            left join system.municipality m on m.mun_code::int = u.municipality" +
                            where
                            + " order by u.user_id desc";

            var UserListVal = _wqsContext.UserLists
                               .FromSqlRaw(query).AsNoTracking()
                               .ToList();

            if (UserListVal == null)
            {
                return new List<UserList>();
            }

            return UserListVal;
        }

        public List<UserList1> GetWashUsers()
        {
            var sGrp = _sessionData.HttpContext.Session.GetInt32("SGroups");
            var sInv = _sessionData.HttpContext.Session.GetString("SInv");
            var sProvince = _sessionData.HttpContext.Session.GetString("SProvince");
            var sDistrict = _sessionData.HttpContext.Session.GetInt32("SDistrict");
            var sMun = _sessionData.HttpContext.Session.GetInt32("SMunicipality");

            var where = "";
            if (sGrp == 1)
            {
                where = " where user_category = 1 ";
            }
            else if (sGrp == 7)
            {
                where = " where u.groups <> 1 and u.province = '" + sProvince + "' and u.inv_agency = '" + sInv + "' and user_category = 1 ";
            }
            else if (sGrp == 2)
            {
                where = " where u.groups <> 1 and u.district = '" + sDistrict + "' and u.inv_agency = '" + sInv + "' and user_category = 1 ";
            }
            else if (sGrp == 5)
            {
                where = " where u.groups <> 1 and u.municipality = '" + sMun + "' and u.inv_agency = '" + sInv + "' and user_category = 1 ";
            }

            var query = @"select u.*,d.district_name,m.mun_name,
                            CASE WHEN last_login is null THEN '-'
		                        ELSE (to_timestamp(u.last_login)::date)::text
		                        END AS last_login_date
                            from system.users u
                            left join system.district d on d.district_code::int = u.district
                            left join system.municipality m on m.mun_code::int = u.municipality" +
                            where
                            + " order by u.user_id desc";

            var UserListVal = _wqsContext.UserLists1
                               .FromSqlRaw(query)
                               .ToList();

            if (UserListVal == null)
            {
                return new List<UserList1>();
            }

            return UserListVal;
        }

        public List<UserList2> InactiveUsers()
        {
            var query = @"select u.*,d.district_name,m.mun_name,
                            CASE WHEN last_login is null THEN '-'
		                        ELSE (to_timestamp(u.last_login)::date)::text
		                        END AS last_login_date
                            from system.users u
                            left join system.district d on d.district_code::int = u.district
                            left join system.municipality m on m.mun_code::int = u.municipality where status = 0 order by u.user_id desc";

            var UserListVal = _wqsContext.UserLists2
                               .FromSqlRaw(query)
                               .ToList();
            return UserListVal;
        }

        public List<UserList2> GetLabUsers()
        {
            var sGrp = _sessionData.HttpContext.Session.GetInt32("SGroups");
            var sInv = _sessionData.HttpContext.Session.GetString("SInv");
            var sProvince = _sessionData.HttpContext.Session.GetString("SProvince");
            var sDistrict = _sessionData.HttpContext.Session.GetInt32("SDistrict");
            var sMun = _sessionData.HttpContext.Session.GetInt32("SMunicipality");

            var where = "";
            if (sGrp == 1)
            {
                where = " where user_category = 2 ";
            }
            else if (sGrp == 7)
            {
                where = " where u.groups <> 1 and u.province = '" + sProvince + "' and u.inv_agency = '" + sInv + "' and user_category = 2 ";
            }
            else if (sGrp == 2)
            {
                where = " where u.groups <> 1 and u.district = '" + sDistrict + "' and u.inv_agency = '" + sInv + "' and user_category = 2 ";
            }
            else if (sGrp == 5)
            {
                where = " where u.groups <> 1 and u.municipality = '" + sMun + "' and u.inv_agency = '" + sInv + "' and user_category = 2 ";
            }

            var query = @"select u.*,d.district_name,m.mun_name,
                            CASE WHEN last_login is null THEN '-'
		                        ELSE (to_timestamp(u.last_login)::date)::text
		                        END AS last_login_date
                            from system.users u
                            left join system.district d on d.district_code::int = u.district
                            left join system.municipality m on m.mun_code::int = u.municipality" +
                            where + " order by u.user_id desc";

            var UserListVal = _wqsContext.UserLists2
                               .FromSqlRaw(query)
                               .ToList();

            if (UserListVal == null)
            {
                return new List<UserList2>();
            }

            return UserListVal;
        }

        public UserList GetSelectedUser(int UserId)
        {
            var query = @"select u.*,d.district_name,m.mun_name,
                            CASE WHEN last_login is null THEN '-'
		                        ELSE (to_timestamp(u.last_login)::date)::text
		                        END AS last_login_date
                            from system.users u
                            left join system.district d on d.district_code::int = u.district
                            left join system.municipality m on m.mun_code::int = u.municipality
                            where u.user_id = " + UserId;

            var UserListVal = _wqsContext.UserLists
                               .FromSqlRaw(query).OrderBy(s => s.district)
                               .FirstOrDefault();

            return UserListVal;
        }
        public int DeactivateUser(int UserID)
        {
            var userData = _wqsContext.Users
                            .Where(s => (s.UserId == UserID))
                            .FirstOrDefault();

            userData.Status = 0;
            var result = _wqsContext.SaveChanges();

            return result;
        }
        public int ActivateUser(int UserID)
        {
            var userData = _wqsContext.Users
                            .Where(s => (s.UserId == UserID))
                            .FirstOrDefault();

            userData.Status = 1;
            var result = _wqsContext.SaveChanges();

            return result;

        }
        public int SetActualUser(int UserID)
        {
            var userData = _wqsContext.Users
                            .Where(s => (s.UserId == UserID))
                            .FirstOrDefault();

            userData.TrainingUser = 0;
            var result = _wqsContext.SaveChanges();

            return result;
        }

        public List<User> GetAllUsers()
        {
            return _wqsContext.Users.ToList();
        }

        public List<District> GetAllDistricts()
        {
            return _wqsContext.Districts.ToList();
        }

        public List<Organization> GetAllOrganizations()
        {
            return _wqsContext.Organizations.ToList();
        }
    }
}
