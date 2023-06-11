using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MS_UI.Services;

namespace MS_UI.Controllers
{
    public class CampusController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

    }
}
