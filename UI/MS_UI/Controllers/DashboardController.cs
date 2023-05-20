using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Skote.Controllers
{
    public class DashboardController : Controller
    {
        // GET: Dashboard
        public ActionResult Index()
        {
            //string strName = Contants.LAYOUT_VERTICAL;
            //string strWelcomeText = "Dashboard";

            //if (TempData["ModeName"] != null)
            //    strName = TempData["ModeName"].ToString();

            //if (TempData["WelcomeText"] != null)
            //    strWelcomeText = TempData["WelcomeText"].ToString();

            //ViewBag.ModeName = strName;
            //ViewBag.WelcomeText = strWelcomeText;
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

        [ActionName("dashboard-saas")]
        public ActionResult dashboardsaas()
        {
            return View();
        }

        [ActionName("dashboard-crypto")]
        public ActionResult dashboardcrypto()
        {
            return View();
        }


    }
}