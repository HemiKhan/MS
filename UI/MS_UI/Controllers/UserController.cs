using Microsoft.AspNetCore.Mvc;
using MS_UI.Models;
using Newtonsoft.Json;
using System.IdentityModel.Tokens.Jwt;
using System.Net.Http.Headers;

namespace MS_UI.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Login()
        {
            if (HttpContext.Session.GetString("Token") != null)
            {
                return Redirect("/Home/Index");
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel Login)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = Constrant.AppUrl;
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                //POST Method
                HttpResponseMessage response = await client.PostAsJsonAsync("api/Account/Login", Login);
                if (response.IsSuccessStatusCode)
                {
                    var Data = await response.Content.ReadAsStringAsync();
                    var Result = JsonConvert.DeserializeObject<Response<string>>(Data);
                    var handler = new JwtSecurityTokenHandler();
                    var jsonToken = handler.ReadToken(Result.Data);
                    var token = jsonToken as JwtSecurityToken;
                    var payload = token.Payload;
                    var email = "";

                    HttpContext.Session.SetString("Token", Result.Data);
                    foreach (var item in payload)
                    {
                        if (item.Key == "Email")
                        {
                            email = item.Value.ToString();
                            HttpContext.Session.SetString("Email", email!);
                        }
                        if (item.Key == "FirstName")
                        {
                            HttpContext.Session.SetString("FirstName", item.Value.ToString());
                        }
                        if (item.Key == "LastName")
                        {
                            HttpContext.Session.SetString("LastName", item.Value.ToString());
                        }
                        if (item.Key == "UserId")
                        {
                            HttpContext.Session.SetString("UserId", item.Value.ToString());
                        }
                        if (item.Key == "UserRole")
                        {
                            HttpContext.Session.SetString("UserRole", item.Value.ToString());
                        }
                    }

                    if (email == "admin@gmail.com")
                        return Redirect("/Admin/Dashboard");
                    return Redirect("/Index/Home");

                    //var Token = HttpContext.Session.GetString("Token");
                    //var email = HttpContext.Session.GetString("Email");
                    //var FirstName = HttpContext.Session.GetString("FirstName");
                    //var LastName = HttpContext.Session.GetString("LastName");
                    //var UserId = HttpContext.Session.GetString("UserId");
                    //var UserRole = HttpContext.Session.GetString("UserRole");

                }
                else
                {
                    Console.WriteLine("Internal server Error");
                    return View();
                }
            }
        }

        public IActionResult Role()
        {
            return View();
        }
    }
}
