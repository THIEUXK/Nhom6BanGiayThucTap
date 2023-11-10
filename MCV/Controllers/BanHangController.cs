using MCV.Migrations;
using MCV.Models;
using MCV.Services;
using MCV.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;

namespace MCV.Controllers
{
    public class BanHangController : Controller
    {
        private readonly HttpClient _httpClient;
        public BanHangController()
        {
            _httpClient = new HttpClient();
            _httpClient.DefaultRequestHeaders.Add("token", "fa31ddca-73b0-11ee-b394-8ac29577e80e");
            _httpClient.DefaultRequestHeaders.Add("shop_id", "4189141");
        }
        public async Task<IActionResult> ThuTucThanhToan()
        {
            HttpResponseMessage responseProvin = _httpClient.GetAsync("https://online-gateway.ghn.vn/shiip/public-api/master-data/province").Result;

            Provin lstprovin = new Provin();

            if (responseProvin.IsSuccessStatusCode)
            {
                string jsonData2 = responseProvin.Content.ReadAsStringAsync().Result;
                lstprovin = JsonConvert.DeserializeObject<Provin>(jsonData2);
                ViewBag.Provin = new SelectList(lstprovin.data, "ProvinceID", "ProvinceName");
            }

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

            string requesURL6 = $"https://localhost:7268/api/CartDetail";
            var httpClient6 = new HttpClient();
            var response6 = await httpClient6.GetAsync(requesURL6);
            string apiData6 = await response6.Content.ReadAsStringAsync();
            var lst6 = JsonConvert.DeserializeObject<List<CartDetail>>(apiData6);

            string requesURL7 = $"https://localhost:7268/api/Cart";
            var httpClient7 = new HttpClient();
            var response7 = await httpClient7.GetAsync(requesURL7);
            string apiData7 = await response7.Content.ReadAsStringAsync();
            var lst7 = JsonConvert.DeserializeObject<List<Cart>>(apiData7);



            List<GioHangHungView> gioHang = (from s in lst6
                                             join a in lst on s.ShoeDetailId equals a.id
                                             join b in lst1 on a.ShoeId equals b.id
                                             join c in lst2 on a.SizeId equals c.id
                                             join d in lst3 on a.CategoryId equals d.id
                                             join e in lst4 on a.BrandId equals e.id
                                             join f in lst5 on a.ColorId equals f.id
                                             join g in lst7 on s.CartId equals g.id
                                             select new GioHangHungView()
                                             {
                                                 CartDetail = s,
                                                 ShoeDetail = a,
                                                 Shoes = b,
                                                 Sizes = c,
                                                 Categories = d,
                                                 Brands = e,
                                                 Color = f,
                                                 Cart = g
                                             }).ToList();
            var acc = SessionServices.LuuAcc(HttpContext.Session, "ACC1");
            if (acc.Count == 0)
            {
                return RedirectToAction("Index", "DangNhap");
            }

            string requesURL8 = $"https://localhost:7268/api/PaymentMethod";
            var httpClient8 = new HttpClient();
            var response8 = await httpClient8.GetAsync(requesURL8);
            string apiData8 = await response8.Content.ReadAsStringAsync();
            var lst8 = JsonConvert.DeserializeObject<List<PaymentMethod>>(apiData8);

            string requesURL9 = $"https://localhost:7268/api/Address";
            var httpClient9 = new HttpClient();
            var response9 = await httpClient9.GetAsync(requesURL9);
            string apiData9 = await response9.Content.ReadAsStringAsync();
            var lst9 = JsonConvert.DeserializeObject<List<Address>>(apiData9);


            var gh = lst7.FirstOrDefault(c => c.AccountId == acc[0].id);
            List<GioHangHungView> ghct = gioHang.Where(c => c.CartDetail.CartId == gh.id).ToList();
            float tong = 0;
            foreach (var x in ghct)
            {
                tong += x.Shoes.PriceOutput * (x.CartDetail.Quantity);

            }


            ListGioHangView view = new ListGioHangView()
            {
                gioHangHungViews = gioHang.Where(c => c.Cart.AccountId == acc[0].id).ToList(),
                PaymentMethodItems = lst8.Select(s => new SelectListItem
                {
                    Value = s.id.ToString(),
                    Text = s.Method.ToString()
                }).ToList(),
                AddressItems = lst9.Where(c => c.AccountId == acc[0].id).Select(s => new SelectListItem
                {
                    Value = s.id.ToString(),
                    Text = s.Name.ToString() + " " + s.SpecificAddress.ToString()
                }).ToList(),
                Account = acc[0],

                address = lst9.FirstOrDefault(c => c.AccountId == acc[0].id && c.Note == "1"),
                Tong = tong,
            };

            return View(view);
        }
        [HttpGet("CheckOut/GetListDistrict")]
        public JsonResult GetListDistrict(int idProvin)
        {

            HttpResponseMessage responseDistrict = _httpClient.GetAsync("https://online-gateway.ghn.vn/shiip/public-api/master-data/district?province_id=" + idProvin).Result;

            District lstDistrict = new District();

            if (responseDistrict.IsSuccessStatusCode)
            {
                string jsonData2 = responseDistrict.Content.ReadAsStringAsync().Result;

                lstDistrict = JsonConvert.DeserializeObject<District>(jsonData2);
            }
            return Json(lstDistrict, new System.Text.Json.JsonSerializerOptions());
        }
        //Lấy địa chỉ phường xã
        [HttpGet("/CheckOut/GetListWard")]
        public JsonResult GetListWard(int idWard)
        {


            HttpResponseMessage responseWard = _httpClient.GetAsync("https://online-gateway.ghn.vn/shiip/public-api/master-data/ward?district_id=" + idWard).Result;

            Ward lstWard = new Ward();

            if (responseWard.IsSuccessStatusCode)
            {
                string jsonData2 = responseWard.Content.ReadAsStringAsync().Result;

                lstWard = JsonConvert.DeserializeObject<Ward>(jsonData2);
            }
            return Json(lstWard, new System.Text.Json.JsonSerializerOptions());
        }
        [HttpPost("/CheckOut/GetTotalShipping")]
        public async Task<JsonResult> GetTotalShipping([FromBody] ShippingOrder shippingOrder)
        {
            var acc = SessionServices.LuuAcc(HttpContext.Session, "ACC1");

          
            var hang = new TinhTienShip()
            {
                service_id = shippingOrder.service_id,
                insurance_value = shippingOrder.insurance_value,
                from_district_id = shippingOrder.from_district_id,
                to_district_id = shippingOrder.to_district_id,
                to_ward_code = shippingOrder.to_ward_code.ToString(),
                height = shippingOrder.height,
                length = shippingOrder.length,
                weight = shippingOrder.weight,
                width = shippingOrder.width,
            };
            var url = $"https://online-gateway.ghn.vn/shiip/public-api/v2/shipping-order/fee";

            var content = new StringContent(JsonConvert.SerializeObject(hang), Encoding.UTF8, "application/json");

            var respose = await _httpClient.PostAsync(url, content);
            float tong = 0;


            if (acc.Count != 0)
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

                string requesURL6 = $"https://localhost:7268/api/CartDetail";
                var httpClient6 = new HttpClient();
                var response6 = await httpClient6.GetAsync(requesURL6);
                string apiData6 = await response6.Content.ReadAsStringAsync();
                var lst6 = JsonConvert.DeserializeObject<List<CartDetail>>(apiData6);

                string requesURL7 = $"https://localhost:7268/api/Cart";
                var httpClient7 = new HttpClient();
                var response7 = await httpClient7.GetAsync(requesURL7);
                string apiData7 = await response7.Content.ReadAsStringAsync();
                var lst7 = JsonConvert.DeserializeObject<List<Cart>>(apiData7);


                List<GioHangHungView> gioHang = (from s in lst6
                                                 join a in lst on s.ShoeDetailId equals a.id
                                                 join b in lst1 on a.ShoeId equals b.id
                                                 join c in lst2 on a.SizeId equals c.id
                                                 join d in lst3 on a.CategoryId equals d.id
                                                 join e in lst4 on a.BrandId equals e.id
                                                 join f in lst5 on a.ColorId equals f.id
                                                 join g in lst7 on s.CartId equals g.id
                                                 select new GioHangHungView()
                                                 {
                                                     CartDetail = s,
                                                     ShoeDetail = a,
                                                     Shoes = b,
                                                     Sizes = c,
                                                     Categories = d,
                                                     Brands = e,
                                                     Color = f,
                                                     Cart = g
                                                 }).ToList();

             
                var gh = lst7.FirstOrDefault(c => c.AccountId == acc[0].id);
                List<GioHangHungView> ghct = gioHang.Where(c => c.CartDetail.CartId == gh.id).ToList();

                foreach (var x in ghct)
                {
                    tong += x.Shoes.PriceOutput * (x.CartDetail.Quantity);

                }
                Shipping shipping = new Shipping();
                if (respose.IsSuccessStatusCode)
                {
                    string jsonData2 = respose.Content.ReadAsStringAsync().Result;

                    shipping = JsonConvert.DeserializeObject<Shipping>(jsonData2);
                    HttpContext.Session.SetInt32("shiptotal", shipping.data.total);
                    shipping.data.totaloder = tong + shipping.data.total;

                    //shipping.data.totaloder = shipping.data.total + int.Parse(tong.ToString());
                    return Json(shipping, new System.Text.Json.JsonSerializerOptions());
                }
                else
                {
                    shipping.message = "False";

                    //shipping.data.totaloder = shipping.data.total + int.Parse(tong.ToString());
                    return Json(shipping, new System.Text.Json.JsonSerializerOptions());
                }

                //Shipping shipping = new Shipping()
                //{
                //    = tong + 52000
                //};


            }
            else
            {
                return Json(0, new System.Text.Json.JsonSerializerOptions());

            }


        }

