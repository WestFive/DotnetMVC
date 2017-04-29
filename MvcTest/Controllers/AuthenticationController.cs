using MvcTest.Models;
using MvcTest.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MvcTest.Controllers
{
    public class AuthenticationController : Controller
    {
        // GET: Authentication
        public ActionResult Login()
        {
            return View();
        }


        [HttpPost]
        public ActionResult DoLogin(UserDetails d)
        {
            EmployeeBusinessLayer bal = new EmployeeBusinessLayer();
            if (bal.IsVaildUser(d))
            {
                FormsAuthentication.SetAuthCookie(d.UserName, false);//认证
                
                return RedirectToAction("Index", "Employee");
            }
            else
            {
                ModelState.AddModelError("CredentialError", "用户名或密码错误");
                return View("Login");
            }
        }

        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }
    }
}