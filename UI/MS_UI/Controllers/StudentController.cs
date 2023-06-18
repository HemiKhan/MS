using Microsoft.AspNetCore.Mvc;
using MS_UI.Models.AdmissionModels;

namespace MS_UI.Controllers
{
    public class StudentController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Admission(AdmissionViewModel model)
        {
            return View();
        }
    }
}
