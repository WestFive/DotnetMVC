using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcTest.Models;
using MvcTest.ViewModels;
using MvcTest.Data_Access_Laye;

namespace MvcTest.Controllers
{
    [Authorize]//需要授权
    public class EmployeeController : Controller
    {
        // GET: Test
        [Authorize]//需要授权
        public ActionResult Index()
        {
            EmployeeListViewModel employeeListViewModel = new EmployeeListViewModel();

            EmployeeBusinessLayer empBal = new EmployeeBusinessLayer();
            List<Employee> employees = empBal.GetEmployees();

            List<EmployeeViewModel> empViewModels = new List<EmployeeViewModel>();

            foreach (Employee emp in employees)
            {
                EmployeeViewModel empViewModel = new EmployeeViewModel();
                empViewModel.EmployeeName = emp.FirstName + " " + emp.LastName;
                empViewModel.Salary = emp.Salary.ToString("C");
                if (emp.Salary > 15000)
                {
                    empViewModel.SalaryColor = "yellow";
                }
                else
                {
                    empViewModel.SalaryColor = "green";
                }
                empViewModels.Add(empViewModel);
            }
            employeeListViewModel.Employees = empViewModels;
            // employeeListViewModel.userName = "Admin";

            employeeListViewModel.FooterData = new FooterViewModel();
            employeeListViewModel.FooterData.CompanyName = "WestFive@CN";//Can be set to dynamic value
            employeeListViewModel.FooterData.Year = DateTime.Now.Year.ToString();

            return View("Index", employeeListViewModel);
        }

        public ActionResult AddNew()
        {
            return View();
        }
        public ActionResult SaveEmployee(Employee e)
        {
            SalesERPDAL dd = new SalesERPDAL();
            dd.Employees.Add(e);
            dd.SaveChanges();

            return Index();

        }

        public ActionResult GetAddNewLink()
        {
            if(Convert.ToBoolean(Session["IsAdmin"]))
            {
                return PartialView("AddNewLink");
            }
            else
            {
                return new EmptyResult();
            }
        }
    }
}