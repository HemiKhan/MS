using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Skote.Controllers
{
    public class AuthController : Controller
    {

        public ActionResult Index()
        {
            return View("auth-login");
        }

        [ActionName("auth-login")]
        public ActionResult authlogin()
        {
            return View();
        }
        [ActionName("auth-register")]
        public ActionResult authregister()
        {
            return View();
        }
        [ActionName("auth-recoverpw")]
        public ActionResult authrecoverpw()
        {
            return View();
        }
        [ActionName("auth-lock-screen")]
        public ActionResult authlockscreen()
        {
            return View();
        }
        
        

        [HttpPost]
        public ActionResult ValidateLogin(string email, string password)
        {
            //You can fetch email and password from db or API here.
            string dbEmail = "Test";
            string dbPassword = "123";
            bool IsValidUser = false;

            if (email == dbEmail && password == dbPassword)
                IsValidUser = true;

            return Json(new
            {
                IsValidUser = IsValidUser
            });
        }
    }
}