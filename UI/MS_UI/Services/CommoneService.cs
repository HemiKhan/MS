using Microsoft.AspNetCore.Mvc.Rendering;
using MS_UI.Models.Common;
using Newtonsoft.Json;
using System.Net.Http.Headers;

namespace MS_UI.Services
{
    public class CommoneService
    {
        public async Task GetCampus()
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    client.BaseAddress = Constrant.AppUrl;
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    //Get Method
                    HttpResponseMessage response = await client.GetAsync("ComplaintPortal/GetFromDepartment?DeptCode=" + DeptCode);
                    if (response.IsSuccessStatusCode)
                    {
                        var Data = await response.Content.ReadAsStringAsync();
                        var res = JsonConvert.DeserializeObject<Response<FromDepartment>>(Data);
                        if (!res.Status)
                            ViewBag.Error = res.Message;

                        ViewBag.FromDepartment = new SelectList(res.List, "DeptCode", "DeptName");
                    }
                    else
                    {
                        Console.WriteLine("Internal server Error");
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
