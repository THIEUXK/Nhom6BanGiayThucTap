using AppAPI.Services;
using Data.ViewModel;
using MCV.Models;
using MCV.Models.DBnhom6;
using MCV.Services.IService;
using MCV.Services.Service;
using MCV.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShopOganicAPI.IServices;
using System.Xml.Linq;

namespace API.Controllers.BanHang
{
    public class banHangController : Controller
    {
        public ICartDetailService _cartDetailService;
        public IShoeDetailService _shoeDetailService;
        public ICartService _cartService;

        public IAccountService _accountService;
        public IOrderDetailService _orderDetailService;
        public IOrderService _orderService;
        public IAddressService _addressService;
        //GET: banHangController
        public DBnhom6TT _db;
        public banHangController()
        {
            _db = new DBnhom6TT();
            _addressService= new AddressService();
            _accountService = new AccountService();
            _cartDetailService = new CartDetailService();
            _shoeDetailService = new ShoeDetailService();
            _cartService = new CartService();
            _orderDetailService = new OrderDetailService();
            _orderService = new OrderService();
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
        [HttpPost("HoanThanhThanhToan")]
        // GET: banHangController/Create
        public bool HoanThanhThanhToan(HoanThanhThanhToanView hoanThanhThanhToanView)
        {
            try
            {
                var kach = _accountService.GetById(hoanThanhThanhToanView.IdKhachhang);
                var gh = _cartService.GetAll().FirstOrDefault(c => c.AccountId == hoanThanhThanhToanView.IdKhachhang);
                if (kach != null && gh != null)
                {
                    {
                        //Tạo hóa đơn mới
                        var hd = new Order()
                        {
                            CustomerName = hoanThanhThanhToanView.name,
                            PhoneNumber = hoanThanhThanhToanView.Sodienthoai,
                            ShipFee = hoanThanhThanhToanView.tienship,
                            TotalMoney = hoanThanhThanhToanView.tongtien,
                            Address = hoanThanhThanhToanView.addDiaChi,
                            AccountId = kach.id,
                            PaymentMethodId = hoanThanhThanhToanView.IdPaymentMethod,
                            Status = "Đang chờ xử lí",
                            CreateDate = DateTime.Now,
                            is_delete = true
                        };
                        if (hoanThanhThanhToanView.IdAddress != Guid.Parse("00000000-0000-0000-0000-000000000000"))
                        {
                            hd.AccouAddressId = hoanThanhThanhToanView.IdAddress;
                        }
                        if (_orderService.Create(hd) == false)
                        {
                            return false;
                        }
                        //Thêm chi tiết hóa đơn cho từng sản phẩm trong giỏ hàng
                        foreach (var ct in _cartDetailService.GetAll().Where(c => c.CartId == gh.id))
                        {
                            var cthd = new OrderDetail()
                            {
                                id = Guid.NewGuid(),
                                OrderId = hd.id,
                                //Id của hóa đơn vừa tạo
                                Quantity = ct.Quantity,
                                Price = ct.ShoeDetail.Shoe.PriceOutput,
                                Discount = ct.ShoeDetail.Shoe.PriceOutput,
                                Status = true,
                                ShoeDetailId = ct.ShoeDetailId,
                            };
                            if (_orderDetailService.Create(cthd) == false)
                            {
                                return false;
                            }

                            //Trừ số lượng sản phẩm trong CSDL
                            if (_cartDetailService.Delete(ct.id) == false) //Xóa các bản ghi mà người dùng thêm vào trong giỏ hàng
                            {
                                return false;
                            }

                        }
                        var lisdiachi1 = _addressService.GetAll().Where(c => c.AccountId == kach.id).ToList();
                        var lisdiachi = _addressService.GetAll().Where(c => c.Name == hoanThanhThanhToanView.addDiaChi && c.AccountId == kach.id && c.tienShip == hoanThanhThanhToanView.tienship).ToList();
                        if (lisdiachi1.Count() < 4 && lisdiachi.Count == 0)
                        {
                            var diachi = new Address()
                            {
                                AccountId = kach.id,
                                Name = hoanThanhThanhToanView.addDiaChi,
                                tienShip = hoanThanhThanhToanView.tienship,
                            };
                            _addressService.Create(diachi);
                        }
                        return true;
                    }
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }
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