        [HttpGet("/CheckOut/chonDiaChi")]
        public async Task<JsonResult> chonDiaChi(/*[FromBody] ShippingOrder shippingOrder*/)
        {

            float tong = 0;
            var acc = SessionServices.LuuAcc(HttpContext.Session, "ACC1");

            if (acc.Count != 0)
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

                string requesURL6 = $"https://localhost:7268/api/CartDetail";
                var httpClient6 = new HttpClient();
                var response6 = await httpClient6.GetAsync(requesURL6);
                string apiData6 = await response6.Content.ReadAsStringAsync();
                var lst6 = JsonConvert.DeserializeObject<List<CartDetail>>(apiData6);

                string requesURL7 = $"https://localhost:7268/api/Cart";
                var httpClient7 = new HttpClient();
                var response7 = await httpClient7.GetAsync(requesURL7);
                string apiData7 = await response7.Content.ReadAsStringAsync();
                var lst7 = JsonConvert.DeserializeObject<List<Cart>>(apiData7);


                List<GioHangHungView> gioHang = (from s in lst6
                                                 join a in lst on s.ShoeDetailId equals a.id
                                                 join b in lst1 on a.ShoeId equals b.id
                                                 join c in lst2 on a.SizeId equals c.id
                                                 join d in lst3 on a.CategoryId equals d.id
                                                 join e in lst4 on a.BrandId equals e.id
                                                 join f in lst5 on a.ColorId equals f.id
                                                 join g in lst7 on s.CartId equals g.id
                                                 select new GioHangHungView()
                                                 {
                                                     CartDetail = s,
                                                     ShoeDetail = a,
                                                     Shoes = b,
                                                     Sizes = c,
                                                     Categories = d,
                                                     Brands = e,
                                                     Color = f,
                                                     Cart = g
                                                 }).ToList();

                var gh = lst7.FirstOrDefault(c => c.AccountId == acc[0].id);
                List<GioHangHungView> ghct = gioHang.Where(c => c.CartDetail.CartId == gh.id).ToList();

                foreach (var x in ghct)
                {
                    tong += x.Shoes.PriceOutput * (x.CartDetail.Quantity);

                }
                Shipping shipping = new Shipping()
                {
                    totaloder = tong + 52000
                };

                //shipping.data.totaloder = shipping.data.total + int.Parse(tong.ToString());
                return Json(shipping.totaloder, new System.Text.Json.JsonSerializerOptions());

            }
            return Json(0, new System.Text.Json.JsonSerializerOptions());

        }
        public async Task<IActionResult> HienThiSanPham()
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



            return View(lst1);
        }
        public async Task<IActionResult> HienThiSanPhamChiTiet(Guid id)
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


            var lisanh = (from s in lst51
                          join a in lst on s.ShoeDetailId equals a.id
                          join b in lst1 on a.ShoeId equals b.id
                          select new listanhview()
                          {
                              Image = s,
                              ShoeDetail = a,
                              Shoes = b,

                          }).ToList();


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

            var sizeSP = view.Where(c => c.ShoeDetail.ShoeId == id).ToList();
            var shoe = lst1.FirstOrDefault(c => c.id == id);
            var acc = SessionServices.LuuAcc(HttpContext.Session, "ACC1");
            ChiTietSanPhamBanvView viewCT = new ChiTietSanPhamBanvView()
            {
                SizeItems = sizeSP.Select(s => new SelectListItem
                {
                    Value = s.Sizes.id.ToString(),
                    Text = s.Sizes.name.ToString()
                }).ToList(),
                listanhviews = lisanh.Where(c => c.ShoeDetail.ShoeId == id).ToList(),
                BanHangViews = sizeSP,
                Shoe = shoe,
            };
            return View(viewCT);
        }
        public async Task<IActionResult> ChonSize(Guid idSize, Guid id)
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


            var lisanh = (from s in lst51
                          join a in lst on s.ShoeDetailId equals a.id
                          join b in lst1 on a.ShoeId equals b.id
                          select new listanhview()
                          {
                              Image = s,
                              ShoeDetail = a,
                              Shoes = b,

                          }).ToList();


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

            var sizeSP = view.Where(c => c.ShoeDetail.ShoeId == id).ToList();
            var shoe = lst1.FirstOrDefault(c => c.id == id);
            var acc = SessionServices.LuuAcc(HttpContext.Session, "ACC1");
            if (acc.Count == 0)
            {
                return RedirectToAction("Index", "DangNhap");
            }
            ChiTietSanPhamBanvView viewCT = new ChiTietSanPhamBanvView()
            {
                SizeItems = sizeSP.Select(s => new SelectListItem
                {
                    Value = s.Sizes.id.ToString(),
                    Text = s.Sizes.name.ToString()
                }).ToList(),
                listanhviews = lisanh.Where(c => c.ShoeDetail.ShoeId == id).ToList(),
                BanHangViews = sizeSP,
                SizeId = idSize,
                ThongtinCt = sizeSP.FirstOrDefault(c => c.Sizes.id == idSize),
                Shoe = shoe,
                Account = acc[0]
            };
            return View("HienThiSanPhamChiTiet", viewCT);
        }
        public async Task<IActionResult> GioHang()
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

            string requesURL6 = $"https://localhost:7268/api/CartDetail";
            var httpClient6 = new HttpClient();
            var response6 = await httpClient6.GetAsync(requesURL6);
            string apiData6 = await response6.Content.ReadAsStringAsync();
            var lst6 = JsonConvert.DeserializeObject<List<CartDetail>>(apiData6);

            string requesURL7 = $"https://localhost:7268/api/Cart";
            var httpClient7 = new HttpClient();
            var response7 = await httpClient7.GetAsync(requesURL7);
            string apiData7 = await response7.Content.ReadAsStringAsync();
            var lst7 = JsonConvert.DeserializeObject<List<Cart>>(apiData7);

            

            List<GioHangHungView> gioHang = (from s in lst6
                                             join a in lst on s.ShoeDetailId equals a.id
                                             join b in lst1 on a.ShoeId equals b.id
                                             join c in lst2 on a.SizeId equals c.id
                                             join d in lst3 on a.CategoryId equals d.id
                                             join e in lst4 on a.BrandId equals e.id
                                             join f in lst5 on a.ColorId equals f.id
                                             join g in lst7 on s.CartId equals g.id
                                             select new GioHangHungView()
                                             {
                                                 CartDetail = s,
                                                 ShoeDetail = a,
                                                 Shoes = b,
                                                 Sizes = c,
                                                 Categories = d,
                                                 Brands = e,
                                                 Color = f,
                                                 Cart = g
                                             }).ToList();
            var acc = SessionServices.LuuAcc(HttpContext.Session, "ACC1");
            if (acc.Count == 0)
            {
                return RedirectToAction("Index", "DangNhap");
            }
            var gh = lst7.FirstOrDefault(c => c.AccountId == acc[0].id);
            List<GioHangHungView> ghct = gioHang.Where(c => c.CartDetail.CartId == gh.id).ToList();
            float tong = 0;
            foreach (var x in ghct)
            {
                tong += x.Shoes.PriceOutput * (x.CartDetail.Quantity);

            }
            ListGioHangView view = new ListGioHangView()
            {
                gioHangHungViews = gioHang.Where(c => c.Cart.AccountId == acc[0].id).ToList(),
                Tong=tong
            };

            return View(view);
        }
        public async Task<IActionResult> ThemVaoGio(Guid idSP, Guid idSize, int soluong, Guid IdKhachHang)
        {
            if (IdKhachHang != Guid.Parse("00000000-0000-0000-0000-000000000000"))
            {
                if (idSize == Guid.Parse("00000000-0000-0000-0000-000000000000") || idSP == Guid.Parse("00000000-0000-0000-0000-000000000000"))
                {
                    var message = "hãy chọn size của bạn !";
                    TempData["ErrorMessage"] = message;
                    return RedirectToAction("HienThiSanPhamChiTiet", new { id = idSP, message });
                }
                else if (soluong == null || soluong <= 0)
                {
                    var message = "hãy kiểm tra lại số lượng của bạn !";
                    TempData["soluong"] = message;
                    return RedirectToAction("HienThiSanPhamChiTiet", new { id = idSP, message });
                }
                else
                {
                    try
                    {
                        var a = new ThemGioHangView() { idSP = idSP, idSize = idSize, soluong = soluong, IdKhachHang = IdKhachHang };
                        var url = $"https://localhost:7268/ThemGioHang?idSP={idSP}&idSize={idSize}&soluong={soluong}&IdKhachHang={IdKhachHang}";
                        var httpClient = new HttpClient();
                        var content = new StringContent(JsonConvert.SerializeObject(a), Encoding.UTF8, "application/json");
                        var respose = await httpClient.PostAsync(url, content);
                        if (respose.IsSuccessStatusCode)
                        {

                            var message1 = "Thêm giỏ hàng thành công";
                            TempData["TB1"] = message1;
                            return RedirectToAction("HienThiSanPhamChiTiet", new { id = idSP, message1 });

                        }

                        var message = "Thêm giỏ hàng thất bại";
                        TempData["TB2"] = message;
                        return RedirectToAction("HienThiSanPhamChiTiet", new { id = idSP, message });

                    }
                    catch
                    {
                        var message = "hãy kiểm tra lại !";
                        TempData["soluong"] = message;
                        return RedirectToAction("HienThiSanPhamChiTiet", new { id = idSP, message });
                    }

                }
            }
            else
            {
                var message = "hãy kiểm tra lại !";
                TempData["soluong"] = message;
                return RedirectToAction("HienThiSanPhamChiTiet", new { id = idSP, message });
            }

        }


    }
}
