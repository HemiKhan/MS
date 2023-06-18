using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MS_Models.Model;
using MS_Models.ViewModel;
using MS_UI.Models.Common;
using MS_UI.Services;
using Newtonsoft.Json;
using System.Net.Http.Headers;

namespace MS_UI.Controllers
{
    public class SessionController : Controller
    {
        private readonly CommonService commonService;
        public SessionController()
        {
            commonService = new CommonService();
        }
        public async Task<IActionResult> Index()
        {
            var session = await commonService.GetSession();
            if (session.list is not null)
                return View(session.list);
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddOrUpdateSession(SessionViewModel model)
        {
            SessionViewModel sess = new SessionViewModel();
            sess.SessionId = model.SessionId;
            sess.SessionName = model.SessionName;
            sess.StartDate = model.StartDate;
            sess.EndDate = model.EndDate;
            sess.IsActive = model.IsActive;

            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = Constrant.AppUrl;
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                //POST Method
                HttpResponseMessage response = await client.PostAsJsonAsync("Session/AddOrUpdateSession", sess);
                if (response.IsSuccessStatusCode)
                {
                    var Data = await response.Content.ReadAsStringAsync();
                    var res = JsonConvert.DeserializeObject<Response<SessionViewModel>>(Data);
                    if (!res.Status)
                    {
                        TempData["ErrorMessage"] = res.Message;
                        return Redirect($"/Session/Index");
                    }
                    TempData["SuccessMessage"] = res.Message;
                    return Redirect($"/Session/Index");
                }
                else
                {
                    return Redirect($"/Session/Index");
                }
            }
        }

        public async Task<IActionResult> DeleteSession(int id)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = Constrant.AppUrl;
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                //POST Method
                HttpResponseMessage response = await client.DeleteAsync("Session/DeleteSession?SessId=" + id);
                if (response.IsSuccessStatusCode)
                {
                    var Data = await response.Content.ReadAsStringAsync();
                    var res = JsonConvert.DeserializeObject<Response<SessionViewModel>>(Data);
                    if (!res.Status)
                    {
                        TempData["ErrorMessage"] = res.Message;
                        return Redirect($"/Session/Index");
                    }
                    TempData["SuccessMessage"] = res.Message;
                    return Redirect($"/Session/Index");
                }
                else
                {
                    return Redirect($"/Session/Index");
                }
            }
        }

    }
}
