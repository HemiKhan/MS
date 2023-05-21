using Microsoft.AspNetCore.Mvc;

namespace MS_UI.Controllers
{
    public class SessionController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
