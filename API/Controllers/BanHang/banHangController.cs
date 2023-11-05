using AppAPI.Services;
using MCV.Models;
using MCV.Models.DBnhom6;
using MCV.Services.IService;
using MCV.Services.Service;
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
	 //GET: banHangController
		public DBnhom6TT _db;
        public banHangController()
        {
            _db = new DBnhom6TT();
			_cartDetailService = new CartDetailService();
		_shoeDetailService =new ShoeDetailService();
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
		public bool ThemGioHang(Guid idSP, Guid idSize, int soluong, Guid id,Guid idKhachHang)
		{
			try
			{
				var accnew = _db.Accounts.FirstOrDefault(c => c.id == idKhachHang);
				if (accnew != null)
				{
					var gioHang = _db.Carts.ToList();
					if (gioHang.Where(c => c.AccountId == accnew.id).ToList().Count == 0)
					{
						var a = new Cart()
						{
							id = Guid.Parse("d16ac357-3ced-4c2c-bcdc-d38971214497"),
							AccountId = accnew.id,
							Status = true
						};
						_db.Carts.Add(a);
						_db.SaveChanges();
					}
					{
						var shoedt = _db.ShoeDetail.FirstOrDefault(c=>c.ShoeId==idSP&&c.SizeId==idSize);
						var SP = _db.CartDetail.FirstOrDefault(c => c.ShoeDetailId == shoedt.id);
						if (SP == null)
						{
							var d = new CartDetail()
							{
								id = Guid.NewGuid(),
								ShoeDetailId = shoedt.id,
								CartId = Guid.Parse("d16ac357-3ced-4c2c-bcdc-d38971214497"),
								Quantity = soluong,
							};
							if (_cartDetailService.Create(d))
							{
								var product = _shoeDetailService.GetById(shoedt.id);
								product.Quantity -= soluong;
								if (_shoeDetailService.Update(product))
								{
									return true;
								}
							}
						}
						else
						{
							SP.Quantity += soluong;
							if (_cartDetailService.Update(SP))
							{
								var product = _shoeDetailService.GetById(shoedt.id);
								product.Quantity -= soluong;
								if (_shoeDetailService.Update(product))
								{
									return true;
								}
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

		// POST: banHangController/Create
		