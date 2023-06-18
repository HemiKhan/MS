using Microsoft.AspNetCore.Mvc;
using MS_Models.ViewModel;
using MS_UI.Models.Common;
using MS_UI.Services;
using Newtonsoft.Json;
using System.Net.Http.Headers;

namespace MS_UI.Controllers
{
    public class ClassController : Controller
    {
        private readonly CommonService commonService;
        public ClassController()
        {
            commonService = new CommonService();
        }
        public async Task<IActionResult> Index()
        {
            var classData = await commonService.GetClass();
            if (classData.list is not null)
                return View(classData.list);
            return View();
        }
<<<<<<< HEAD
=======

>>>>>>> a3501d614d417619153db92b0908bbe37e6970e0
        [HttpPost]
        public async Task<IActionResult> AddOrUpdateClass(ClassViewModel model)
        {
            ClassViewModel clas = new ClassViewModel();
            clas.ClassId = model.ClassId;
            clas.ClassName = model.ClassName;
            clas.IsActive = model.IsActive;

            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = Constrant.AppUrl;
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                //POST Method
                HttpResponseMessage response = await client.PostAsJsonAsync("Class/AddClass", clas);
                if (response.IsSuccessStatusCode)
                {
                    var Data = await response.Content.ReadAsStringAsync();
                    var res = JsonConvert.DeserializeObject<Response<ClassViewModel>>(Data);
                    if (!res.Status)
                    {
                        TempData["ErrorMessage"] = res.Message;
                        return Redirect($"/Class/Index");
                    }
                    TempData["SuccessMessage"] = res.Message;
                    return Redirect($"/Class/Index");
                }
                else
                {
                    return Redirect($"/Class/Index");
                }
            }
        }

        public async Task<IActionResult> DeleteClass(int id)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = Constrant.AppUrl;
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                //POST Method
                HttpResponseMessage response = await client.DeleteAsync("Class/DeleteClass?ClassId=" + id);
                if (response.IsSuccessStatusCode)
                {
                    var Data = await response.Content.ReadAsStringAsync();
                    var res = JsonConvert.DeserializeObject<Response<ClassViewModel>>(Data);
                    if (!res.Status)
                    {
                        TempData["ErrorMessage"] = res.Message;
                        return Redirect($"/Class/Index");
                    }
                    TempData["SuccessMessage"] = res.Message;
                    return Redirect($"/Class/Index");
                }
                else
                {
                    return Redirect($"/Class/Index");
                }
            }
        }
    }
}
