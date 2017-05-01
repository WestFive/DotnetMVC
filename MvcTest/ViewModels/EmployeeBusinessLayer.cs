using MvcTest.Data_Access_Laye;
using MvcTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcTest.ViewModels
{
    public class EmployeeBusinessLayer
    {
        public List<Employee> GetEmployees()
        {
            SalesERPDAL sales = new SalesERPDAL();


            return sales.Employees.ToList();
        }

        public UserStatus IsVaildUser(UserDetails u)
        {
            if (u.UserName == "Admin" && u.PassWord == "Admin")
            {
                return UserStatus.AuthenticatedAdmin;
            }
            else if (u.UserName == "User" && u.PassWord == "User")
            {
                return UserStatus.AuthentucatedUser;

            }
            else
            {
                return UserStatus.NonAuthenticatedUser;
            }
        }
    }
}