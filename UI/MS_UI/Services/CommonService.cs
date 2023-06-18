using Microsoft.AspNetCore.Mvc.Rendering;
using MS_Models.Model;
using MS_UI.Models.Common;
using Newtonsoft.Json;
using System.Net.Http.Headers;

namespace MS_UI.Services
{
    public class CommonService
    {
        public async Task<(string message, List<Campus> list)> GetCampus()
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    client.BaseAddress = Constrant.AppUrl;
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    //Get Method
                    HttpResponseMessage response = await client.GetAsync("Campus/GetCampus");
                    if (response.IsSuccessStatusCode)
                    {
                        var responseData = await response.Content.ReadAsStringAsync();
                        var result = JsonConvert.DeserializeObject<Response<Campus>>(responseData);
                        if (!result!.Status)
                            return (message: result.Message, list: null);

                        return (message: result.Message, list: result.List!);
                    }
                    else
                    {
                        return (message: "Internal server error occurred.", list: null);
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<(string message, List<Session> list)> GetSession()
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    client.BaseAddress = Constrant.AppUrl;
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    //Get Method
                    HttpResponseMessage response = await client.GetAsync("Session/GetSession");
                    if (response.IsSuccessStatusCode)
                    {
                        var responseData = await response.Content.ReadAsStringAsync();
                        var result = JsonConvert.DeserializeObject<Response<Session>>(responseData);
                        if (!result!.Status)
                            return (message: result.Message, list: null);

                        return (message: result.Message, list: result.List!);
                    }
                    else
                    {
                        return (message: "Internal server error occurred.", list: null);
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<(string message, List<Section> list)> GetSection()
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    client.BaseAddress = Constrant.AppUrl;
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    //Get Method
                    HttpResponseMessage response = await client.GetAsync("Section/GetSection");
                    if (response.IsSuccessStatusCode)
                    {
                        var responseData = await response.Content.ReadAsStringAsync();
                        var result = JsonConvert.DeserializeObject<Response<Section>>(responseData);
                        if (!result!.Status)
                            return (message: result.Message, list: null);

                        return (message: result.Message, list: result.List!);
                    }
                    else
                    {
                        return (message: "Internal server error occurred.", list: null);
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<(string message, List<Class> list)> GetClass()
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    client.BaseAddress = Constrant.AppUrl;
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    //Get Method
                    HttpResponseMessage response = await client.GetAsync("Class/GetClass");
                    if (response.IsSuccessStatusCode)
                    {
                        var responseData = await response.Content.ReadAsStringAsync();
                        var result = JsonConvert.DeserializeObject<Response<Class>>(responseData);
                        if (!result!.Status)
                            return (message: result.Message, list: null);

                        return (message: result.Message, list: result.List!);
                    }
                    else
                    {
                        return (message: "Internal server error occurred.", list: null);
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<string> GetBase64StringFromImage(IFormFile imageFile)
        {
            if (imageFile != null && imageFile.Length > 0)
            {
                using (var memoryStream = new MemoryStream())
                {
                    await imageFile.CopyToAsync(memoryStream);

                    // Convert the file to Base64
                    var base64String = Convert.ToBase64String(memoryStream.ToArray());

                    return base64String;
                }
            }

            return null;
        }


    }
}
