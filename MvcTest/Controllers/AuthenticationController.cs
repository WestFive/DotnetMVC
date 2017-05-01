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
            if (ModelState.IsValid)
            {
                EmployeeBusinessLayer bal = new EmployeeBusinessLayer();
                UserStatus status = bal.IsVaildUser(d);
                bool IsAdmin = false;
                switch (status)
                {
                    case UserStatus.AuthenticatedAdmin:
                        IsAdmin = true;
                        break;
                    case UserStatus.AuthentucatedUser:
                        IsAdmin = false;
                        break;
                    default:
                        ModelState.AddModelError("CredentialError", "用户名或密码错误");
                        break;

                }
                FormsAuthentication.SetAuthCookie(d.UserName, false);
                Session["IsAdmin"] = IsAdmin;
                return RedirectToAction("Index", "Employee");
            }
            else
            {
                return View("Login");
            }
            //if (bal.IsVaildUser(d))
            //{
            //    FormsAuthentication.SetAuthCookie(d.UserName, false);//认证

            //    return RedirectToAction("Index", "Employee");
            //}
            //else
            //{
            //    ModelState.AddModelError("CredentialError", "用户名或密码错误");
            //    return View("Login");
            //}
        }

        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }
    }
}