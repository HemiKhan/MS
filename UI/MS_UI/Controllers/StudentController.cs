using Microsoft.AspNetCore.Mvc;

namespace MS_UI.Controllers
{
    public class StudentController : Controller
    {
        public IActionResult StudentRegistration()
        {
            return View();
        }
    }
}
