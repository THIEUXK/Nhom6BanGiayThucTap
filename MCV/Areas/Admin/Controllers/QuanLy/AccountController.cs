using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net.NetworkInformation;
using MCV.Models;
using Newtonsoft.Json;
using System.Text;

namespace View_Admin.Controllers.QuanLy
{
    [Area("admin")]
    public class AccountController : Controller
    {
        public async Task<ActionResult> Index()
        {
            ViewBag.Role = LRole();
            string requesURL = $"https://localhost:7268/api/Account";
            var httpClient = new HttpClient();
            var response = await httpClient.GetAsync(requesURL);
            string apiData = await response.Content.ReadAsStringAsync();
            var lst = JsonConvert.DeserializeObject<List<Account>>(apiData);
            return View(lst);
        }
        public async Task<List<Role>> LRole()
        {

            string requesURL = $"https://localhost:7268/api/Role";
            var httpClient = new HttpClient();
            var response = await httpClient.GetAsync(requesURL);
            string apiData = await response.Content.ReadAsStringAsync();
            var lst = JsonConvert.DeserializeObject<List<Role>>(apiData);
            return lst;
        }
        // GET: RoleController/Details/5
        public async Task<ActionResult> Details(Guid id)
        {
            ViewBag.Role = LRole();
            var url = $"https://localhost:7268/api/Account/{id}";
            var httpClient = new HttpClient();
            var response = await httpClient.GetAsync(url);
            var dataApi = await response.Content.ReadAsStringAsync();
            var lst = JsonConvert.DeserializeObject<Account>(dataApi);
            return View(lst);
        }

        // GET: RoleController/Create
        public ActionResult Create()
        {
            ViewBag.Role = LRole();
            if (ModelState.IsValid)
            {
                return View();
            }

            return BadRequest();
        }

        // POST: RoleController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Account a)
        {
            
            try
            {
                ViewBag.Role = LRole();
                var url = $"https://localhost:7268/api/Account/Add";
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

        // GET: RoleController/Edit/5
        public async Task<ActionResult> Edit(Guid id)
        {
            if (ModelState.IsValid)
            {
                ViewBag.Role = LRole();
                var url = $"https://localhost:7268/api/Account/{id}";
                var httpClient = new HttpClient();
                var response = await httpClient.GetAsync(url);
                var dataApi = await response.Content.ReadAsStringAsync();
                var lst = JsonConvert.DeserializeObject<Account>(dataApi);
                return View(lst);
            }

            return BadRequest();
        }

        // POST: RoleController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(Account a)
        {
            try
            {
                var url = $"https://localhost:7268/api/Account/Update";
                var httpClient = new HttpClient();
                var content = new StringContent(JsonConvert.SerializeObject(a), Encoding.UTF8, "application/json");
                var respose = await httpClient.PutAsync(url, content);
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

        // GET: RoleController/Delete/5
        public async Task<ActionResult> Delete(Guid id)
        {
            var url = $"https://localhost:7268/api/Account/delete/{id}";
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
