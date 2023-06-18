using Microsoft.AspNetCore.Mvc;
using MS_UI.Models.AdmissionModels;
using Microsoft.AspNetCore.Mvc.Rendering;
using MS_Models.Model;
using MS_UI.Services;



namespace MS_UI.Controllers
{
    public class StudentController : Controller
    {
        private readonly CommonService commonService;
        public StudentController()
        {
            commonService = new CommonService();
        }


        public async Task<IActionResult> Index()
        {
            var campus = await commonService.GetCampus();
            if (campus.list is not null)
            {
                campus.list.Insert(0, new Campus { Id = 0, CampusName = "Select Campus" });
                ViewBag.Campus = new SelectList(campus.list, "Id", "CampusName");
            }

            var session = await commonService.GetSession();
            if (session.list is not null)
            {
                session.list.Insert(0, new Session { Id = 0, SessionName = "Select Session" });
                ViewBag.Session = new SelectList(session.list, "Id", "SessionName");
            }

            var section = await commonService.GetSection();
            if (section.list is not null)
            {
                section.list.Insert(0, new Section { Id = 0, SectionName = "Select Section" });
                ViewBag.Section = new SelectList(section.list, "Id", "SectionName");
            }

            var classes = await commonService.GetClass();
            if (classes.list is not null)
            {
                classes.list.Insert(0, new Class { Id = 0, ClassName = "Select Class" });
                ViewBag.Class = new SelectList(classes.list, "Id", "ClassName");
            }

            return View();
        }
        public IActionResult Admission(AdmissionViewModel model)
        {
            return View();
        }
    }
}
