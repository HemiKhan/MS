using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MS_Models.Model;
using MS_UI.Services;
using MS_Models.ViewModel;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using MS_UI.Models.Common;



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
            var base64String = await commonService.GetBase64StringFromImage(model.StudentImageUpload);
            AdmissionViewModel admission = new AdmissionViewModel();

            if (base64String != null)
            {
                admission.StudentImage = base64String;
            }
            admission.StudentName = model.StudentName;
            admission.StudentCode = model.StudentCode;
            admission.Email = model.Email;
            admission.Address = model.Address;
            admission.Religion = model.Religion;
            
            admission.PreviousSchool = model.PreviousSchool;
            admission.FatherName = model.FatherName;
            admission.FatherProfession = model.FatherProfession;
            admission.FatherCnic = model.FatherCnic;
            admission.MotherName = model.MotherName;
            admission.MotherProfession = model.MotherProfession;
            admission.MotherCnic = model.MotherCnic;
            admission.GuardianName = model.GuardianName;
            admission.GuardianProfession = model.GuardianProfession;
            admission.GuardianCnic = model.GuardianCnic;
            admission.GuardianRelation = model.GuardianRelation;
            admission.DOB = model.DOB;
            admission.AdmissionDate = model.AdmissionDate;
            admission.Gender = model.Gender;
            admission.PhoneNumber = model.PhoneNumber;
            admission.ParrentContact = model.ParrentContact;
            admission.HomeAddress = model.HomeAddress;
            admission.ParrentEmail = model.ParrentEmail;
            admission.CampusId = model.CampusId;
            admission.SessionId = model.SessionId;
            admission.SectionId = model.SectionId;
            admission.ClassId = model.ClassId;
            admission.FeeStructureId = model.FeeStructureId;
            admission.IsFeeStructure = model.IsFeeStructure;
            admission.Fee = model.Fee;

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

        [HttpGet]
        public async Task<IActionResult> GetFees(int campusId, int sessionId, int classId, int sectionId)
        {
            try
            {
                try
                {
                    using (HttpClient client = new HttpClient())
                    {
                        client.BaseAddress = Constrant.AppUrl;
                        client.DefaultRequestHeaders.Accept.Clear();
                        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                        //Get Method
                        HttpResponseMessage response = await client.GetAsync("Fee/GetFee?CampusId="+campusId+"&SessionId="+sessionId+"&SectionId="+sectionId+"&ClassId="+classId);
                        if (response.IsSuccessStatusCode)
                        {
                            var responseData = await response.Content.ReadAsStringAsync();
                            var result = JsonConvert.DeserializeObject<Response<GetFeeStructureViewModel>>(responseData);
                            if (!result!.Status)

                                return Json(result);
                            //return (message: result.Message, list: null);
                            return Json(result);

                            //return (message: result.Message, list: result.List!);
                        }
                        else
                        {
                            return Json("sd");
                            //return (message: "Internal server error occurred.", list: null);
                        }
                    }
                    return Json("sd");
                }
                catch (Exception)
                {

                    throw;
                }
            }
            catch (Exception)
            {
                // Handle any exceptions that occur during the process
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal server error occurred.");
            }
        }


    }
}
