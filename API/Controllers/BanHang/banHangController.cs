using AppAPI.Services;
using MCV.Models;
using MCV.Models.DBnhom6;
using MCV.Services.IService;
using MCV.Services.Service;
using MCV.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShopOganicAPI.IServices;

namespace API.Controllers.BanHang
{
    public class banHangController : Controller
    {
        public ICartDetailService _cartDetailService { get; set; }
        public IShoeDetailService _shoeDetailService { get; set; }
        public ICartService _cartService { get; set; }

        public IAccountService _accountService { get; set; }
        //GET: banHangController
        public DBnhom6TT _db;
        public banHangController()
        {
            _db = new DBnhom6TT();
            _accountService = new AccountService();
            _cartDetailService = new CartDetailService();
            _shoeDetailService = new ShoeDetailService();
            _cartService = new CartService();
        }
        public ActionResult Index()
        {
            return View();
        }

        // GET: banHangController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }
        [HttpPost("ThemGioHang")]
        // GET: banHangController/Create
        public bool ThemGioHang(ThemGioHangView a)
        {
            try
            {
                var accnew = _accountService.GetAll().FirstOrDefault(c => c.id == a.IdKhachHang);
                if (accnew != null)
                {
                    var gioHang = _db.Carts.ToList();
                    if (gioHang.Where(c => c.AccountId == accnew.id).ToList().Count == 0)
                    {
                        var b = new Cart()
                        {
                            id = Guid.NewGuid(),
                            AccountId = accnew.id,
                            Status = true
                        };
                        _cartService.Create(b);
                    }

                    var shoedt = _shoeDetailService.GetAll().FirstOrDefault(c => c.ShoeId == a.idSP && c.SizeId == a.idSize);
                    var SP = _cartDetailService.GetAll().FirstOrDefault(c => c.ShoeDetailId == shoedt.id);
                    if (SP == null)
                    {
                        var d = new CartDetail()
                        {
                            id = Guid.NewGuid(),
                            ShoeDetailId = shoedt.id,
                            CartId = _cartService.GetAll().FirstOrDefault(c => c.AccountId == accnew.id).id,
                            Quantity = a.soluong,
                        };
                        if (_cartDetailService.Create(d))
                        {
                            var product = _shoeDetailService.GetById(shoedt.id);
                            product.Quantity -= a.soluong;
                            if (_shoeDetailService.Update(product))
                            {
                                return true;
                            }
                        }
                    }
                    else
                    {
                        SP.Quantity += a.soluong;
                        if (_cartDetailService.Update(SP))
                        {
                            var product = _shoeDetailService.GetById(shoedt.id);
                            product.Quantity -= a.soluong;
                            if (_shoeDetailService.Update(product))
                            {
                                return true;
                            }
                        }
                    }


                    return false;
                }
                else
                    return false;
            }
            catch
            {
                return false;
            }
            //var accnew = SessionServices.KhachHangSS(HttpContext.Session, "ACC");
            //if (accnew.Count != 0)
            //{
            //	var tkmoi = accnew[0];
            //	var gioHang = _GioHang.GetAll();
            //	if (gioHang.Where(c => c.IdKhachHang == tkmoi.Id).ToList().Count == 0)
            //	{
            //		_GioHang.Clean(tkmoi.Id);
            //		var a = new GioHang()
            //		{
            //			Id = Guid.Parse("d16ac357-3ced-4c2c-bcdc-d38971214497"),
            //			IdKhachHang = tkmoi.Id,
            //			TrangThai = true
            //		};
            //		_GioHang.Them(a);
            //	}
            //	{
            //		var SP = _GioHangChiTiet.GetAll().FirstOrDefault(c => c.IdSanPhamChiTiet == idSP);
            //		if (SP == null)
            //		{
            //			var d = new GioHangChiTiet()
            //			{
            //				Id = Guid.NewGuid(),
            //				IdSanPhamChiTiet = idSP,
            //				IdGioHang = Guid.Parse("d16ac357-3ced-4c2c-bcdc-d38971214497"),
            //				SoLuong = soluong,
            //			};
            //			if (_GioHangChiTiet.Them(d))
            //			{
            //				var product = _sanPhamCuaHangService.GetById(idSP);
            //				product.SoLuong -= soluong;
            //				if (_SanPhamChiTiet.Sua(product))
            //				{
            //					return RedirectToAction("GioHang");
            //				}
            //			}
            //		}
            //		else
            //		{
            //			SP.SoLuong += soluong;
            //			if (_GioHangChiTiet.Sua(SP))
            //			{
            //				var product = _sanPhamCuaHangService.GetById(idSP);
            //				product.SoLuong -= soluong;
            //				if (_SanPhamChiTiet.Sua(product))
            //				{
            //					return RedirectToAction("GioHang");
            //				}
            //			}
            //		}
            //	}

            //	var e = _sanPhamCuaHangService.GetById(idSP);

            //	return RedirectToAction("HienThiSanPhamChiTiet", "HienThiSanPham", e);

            //}
            //else
            //{
            //	var gioHang = _GioHang.GetAll();
            //	if (gioHang.Count == 0)
            //	{
            //		var a = new GioHang()
            //		{
            //			Id = Guid.Parse("d16ac357-3ced-4c2c-bcdc-d38971214498"),
            //			TrangThai = true
            //		};
            //		_GioHang.Them(a);
            //	}
            //	{
            //		var SP = _GioHangChiTiet.GetAll().FirstOrDefault(c => c.IdSanPhamChiTiet == idSP);
            //		if (SP == null)
            //		{
            //			var d = new GioHangChiTiet()
            //			{
            //				Id = Guid.NewGuid(),
            //				IdSanPhamChiTiet = idSP,
            //				IdGioHang = Guid.Parse("d16ac357-3ced-4c2c-bcdc-d38971214498"),
            //				SoLuong = soluong,
            //			};
            //			if (_GioHangChiTiet.Them(d))
            //			{
            //				var product = _sanPhamCuaHangService.GetById(idSP);
            //				product.SoLuong -= soluong;
            //				if (_SanPhamChiTiet.Sua(product))
            //				{
            //					return RedirectToAction("GioHang");
            //				}
            //			}
            //		}
            //		else
            //		{
            //			SP.SoLuong += soluong;
            //			if (_GioHangChiTiet.Sua(SP))
            //			{
            //				var product = _sanPhamCuaHangService.GetById(idSP);
            //				product.SoLuong -= soluong;
            //				if (_SanPhamChiTiet.Sua(product))
            //				{
            //					return RedirectToAction("GioHang");
            //				}
            //			}
            //		}
            //	}

            //	var c = _sanPhamCuaHangService.GetById(idSP);

            //	return RedirectToAction("HienThiSanPhamChiTiet", "HienThiSanPham", c);
        }
    }
}

// POST: banHangController/Create
