using Microsoft.AspNetCore.Mvc;

namespace MS_UI.Controllers
{
    public class SectionController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
