using MCV.Models;
using MCV.Services;
using MCV.Services.IService;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Security.Claims;
using Newtonsoft.Json;
using System.Text;
using System.Data;

namespace MCV.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private IAccountService _accountService;
        private IRoleService _roleService;
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
            _accountService = new AccountService();
            _roleService = new RoleService();
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult blog()
        {
	        return View();
        }
        public IActionResult cart()
        {
            return View();
        }
        public IActionResult category()
        {
            return View();
        }
        public IActionResult confirmation()
        {
            return View();
        }
        public IActionResult contact()
        {
            return View();
        }
        public IActionResult checkout()
        {
            return View();
        }
        public IActionResult elements()
        {
            return View();
        }

        public IActionResult login()
        {
            ClaimsPrincipal claimsUser = HttpContext.User;
            if (claimsUser.Identity.IsAuthenticated)
                return RedirectToAction("Index");


            return View();
        }
        [HttpPost]
        public async Task< IActionResult> login(string username , string pass )
        {
            var acc = _accountService.GetAll().FirstOrDefault(c=>c.Email == username && c.Password == pass);
            var role = _roleService.GetAll().FirstOrDefault(c=>c.name== "KhachHang");

            if (acc==null) {
            ViewBag.Error = "Sai Tài Khoản Hoặc Mật Khẩu";
       
            }
            
            else if (acc != null&&acc.RoleId==role.id)
            {
                List<Claim> claims = new List<Claim>()
                  {
                      new Claim(ClaimTypes.Name,acc.Name)

                  };
                ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                AuthenticationProperties properties = new AuthenticationProperties()
                {
                    AllowRefresh = true,
                    IsPersistent = true,
                };
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity), properties);
                return RedirectToAction("Index");

            }
     
            else
            {
                List<Claim> claims = new List<Claim>()
                  {
                      new Claim(ClaimTypes.Name,acc.Name),

                  };
                ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                AuthenticationProperties properties = new AuthenticationProperties()
                {
                    AllowRefresh = true,
                    IsPersistent = true,
                };
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity), properties);
                return Redirect("~/Admin/Menu/Index");

            }
            return View();  

        }
        public async Task<IActionResult> logout()
        { 
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return Redirect("~/Home/login");
        }
   
        public IActionResult singleblog()
        {
            return View();
        }
        public IActionResult singleproduct()
        {
            return View();
        }
        public IActionResult tracking()
        {
            return View();
        }

    }
}