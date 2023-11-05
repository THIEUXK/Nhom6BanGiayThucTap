using MCV.Models;
using MCV.Services;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace MCV.Controllers.ThieuxkLoggin
{
	public class DangNhapController : Controller
	{
		
        public IActionResult Index()
		{
			return View();
		}
		public async Task<IActionResult> CheckDangNhapAsync(string TK, string MK)
		{
			string requesURL = $"https://localhost:7268/api/Account";
			var httpClient = new HttpClient();
			var response = await httpClient.GetAsync(requesURL);
			string apiData = await response.Content.ReadAsStringAsync();
			var lst = JsonConvert.DeserializeObject<List<Account>>(apiData);

			var lisacc = lst;
			var ac = lisacc.FirstOrDefault(c => c.Name == TK && c.Password == MK && c.RoleId == Guid.Parse("d16ac357-3ced-4c2c-bcdc-d38971214416"));
			if (TK == null || MK == null)
			{
				var message = "hãy nhập tài khoản mất khẩu của bạn của bạn !";
				TempData["TB1"] = message;
				return RedirectToAction("Index", new { message });
			}
			else if (ac != null)
			{
				var accnew = SessionServices.LuuAcc(HttpContext.Session, "ACC1");
				if (accnew.Count == 0)
				{
					accnew.Add(ac);
					SessionServices.SetObjToJson(HttpContext.Session, "ACC1", accnew);
				}
				else if (accnew.Count != 0)
				{
					accnew.Clear();
					accnew.Add(ac);
					SessionServices.SetObjToJson(HttpContext.Session, "ACC1", accnew);
				}
				var message = "Đăng nhập thành công";
				TempData["TB2"] = message;
				return RedirectToAction("Index", new { message });
			}
			else
			{
				var message = "Tài khoản hoặc mật khẩu không chính xác";
				TempData["TB3"] = message;
				return RedirectToAction("Index", new { message });
			}
		}
	}
}
