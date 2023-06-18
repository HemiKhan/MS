using Microsoft.AspNetCore.Mvc;
using MS_Models.ViewModel;
using MS_UI.Models.Common;
using MS_UI.Services;
using Newtonsoft.Json;
using System.Net.Http.Headers;

namespace MS_UI.Controllers
{
    public class SectionController : Controller
    {
        private readonly CommonService commonService;
        public SectionController()
        {
            commonService = new CommonService();
        }
        public async Task<IActionResult> Index()
        {
            var section = await commonService.GetSection();
            if (section.list is not null)
                return View(section.list);
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddOrUpdateSection(SectionViewModel model)
        {
            SectionViewModel sec = new SectionViewModel();
            sec.SectionId = model.SectionId;
            sec.SectionName = model.SectionName;
            sec.IsActive = model.IsActive;

            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = Constrant.AppUrl;
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                //POST Method
                HttpResponseMessage response = await client.PostAsJsonAsync("Section/AddOrEditSection", sec);
                if (response.IsSuccessStatusCode)
                {
                    var Data = await response.Content.ReadAsStringAsync();
                    var res = JsonConvert.DeserializeObject<Response<SectionViewModel>>(Data);
                    if (!res.Status)
                    {
                        TempData["ErrorMessage"] = res.Message;
                        return Redirect($"/Section/Index");
                    }
                    TempData["SuccessMessage"] = res.Message;
                    return Redirect($"/Section/Index");
                }
                else
                {
                    return Redirect($"/Section/Index");
                }
            }
        }


        public async Task<IActionResult> DeleteSection(int id)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = Constrant.AppUrl;
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                //POST Method
                HttpResponseMessage response = await client.DeleteAsync("Section/DeleteSection?SecId="+id );
                if (response.IsSuccessStatusCode)
                {
                    var Data = await response.Content.ReadAsStringAsync();
                    var res = JsonConvert.DeserializeObject<Response<SectionViewModel>>(Data);
                    if (!res.Status)
                    {
                        TempData["ErrorMessage"] = res.Message;
                        return Redirect($"/Section/Index");
                    }
                    TempData["SuccessMessage"] = res.Message;
                    return Redirect($"/Section/Index");
                }
                else
                {
                    return Redirect($"/Section/Index");
                }
            }
        }

    }
}
