﻿using MCV.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace View_Admin.Controllers.QuanLy
{
    [Area("admin")]
    public class AddressController : Controller
    {
        public async Task<ActionResult> Index()
        {
            string requesURL = $"https://localhost:7268/api/Address";
            var httpClient = new HttpClient();
            var response = await httpClient.GetAsync(requesURL);
            string apiData = await response.Content.ReadAsStringAsync();
            var lst = JsonConvert.DeserializeObject<List<Address>>(apiData);
            return View(lst);
        }

        // GET: RoleController/Details/5
        public async Task<ActionResult> Details(Guid id)
        {
            var url = $"https://localhost:7268/api/Address/{id}";
            var httpClient = new HttpClient();
            var response = await httpClient.GetAsync(url);
            var dataApi = await response.Content.ReadAsStringAsync();
            var lst = JsonConvert.DeserializeObject<Address>(dataApi);
            return View(lst);
        }

        // GET: RoleController/Create
        public ActionResult Create()
        {
            if (ModelState.IsValid)
            {
                return View();
            }

            return BadRequest();
        }

        // POST: RoleController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Address a)
        {
            try
            {
                var url = $"https://localhost:7268/api/Address/Add";
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
                var url = $"https://localhost:7268/api/Address/{id}";
                var httpClient = new HttpClient();
                var response = await httpClient.GetAsync(url);
                var dataApi = await response.Content.ReadAsStringAsync();
                var lst = JsonConvert.DeserializeObject<Address>(dataApi);
                return View(lst);
            }

            return BadRequest();
        }

        // POST: RoleController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(Address a)
        {
            try
            {
                var url = $"https://localhost:7268/api/Address/Update";
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
            var url = $"https://localhost:7268/api/Address/delete/{id}";
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
