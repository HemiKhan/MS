using Microsoft.AspNetCore.Mvc;

namespace MS_UI.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Dashboard()
        {
            //if (HttpContext.Session.GetString("Token") == null)
            //{
            //    return Redirect("/User/login");
            //}
            //ViewBag.Name = HttpContext.Session.GetString("FirstName") + ' ' + HttpContext.Session.GetString("LastName");
            return View();
        }
    }
}
