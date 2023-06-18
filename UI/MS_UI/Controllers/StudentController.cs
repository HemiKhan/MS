using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MS_Models.Model;
using MS_UI.Services;
using MS_Models.ViewModel;
using Newtonsoft.Json;
using System.Net.Http.Headers;

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

        [HttpPost]
        public async Task<IActionResult> Admission(AdmissionViewModel model)
        {
            AdmissionViewModel admission = new AdmissionViewModel();
            admission.StudentName = model.StudentName;
            admission.StudentCode = model.StudentCode;
            admission.IsActive = model.IsActive;

            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = Constrant.AppUrl;
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                //POST Method
                HttpResponseMessage response = await client.PostAsJsonAsync("Admission/Admission", admission);
                if (response.IsSuccessStatusCode)
                {
                    var Data = await response.Content.ReadAsStringAsync();
                    var res = JsonConvert.DeserializeObject<Response<AdmissionViewModel>>(Data);
                    if (!res.Status)
                    {
                        TempData["ErrorMessage"] = res.Message;
                        return Redirect($"/Student/Index");
                    }
                    TempData["SuccessMessage"] = res.Message;
                    return Redirect($"/Student/Index");
                }
                else
                {
                    return Redirect($"/Student/Index");
                }
            }
        }
    }
}
