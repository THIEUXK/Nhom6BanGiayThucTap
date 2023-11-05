using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace View_Admin.Controllers
{
    [Area("admin")]
    public class MenuController : Controller
    {
        private readonly ILogger<MenuController> _logger;

        public MenuController(ILogger<MenuController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult BangQuanLy()
        {
            return View();
        }

        public IActionResult DangNhap()
        {
            return View();
        }
        public async Task<IActionResult> logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            var url = Url.Action("login", "Home", new { area = "" });
            return Redirect(url);
        }



    }
}