using MCV.Migrations;
using MCV.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System.Text;
using MCV.ViewModel;

namespace MCV.Areas.Admin.Controllers.BanHang
{
    [Area("admin")]
    public class QuanLySanPhamBanController : Controller
    {

        public async Task<ActionResult> Index()
        {
            string requesURL = $"https://localhost:7268/api/ShoeDetail";
            var httpClient = new HttpClient();
            var response = await httpClient.GetAsync(requesURL);
            string apiData = await response.Content.ReadAsStringAsync();
            var lst = JsonConvert.DeserializeObject<List<ShoeDetail>>(apiData);
            return View(lst);
        }

        // GET: QuanLySanPhamBanController/Details/5
        public async Task<ActionResult> Details(Guid id)
        {
            var url = $"https://localhost:7268/api/ShoeDetail/{id}";
            var httpClient = new HttpClient();
            var response = await httpClient.GetAsync(url);
            var dataApi = await response.Content.ReadAsStringAsync();
            var lst = JsonConvert.DeserializeObject<ShoeDetail>(dataApi);
            return View(lst);
        }

        // GET: QuanLySanPhamBanController/Create
        public async Task<ActionResult> Create()
        {
            string requesURL1 = $"https://localhost:7268/api/Shoe";
            var a1 = new HttpClient();
            var response1 = await a1.GetAsync(requesURL1);
            string apiData1 = await response1.Content.ReadAsStringAsync();
            var lst1 = JsonConvert.DeserializeObject<List<Shoe>>(apiData1);

            string requesURL2 = $"https://localhost:7268/api/Size";
            var a2 = new HttpClient();
            var response2 = await a2.GetAsync(requesURL2);
            string apiData2 = await response2.Content.ReadAsStringAsync();
            var lst2 = JsonConvert.DeserializeObject<List<Size>>(apiData2);

            string requesURL3 = $"https://localhost:7268/api/Category";
            var a3 = new HttpClient();
            var response3 = await a3.GetAsync(requesURL3);
            string apiData3 = await response3.Content.ReadAsStringAsync();
            var lst3 = JsonConvert.DeserializeObject<List<Category>>(apiData3);

            string requesURL4 = $"https://localhost:7268/api/Brand";
            var a4 = new HttpClient();
            var response4 = await a4.GetAsync(requesURL4);
            string apiData4 = await response4.Content.ReadAsStringAsync();
            var lst4 = JsonConvert.DeserializeObject<List<Brand>>(apiData4);

            string requesURL5 = $"https://localhost:7268/api/Color";
            var a5 = new HttpClient();
            var response5 = await a5.GetAsync(requesURL5);
            string apiData5 = await response5.Content.ReadAsStringAsync();
            var lst5 = JsonConvert.DeserializeObject<List<Color>>(apiData5);

            var viewModel = new BanHangView()
            {

                ShoeItems = lst1.Select(s => new SelectListItem
                {
                    Value = s.id.ToString(),
                    Text = s.name.ToString()
                }).ToList(),
                SizeItems = lst2.Select(s => new SelectListItem
                {
                    Value = s.id.ToString(),
                    Text = s.name.ToString()
                }).ToList(),
                CategoryItems = lst3.Select(s => new SelectListItem
                {
                    Value = s.id.ToString(),
                    Text = s.name.ToString()
                }).ToList(),
                BrandItems = lst4.Select(s => new SelectListItem
                {
                    Value = s.id.ToString(),
                    Text = s.name.ToString()
                }).ToList(),
                ColorItems = lst5.Select(s => new SelectListItem
                {
                    Value = s.id.ToString(),
                    Text = s.name.ToString()
                }).ToList(),

            };
            return View(viewModel);
        }

