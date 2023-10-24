using MCV.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace MCV.Controllers
{
    public class BanHangController : Controller
    {
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


			var view = (from s in lst
				join a in lst1 on s.ShoeId equals a.id
				join b in lst2 on s.SizeId equals b.id
				join c in lst3 on s.CategoryId equals c.id
				join d in lst4 on s.BrandId equals d.id
				join e in lst5 on s.ColorId equals e.id
						select new
				{
					ShoeDetail=s
				});



			return View((IEnumerable<ShoeDetail>)view);
        }
		public async Task<IActionResult> HienThiSanPhamChiTiet()
		{
			return View();
		}

	}
}
