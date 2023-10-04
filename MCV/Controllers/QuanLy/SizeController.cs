using MCV.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace MCV.Controllers.QuanLy
{
    public class SizeController : Controller
    {
        // GET: SizeController
        [HttpGet]
        public async Task<ActionResult> ListSize()
        {
           
                try
                {
                    string requesURL = $"https://localhost:7021/api/Size/get-all-Size";
                    var httpClient = new HttpClient();
                    var response = await httpClient.GetAsync(requesURL);
                    string apiData = await response.Content.ReadAsStringAsync();
                    var lst = JsonConvert.DeserializeObject<List<Size>>(apiData);

                    return View(lst);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    throw;
                }

        }


        // GET: SizeController/Details/5
        [HttpGet]
        public async Task<ActionResult> Details(Guid id)
        {
            var url = $"https://localhost:7021/api/Size/get-by-Size/{id}";
            var httpClient = new HttpClient();
            var response = await httpClient.GetAsync(url);
            var dataApi = await response.Content.ReadAsStringAsync();
            var lst = JsonConvert.DeserializeObject<Size>(dataApi);
            return View(lst);
        }

        // GET: SizeController/Create
        public ActionResult Create()
        {
            if (ModelState.IsValid)
            {
                return View();
            }

            return BadRequest();
        }

        // POST: SizeController/Create
        [HttpPost]
        public async Task<ActionResult> Create(Size s)
        {
            try
            {
                var url = $"";
                var httpClient = new HttpClient();
                var content = new StringContent(JsonConvert.SerializeObject(s), Encoding.UTF8, "application/json");
                var respose = await httpClient.PostAsync(url, content);
                if (respose.IsSuccessStatusCode)
                {
                    return RedirectToAction("ListSize");
                }
                return View();

            }
            catch
            {
                return View();
            }
        }

        // POST: SizeController/Edit/5
       public async Task<IActionResult> Edit(Guid id)
        {
            if (ModelState.IsValid)
            {
                var url = $"https://localhost:7021/api/Size/get-by-Size/{id}";
                var httpClient = new HttpClient();
                var response = await httpClient.GetAsync(url);
                var dataApi = await response.Content.ReadAsStringAsync();
                var lst = JsonConvert.DeserializeObject<Size>(dataApi);
                return View(lst);
            }

            return BadRequest();

        }
       [HttpPost]
       public async Task<IActionResult> Edit(Size s)
       {
           try
           {
               var url = $"";
               var httpClient = new HttpClient();
               var content = new StringContent(JsonConvert.SerializeObject(s), Encoding.UTF8, "application/json");
               var respose = await httpClient.PostAsync(url, content);
               if (respose.IsSuccessStatusCode)
               {
                   return RedirectToAction("ListSize");
               }
               return View();
           }
           catch (Exception e)
           {
               return View();
           }

       }

        // GET: SizeController/Delete/5
        public async Task<ActionResult> Delete(Guid id)
        {
            var url = $"https://localhost:7021/api/Size/delete-Size{id}";
            var httpClient = new HttpClient();
            var respose = await httpClient.DeleteAsync(url);
            if (respose.IsSuccessStatusCode)
            {
                return RedirectToAction("ListSize");
            }
            return BadRequest();
        }
    }
}