        // POST: QuanLySanPhamBanController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(BanHangView b)
        {

           
            // GET: QuanLySanPhamBanController
            try
            {
                var a = new ShoeDetail()
                {
                    id = Guid.NewGuid(),
                    ShoeId = b.ShoeId,
                    SizeId = b.SizeId,
                    BrandId = b.BrandId,
                    CategoryId = b.CategoryId,
                    ColorId = b.ColorId,
                    Code = b.Code,
                    PriceInput = b.PriceInput,
                    PriceOutput = b.PriceOutput,
                    Quantity = b.Quantity,
                    Status = b.Status
                };
                var url = $"https://localhost:7268/api/ShoeDetail/Add";
                var httpClient = new HttpClient();
                var content = new StringContent(JsonConvert.SerializeObject(a), Encoding.UTF8, "application/json");
                var respose = await httpClient.PostAsync(url, content);
                if (respose.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
                string requesURL1 = $"https://localhost:7268/api/Shoe";
                var a1 = new HttpClient();
                var response1 = await a1.GetAsync(requesURL1);
                string apiData1 = await response1.Content.ReadAsStringAsync();
                var lst1 = JsonConvert.DeserializeObject<List<Shoe>>(apiData1);

                string requesURL2 = $"https://localhost:7268/api/Size";
                var a2 = new HttpClient();
                var response2 = await a2.GetAsync(requesURL2);
                string apiData2 = await response2.Content.ReadAsStringAsync();
                var lst2 = JsonConvert.DeserializeObject<List<Size>>(apiData2);

                string requesURL3 = $"https://localhost:7268/api/Category";
                var a3 = new HttpClient();
                var response3 = await a3.GetAsync(requesURL3);
                string apiData3 = await response3.Content.ReadAsStringAsync();
                var lst3 = JsonConvert.DeserializeObject<List<Category>>(apiData3);

                string requesURL4 = $"https://localhost:7268/api/Brand";
                var a4 = new HttpClient();
                var response4 = await a4.GetAsync(requesURL4);
                string apiData4 = await response4.Content.ReadAsStringAsync();
                var lst4 = JsonConvert.DeserializeObject<List<Brand>>(apiData4);

                string requesURL5 = $"https://localhost:7268/api/Color";
                var a5 = new HttpClient();
                var response5 = await a5.GetAsync(requesURL5);
                string apiData5 = await response5.Content.ReadAsStringAsync();
                var lst5 = JsonConvert.DeserializeObject<List<Color>>(apiData5);

                var viewModel = new BanHangView()
                {

                    ShoeItems = lst1.Select(s => new SelectListItem
                    {
                        Value = s.id.ToString(),
                        Text = s.name.ToString()
                    }).ToList(),
                    SizeItems = lst2.Select(s => new SelectListItem
                    {
                        Value = s.id.ToString(),
                        Text = s.name.ToString()
                    }).ToList(),
                    CategoryItems = lst3.Select(s => new SelectListItem
                    {
                        Value = s.id.ToString(),
                        Text = s.name.ToString()
                    }).ToList(),
                    BrandItems = lst4.Select(s => new SelectListItem
                    {
                        Value = s.id.ToString(),
                        Text = s.name.ToString()
                    }).ToList(),
                    ColorItems = lst5.Select(s => new SelectListItem
                    {
                        Value = s.id.ToString(),
                        Text = s.name.ToString()
                    }).ToList(),

                };
                return View(viewModel);

            }
            catch
            {
                string requesURL1 = $"https://localhost:7268/api/Shoe";
                var a1 = new HttpClient();
                var response1 = await a1.GetAsync(requesURL1);
                string apiData1 = await response1.Content.ReadAsStringAsync();
                var lst1 = JsonConvert.DeserializeObject<List<Shoe>>(apiData1);

                string requesURL2 = $"https://localhost:7268/api/Size";
                var a2 = new HttpClient();
                var response2 = await a2.GetAsync(requesURL2);
                string apiData2 = await response2.Content.ReadAsStringAsync();
                var lst2 = JsonConvert.DeserializeObject<List<Size>>(apiData2);

                string requesURL3 = $"https://localhost:7268/api/Category";
                var a3 = new HttpClient();
                var response3 = await a3.GetAsync(requesURL3);
                string apiData3 = await response3.Content.ReadAsStringAsync();
                var lst3 = JsonConvert.DeserializeObject<List<Category>>(apiData3);

                string requesURL4 = $"https://localhost:7268/api/Brand";
                var a4 = new HttpClient();
                var response4 = await a4.GetAsync(requesURL4);
                string apiData4 = await response4.Content.ReadAsStringAsync();
                var lst4 = JsonConvert.DeserializeObject<List<Brand>>(apiData4);

                string requesURL5 = $"https://localhost:7268/api/Color";
                var a5 = new HttpClient();
                var response5 = await a5.GetAsync(requesURL5);
                string apiData5 = await response5.Content.ReadAsStringAsync();
                var lst5 = JsonConvert.DeserializeObject<List<Color>>(apiData5);

                var viewModel = new BanHangView()
                {

                    ShoeItems = lst1.Select(s => new SelectListItem
                    {
                        Value = s.id.ToString(),
                        Text = s.name.ToString()
                    }).ToList(),
                    SizeItems = lst2.Select(s => new SelectListItem
                    {
                        Value = s.id.ToString(),
                        Text = s.name.ToString()
                    }).ToList(),
                    CategoryItems = lst3.Select(s => new SelectListItem
                    {
                        Value = s.id.ToString(),
                        Text = s.name.ToString()
                    }).ToList(),
                    BrandItems = lst4.Select(s => new SelectListItem
                    {
                        Value = s.id.ToString(),
                        Text = s.name.ToString()
                    }).ToList(),
                    ColorItems = lst5.Select(s => new SelectListItem
                    {
                        Value = s.id.ToString(),
                        Text = s.name.ToString()
                    }).ToList(),

                };
                return View(viewModel);
            }
        }

        // GET: QuanLySanPhamBanController/Edit/5
        public async Task<ActionResult> Edit(Guid id)
        {
            if (ModelState.IsValid)
            {
                var url = $"https://localhost:7268/api/ShoeDetail/{id}";
                var httpClient = new HttpClient();
                var response = await httpClient.GetAsync(url);
                var dataApi = await response.Content.ReadAsStringAsync();
                var lst = JsonConvert.DeserializeObject<ShoeDetail>(dataApi);
                return View(lst);
            }

            return BadRequest();
        }

        // POST: QuanLySanPhamBanController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(ShoeDetail a)
        {

            try
            {
                var url = $"https://localhost:7268/api/ShoeDetail/Update";
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

        // GET: QuanLySanPhamBanController/Delete/5
        public async Task<ActionResult> Delete(Guid id)
        {
            var url = $"https://localhost:7268/api/ShoeDetail/delete/{id}";
            var httpClient = new HttpClient();
            var respose = await httpClient.DeleteAsync(url);
            if (respose.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }

            return BadRequest();
        }

        // POST: QuanLySanPhamBanController/Delete/5
    }
}
