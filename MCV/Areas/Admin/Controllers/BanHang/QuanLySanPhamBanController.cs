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
        [HttpGet]
        public async Task<ActionResult> Details(Guid id)
        {
            string requesURL = $"https://localhost:7268/api/ShoeDetail";
            var httpClient = new HttpClient();
            var response = await httpClient.GetAsync(requesURL);
            string apiData = await response.Content.ReadAsStringAsync();
            var lst = JsonConvert.DeserializeObject<List<ShoeDetail>>(apiData);

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


            string requesURL51 = $"https://localhost:7268/api/Image";
            var a51 = new HttpClient();
            var response51 = await a51.GetAsync(requesURL51);
            string apiData51 = await response51.Content.ReadAsStringAsync();
            var lst51 = JsonConvert.DeserializeObject<List<Image>>(apiData51);


            List<SanPhamBan> view = (from s in lst
                                     join a in lst1 on s.ShoeId equals a.id
                                     join b in lst2 on s.SizeId equals b.id
                                     join c in lst3 on s.CategoryId equals c.id
                                     join d in lst4 on s.BrandId equals d.id
                                     join e in lst5 on s.ColorId equals e.id
                                     select new SanPhamBan()
                                     {
                                         ShoeDetail = s,
                                         Shoes = a,
                                         Sizes = b,
                                         Categories = c,
                                         Brands = d,
                                         Color = e,
                                     }).ToList();

            var SPCT = view.FirstOrDefault(c => c.ShoeDetail.id == id);

            

         

            var view1 = new BanHangView()
            {
                Anh= lst51/*.Where(c=>c.ShoeDetailId==id)*/.ToList(),
                sanPhamBan =SPCT,
            };
            return View(view1);
        }
        [HttpPost]
        public async Task<ActionResult> AddAnh(Guid IdSP, [Bind] IFormFile imageFile)
        {
            if (imageFile != null && imageFile.Length > 0) // Không null và không trống
            {
                //Trỏ tới thư mục wwwroot để lát nữa thực hiện việc Copy sang
                var path = Path.Combine(
                    Directory.GetCurrentDirectory(), "wwwroot", "image", imageFile.FileName);
                using (var stream = new FileStream(path, FileMode.Create))
                {
                    imageFile.CopyTo(stream);
                }

            }

            if (imageFile != null)
            {
                {
                    var a=new Image()
                    {
                        ShoeDetailId = IdSP,                 
                        ImgUrl = imageFile.FileName
                    };
                    var url = $"https://localhost:7268/api/Image/Add";
                    var httpClient = new HttpClient();
                    var content = new StringContent(JsonConvert.SerializeObject(a), Encoding.UTF8, "application/json");
                    var respose = await httpClient.PostAsync(url, content);

                }
            }


            return RedirectToAction("Details", new { id = IdSP });
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
                    ShoeId = b.ShoeId,
                    SizeId = b.SizeId,
                    BrandId = b.BrandId,
                    CategoryId = b.CategoryId,
                    ColorId = b.ColorId,               
                    Quantity = b.Quantity,
                    Status = b.Status
                };
                var url = $"https://localhost:7268/api/ShoeDetail/Add";
                var httpClient = new HttpClient();
                var content = new StringContent(JsonConvert.SerializeObject(a), Encoding.UTF8, "application/json");
                var respose = await httpClient.PostAsync(url, content);
                if (respose.IsSuccessStatusCode)
                {
                    string requesURL11 = $"https://localhost:7268/api/Shoe";
                    var a11 = new HttpClient();
                    var response11 = await a11.GetAsync(requesURL11);
                    string apiData11= await response11.Content.ReadAsStringAsync();
                    var lst11 = JsonConvert.DeserializeObject<List<Shoe>>(apiData11);

                    string requesURL21 = $"https://localhost:7268/api/Size";
                    var a21 = new HttpClient();
                    var response21 = await a21.GetAsync(requesURL21);
                    string apiData21 = await response21.Content.ReadAsStringAsync();
                    var lst21 = JsonConvert.DeserializeObject<List<Size>>(apiData21);

                    string requesURL31 = $"https://localhost:7268/api/Category";
                    var a31 = new HttpClient();
                    var response31 = await a31.GetAsync(requesURL31);
                    string apiData31 = await response31.Content.ReadAsStringAsync();
                    var lst31 = JsonConvert.DeserializeObject<List<Category>>(apiData31);

                    string requesURL41 = $"https://localhost:7268/api/Brand";
                    var a41 = new HttpClient();
                    var response41 = await a41.GetAsync(requesURL41);
                    string apiData41 = await response41.Content.ReadAsStringAsync();
                    var lst41 = JsonConvert.DeserializeObject<List<Brand>>(apiData41);

                    string requesURL51 = $"https://localhost:7268/api/Color";
                    var a51 = new HttpClient();
                    var response51 = await a51.GetAsync(requesURL51);
                    string apiData51 = await response51.Content.ReadAsStringAsync();
                    var lst51= JsonConvert.DeserializeObject<List<Color>>(apiData51);

                    var viewModel1 = new BanHangView()
                    {

                        ShoeItems = lst11.Select(s => new SelectListItem
                        {
                            Value = s.id.ToString(),
                            Text = s.name.ToString()
                        }).ToList(),
                        SizeItems = lst21.Select(s => new SelectListItem
                        {
                            Value = s.id.ToString(),
                            Text = s.name.ToString()
                        }).ToList(),
                        CategoryItems = lst31.Select(s => new SelectListItem
                        {
                            Value = s.id.ToString(),
                            Text = s.name.ToString()
                        }).ToList(),
                        BrandItems = lst41.Select(s => new SelectListItem
                        {
                            Value = s.id.ToString(),
                            Text = s.name.ToString()
                        }).ToList(),
                        ColorItems = lst51.Select(s => new SelectListItem
                        {
                            Value = s.id.ToString(),
                            Text = s.name.ToString()
                        }).ToList(),

                    };
                    return View(viewModel1);
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
