using Microsoft.AspNetCore.Mvc;

namespace MS_UI.Controllers
{
    public class CampusController : Controller
    {
        public IActionResult index()
        {
            return View();
        }

    }
}
