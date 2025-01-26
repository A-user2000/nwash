using DocumentFormat.OpenXml.Spreadsheet;
using Microsoft.AspNetCore.Mvc;
using Wq_Surveillance.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Wq_Surveillance.Models.QueryTables;

namespace Wq_Surveillance.Service.Users
{
    public interface IUserService
    {
        public List<UserList> GetUsers();
        public UserList GetSelectedUser(int UserId);
        public User AddUsers(User users);
        public User UpdateUser(User users);
        public List<UserList2> InactiveUsers();
        public bool CheckExistingPassword(int UserID, string Password);
        public bool ChangeUserPassword(int UserID, string NewPassword);
        public int DeactivateUser(int UserID);
        public int ActivateUser(int UserID);
        public int SetActualUser(int UserID);
        public List<UserList> GetAllUsers();
        public List<District> GetAllDistricts();
        public List<Organization> GetAllOrganizations();
        public List<UserList2> GetLabUsers();
        public List<UserList1> GetWashUsers();
        public List<UserList2> ActiveUsers();



    }
}
