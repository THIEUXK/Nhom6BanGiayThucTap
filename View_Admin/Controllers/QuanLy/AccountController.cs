using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net.NetworkInformation;
using MCV.Models;
using Newtonsoft.Json;
using System.Text;

namespace View_Admin.Controllers.QuanLy
{
    public class AccountController : Controller
    {
        // GET: AccountController
        [HttpGet]
        public async Task<ActionResult> Index()
        {
            string requesURL = $"https://localhost:7021/api/SanPham/get-all-SanPham";
            var httpClient = new HttpClient();
            var response = await httpClient.GetAsync(requesURL);
            string apiData = await response.Content.ReadAsStringAsync();
            var lst = JsonConvert.DeserializeObject<List<Account>>(apiData);
            return View(lst);
        }

        // GET: AccountController/Details/5
        [HttpGet]
        public async Task<ActionResult> Details(Guid id)
        {
            var url = $"https://localhost:7021/api/ChatLieu/get-by-chatlieu?id={id}";
            var httpClient = new HttpClient();
            var response = await httpClient.GetAsync(url);
            var dataApi = await response.Content.ReadAsStringAsync();
            var lst = JsonConvert.DeserializeObject<Account>(dataApi);
            return View(lst);
        }

        // GET: AccountController/Create
        public ActionResult Create()
        {
            if (ModelState.IsValid)
            {
                return View();
            }

            return BadRequest();
        }

        // POST: AccountController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Account a)
        {
            try
            {
                var url = $"h";
                var httpClient = new HttpClient();
                var content = new StringContent(JsonConvert.SerializeObject(a), Encoding.UTF8, "application/json");
                var respose = await httpClient.PostAsync(url, content);
                if (respose.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
                return View();

            }
            catch
            {
                return View();
            }
        }

        // GET: AccountController/Edit/5
        public async Task<ActionResult> Edit(Guid id)
        {
            if (ModelState.IsValid)
            {
                var url = $"https://localhost:7021/api/ChatLieu/get-by-chatlieu?id={id}";
                var httpClient = new HttpClient();
                var response = await httpClient.GetAsync(url);
                var dataApi = await response.Content.ReadAsStringAsync();
                var lst = JsonConvert.DeserializeObject<Account>(dataApi);
                return View(lst);
            }

            return BadRequest();
        }

        // POST: AccountController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(Account a)
        {
            try
            {
                var url = $"";
                var httpClient = new HttpClient();
                var content = new StringContent(JsonConvert.SerializeObject(a), Encoding.UTF8, "application/json");
                var respose = await httpClient.PostAsync(url, content);
                if (respose.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
                return View();
            }
            catch (Exception e)
            {
                return View();
            }
        }

        // GET: AccountController/Delete/5
        public async Task<ActionResult> Delete(Guid id)
        {
            var url = $"https://localhost:7021/api/ChatLieu/delete-chatlieu/{id}";
            var httpClient = new HttpClient();
            var respose = await httpClient.DeleteAsync(url);
            if (respose.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return BadRequest();
        }
    }
}
