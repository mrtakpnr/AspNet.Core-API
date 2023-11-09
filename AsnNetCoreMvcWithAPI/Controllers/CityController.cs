using AsnNetCoreMvcWithAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;
using System.Text.Json.Serialization;

namespace AsnNetCoreMvcWithAPI.Controllers
{
    public class CityController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public CityController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var http = _httpClientFactory.CreateClient(); //HttpClient nesnesi oluşturur.
            var result = await http.GetAsync("https://localhost:7122/api/cities");
            if (result.StatusCode == System.Net.HttpStatusCode.OK)
            {
                var jsonData = await result.Content.ReadAsStringAsync();
                var data = JsonConvert.DeserializeObject<List<CityViewModel>>(jsonData);
                return View(data);
            }
            return View();
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(CityViewModel model)
        {
            var http = _httpClientFactory.CreateClient(); //HttpClient nesnesi oluşturur.
            var jsonData = JsonConvert.SerializeObject(model);
            var content = new StringContent(jsonData, encoding: Encoding.UTF8, "application/json");
            var result = await http.PostAsync("https://localhost:7122/api/cities", content);
            if (result.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }

            return View();
        }
        public async Task<IActionResult> Edit(int id)
        {
            var http = _httpClientFactory.CreateClient(); //HttpClient nesnesi oluşturur.
            var result = await http.GetAsync($"https://localhost:7122/api/cities/{id}");
            var jsonData = await result.Content.ReadAsStringAsync();
            var data = JsonConvert.DeserializeObject<CityViewModel>(jsonData);
            return View(data);
        }
           
    
        [HttpPost]
        public async Task<IActionResult> Edit(CityViewModel city)
        {
            var http = _httpClientFactory.CreateClient(); //HttpClient nesnesi oluşturur.
            var jsonData = JsonConvert.SerializeObject(city); 
            var content = new StringContent(jsonData, encoding: Encoding.UTF8, "application/json"); 
            var result = await http.PutAsync($"https://localhost:7122/api/cities/", content); 
            if (result.IsSuccessStatusCode) 
            {
                return RedirectToAction("Index"); 
            }

            return View();
        }
    }
}
