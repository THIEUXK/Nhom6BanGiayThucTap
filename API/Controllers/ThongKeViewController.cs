
//using AppData.ViewModels;
//using AppData.ViewModels.ThongKe;
//using MCV.Models.DBnhom6;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.EntityFrameworkCore;

//// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

//namespace AppAPI.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class ThongKeViewController : ControllerBase
//    {
//        private readonly DBnhom6TT _dbContext;
//        public ThongKeViewController()
//        {
//            _dbContext = new DBnhom6TT();
//        }
//        //GET: api/<ThongKeViewController>
//        [HttpGet("ThongKeMSSanPhamBan")]
//        public List<ThongKeMSSanPhamTheoSoLuong> ThongKeSanPhamMuaSapXep()
//        {
//            var result = _dbContext.OrderDetail
//                .Join(_dbContext.ShoeDetail, cthd => cthd.ShoeDetailId, cts => cts.id, (cthd, cts) => new { ChiTietHoaDon = cthd, ChiTietSanPham = cts })
//                .Join(_dbContext.Shoe, cthd_cts => cthd_cts.ChiTietSanPham.ShoeId, sp => sp.id, (cthd_cts, sp) => new { ChiTietHoaDon_ChiTietSanPham = cthd_cts, SanPham = sp })
//                .Join(_dbContext.Color, cthd_cts_sp => cthd_cts_sp.ChiTietHoaDon_ChiTietSanPham.ChiTietSanPham.ColorId, ms => ms.id, (cthd_cts_sp, ms) => new { ChiTietHoaDon_ChiTietSanPham_SanPham = cthd_cts_sp, MauSac = ms })
//                .Join(_dbContext.Order, cthd_cts_sp_ms => cthd_cts_sp_ms.ChiTietHoaDon_ChiTietSanPham_SanPham.ChiTietHoaDon_ChiTietSanPham.ChiTietHoaDon.OrderId, hd => hd.id, (cthd_cts_sp_ms, hd) => new { ChiTietHoaDon_ChiTietSanPham_SanPham_MauSac = cthd_cts_sp_ms, HoaDon = hd })
//                .GroupBy(cthd_cts_sp_ms_hd => cthd_cts_sp_ms_hd.ChiTietHoaDon_ChiTietSanPham_SanPham_MauSac.ChiTietHoaDon_ChiTietSanPham_SanPham.SanPham.id)
//                .Select(group => new ThongKeMSSanPhamTheoSoLuong
//                {
//                    idSanPham = group.FirstOrDefault().ChiTietHoaDon_ChiTietSanPham_SanPham_MauSac.ChiTietHoaDon_ChiTietSanPham_SanPham.SanPham.id,
//                    TenSP = group.FirstOrDefault().ChiTietHoaDon_ChiTietSanPham_SanPham_MauSac.ChiTietHoaDon_ChiTietSanPham_SanPham.SanPham.name.Trim().ToString(),
                    
//                    SoLuong = group.Sum(cthd_cts_sp_ms_hd => cthd_cts_sp_ms_hd.ChiTietHoaDon_ChiTietSanPham_SanPham_MauSac.ChiTietHoaDon_ChiTietSanPham_SanPham.ChiTietHoaDon_ChiTietSanPham.ChiTietHoaDon.Quantity),
//                    Gia= group.FirstOrDefault().ChiTietHoaDon_ChiTietSanPham_SanPham_MauSac.ChiTietHoaDon_ChiTietSanPham_SanPham.ChiTietHoaDon_ChiTietSanPham.ChiTietSanPham.GiaBan,
//                    DoanhThu= group.Sum(cthd_cts_sp_ms_hd => cthd_cts_sp_ms_hd.ChiTietHoaDon_ChiTietSanPham_SanPham_MauSac.ChiTietHoaDon_ChiTietSanPham_SanPham.ChiTietHoaDon_ChiTietSanPham.ChiTietHoaDon.Quantity) * group.FirstOrDefault().ChiTietHoaDon_ChiTietSanPham_SanPham_MauSac.ChiTietHoaDon_ChiTietSanPham_SanPham.ChiTietHoaDon_ChiTietSanPham.ChiTietSanPham.GiaBan,
//                    Ngay = group.FirstOrDefault().HoaDon.PayDate.Value
//                })

//                .OrderByDescending(item => item.SoLuong).Where(x=>x.Ngay.Month==DateTime.Now.Month).Take(7)
//                .ToList();

//            return result;
//        }
//        //[HttpGet("ThongKeKHTheoSoLuongHoaDon")]
//        //public List<ThongKeKHMuaNhieu> ThongKeKHTheoSoLuongHoaDon()
//        //{
//        //    var result = _dbContext.LichSuTichDiems
//        //        .Join(_dbContext.HoaDons, lstd => lstd.IDHoaDon, hd => hd.ID, (lstd, hd) => new { LichSuTichDiem = lstd, HoaDon = hd })
//        //        .Join(_dbContext.ChiTietHoaDons, hd_cthd => hd_cthd.HoaDon.ID, cthd => cthd.IDHoaDon, (hd_cthd, cthd) => new { HoaDon_ChiTietHoaDon = hd_cthd, ChiTietHoaDon = cthd })

//        //        .Join(_dbContext.KhachHangs, lstd_kh => lstd_kh.HoaDon_ChiTietHoaDon.LichSuTichDiem.IDKhachHang, kh => kh.IDKhachHang, (lstd_kh, kh) => new { LichSuTichDiem_KhachHang = lstd_kh, KhachHang = kh }).
//        //        Where(x => x.LichSuTichDiem_KhachHang.HoaDon_ChiTietHoaDon.HoaDon.NgayThanhToan.HasValue)
//        //        .GroupBy(x=> new { x.KhachHang.IDKhachHang,x.LichSuTichDiem_KhachHang.HoaDon_ChiTietHoaDon.HoaDon.NgayThanhToan.Value.Month })
//        //        .Select(group => new ThongKeKHMuaNhieu
//        //        {

//        //           idkh=group.FirstOrDefault().KhachHang.IDKhachHang,
//        //           Ten=group.FirstOrDefault().KhachHang.Ten,
//        //           SDT=group.FirstOrDefault().KhachHang.SDT,
//        //           Email=group.FirstOrDefault().KhachHang.Email,
//        //           SoDonMua=group.Sum(x=>x.LichSuTichDiem_KhachHang.HoaDon_ChiTietHoaDon.HoaDon.ID!=null?1:0),
//        //           TongSoTien=group.Sum(x=>x.LichSuTichDiem_KhachHang.HoaDon_ChiTietHoaDon.HoaDon.TienShip+x.LichSuTichDiem_KhachHang.ChiTietHoaDon.DonGia*x.LichSuTichDiem_KhachHang.ChiTietHoaDon.SoLuong),
//        //           Ngay=group.FirstOrDefault().LichSuTichDiem_KhachHang.HoaDon_ChiTietHoaDon.HoaDon.NgayThanhToan.Value
//        //        })

//        //        .OrderByDescending(item => item.TongSoTien).Take(10)
//        //        .ToList();

//        //    return result;

//        //}
//        [HttpGet("ThongKeDoanhThuTheoNgay")]
//        public async Task<IActionResult> ThongKeDoanhThuTheoNgay()
//        {
//            var result = await _dbContext.OrderDetail
//                .Include(ch => ch.Order)
//                .Where(ch => ch.Order.PayDate.HasValue)
//                .GroupBy(ch => ch.Order.PayDate.Value.Date)
//                .Select(group => new ThongKeDoanhThu
//                {
//                    Ngay = group.Key,
//                    SoHoaDon = group.Count(),
//                    DoanhThu = group.Sum(ch => ch.Price * ch.Quantity + ch.Order.ShipFee 
//                })
//                .OrderByDescending(t => t.Ngay.Date)
//                .Where(x => x.Ngay.Date <= DateTime.Today.Date)
//                .Take(7)
//                .ToListAsync();
//            foreach (var item in result)
//            {
//                item.DoanhThu = (decimal)item.DoanhThu;
//            }

//            return Ok(result);
//        }

//        //[HttpGet("LocThongKeDoanhThuTheoNgay")]
//        //public async Task<IActionResult> LocThongKeDoanhThuTheoNgay(DateTime NgayStart,DateTime NgayEnd)
//        //{
//        //    if(NgayStart > NgayEnd)
//        //    {
//        //        return null;
//        //    }
//        //    var result = await _dbContext.OrderDetail
//        //        .Include(ch => ch.Order)
//        //        .Where(ch => ch.Order.PayDate.HasValue)
//        //        .GroupBy(ch => ch.Order.PayDate.Value.Date)
//        //        .Select(group => new ThongKeDoanhThu
//        //        {
//        //            Ngay = group.Key,
//        //            SoHoaDon = group.Count(),
//        //            DoanhThu = Math.Round(group.Sum(ch => ch.Price * ch.Quantity) + group.Sum(ch => ch.Order.ShipFee), 2)
//        //        })
//        //        .OrderByDescending(t => t.Ngay.Date)
//        //        .Where(x=>x.Ngay.Date>=NgayStart.Date&& x.Ngay.Date<=NgayEnd.Date)
//        //        .ToListAsync();
//        //    return Ok(result);
//        //}
//        [HttpGet("ThongKeDoanhThuTheoThang")]
//        public List<ThongKeDoanhThu> ThongKeDoanhThuTheoThang()
//        {
//            var result = _dbContext.OrderDetail
//                .Join(_dbContext.ShoeDetail, cthd => cthd.ShoeDetailId, cts => cts.id, (cthd, cts) => new { ChiTietHoaDon = cthd, ChiTietSanPham = cts })
//                .Join(_dbContext.Shoe, cthd_cts => cthd_cts.ChiTietSanPham.ShoeId, sp => sp.id, (cthd_cts, sp) => new { ChiTietHoaDon_ChiTietSanPham = cthd_cts, SanPham = sp })

//                .Join(_dbContext.Order, cthd_cts_sp_ms => cthd_cts_sp_ms.ChiTietHoaDon_ChiTietSanPham.ChiTietHoaDon.OrderId, hd => hd.id, (cthd_cts_sp_ms, hd) => new { ChiTietHoaDon_ChiTietSanPham_SanPham_MauSac = cthd_cts_sp_ms, HoaDon = hd }).
//                Where(x=>x.HoaDon.PayDate.HasValue)
//                .GroupBy(cthd_cts_sp_ms_hd => cthd_cts_sp_ms_hd.HoaDon.PayDate.Value.Month)
//                .Select(group => new ThongKeDoanhThu
//                {
                   
//                    SoHoaDon = group.Sum(x => x.HoaDon.id != null ? 1 : 0),
//                    DoanhThu = group.Sum(x => x.ChiTietHoaDon_ChiTietSanPham_SanPham_MauSac.ChiTietHoaDon_ChiTietSanPham.ChiTietHoaDon.Price * x.ChiTietHoaDon_ChiTietSanPham_SanPham_MauSac.ChiTietHoaDon_ChiTietSanPham.ChiTietHoaDon.Quantity + Math.Round( x.HoaDon.ShipFee),)
//                    Ngay = group.FirstOrDefault().HoaDon.PayDate.Value
//                })

//                .OrderByDescending(item => item.Ngay.Month).Where(x=>x.Ngay.Month<=DateTime.Today.Month).Take(7)
//                .ToList();
//            return result;
//        }
        
//        //[HttpGet("ThongKeDoanhThuTheoNam")]
//        //public List<ThongKeDoanhThu> ThongKeDoanhThuTheoNam()
//        //{
//        //    var result = _dbContext.OrderDetail
//        //        .Join(_dbContext.ShoeDetail, cthd => cthd.ShoeDetailId, cts => cts.id, (cthd, cts) => new { ChiTietHoaDon = cthd, ChiTietSanPham = cts })
//        //        .Join(_dbContext.Order, cthd_cts => cthd_cts.ChiTietSanPham.ShoeId, sp => sp.id, (cthd_cts, sp) => new { ChiTietHoaDon_ChiTietSanPham = cthd_cts, SanPham = sp })

//        //        .Join(_dbContext.Order, cthd_cts_sp_ms => cthd_cts_sp_ms.ChiTietHoaDon_ChiTietSanPham.ChiTietHoaDon.OrderId, hd => hd.id, (cthd_cts_sp_ms, hd) => new { ChiTietHoaDon_ChiTietSanPham_SanPham_MauSac = cthd_cts_sp_ms, HoaDon = hd })
//        //        .Where(x => x.HoaDon.PayDate.HasValue)
//        //        .GroupBy(cthd_cts_sp_ms_hd => cthd_cts_sp_ms_hd.HoaDon.PayDate.Value.Year)
//        //        .Select(group => new ThongKeDoanhThu
//        //        {
                    
//        //            SoHoaDon = group.Sum(x => x.HoaDon.id != null ? 1 : 0),
//        //            DoanhThu = group.Sum(x => x.ChiTietHoaDon_ChiTietSanPham_SanPham_MauSac.ChiTietHoaDon_ChiTietSanPham.ChiTietHoaDon.Price * x.ChiTietHoaDon_ChiTietSanPham_SanPham_MauSac.ChiTietHoaDon_ChiTietSanPham.ChiTietHoaDon.Quantity + x.HoaDon.ShipFee),
//        //            Ngay = group.FirstOrDefault().HoaDon.PayDate.Value
//        //        })

//        //        .OrderByDescending(item => item.Ngay.Year).Take(10)
//        //        .ToList();

//        //    return result;
//        //}

//        // thong ke So CTSP da ban
        
//        [HttpGet("ThongKeTongDTTrongThang")]
//        public ThongKeDTTrongThang TongDoanhThu()
//        {
//            var tim = _dbContext.OrderDetail
//                .Join(_dbContext.Order, cthd => cthd.OrderId, hd => hd.id, (cthd, hd) => new { ChiTietHoaDon = cthd, HoaDon = hd }).
//                Where(x => x.HoaDon.PayDate.HasValue)
//                .GroupBy(x => x.HoaDon.PayDate.Value.Month).
//                Select(group => new ThongKeDTTrongThang
//                {
//                    TongTien = group.Sum(x => x.ChiTietHoaDon.Quantity * x.ChiTietHoaDon.Price + x.HoaDon.ShipFee ),
//                    Ngay = group.FirstOrDefault().HoaDon.PayDate.Value
//                }).Where(x => x.Ngay.Month == DateTime.Now.Month).FirstOrDefault();
//            return tim;
//        }
//        [HttpGet("ThongKeSoDonTrongThang")]
//        public ThongKeSDonTrongThang TongSoDon()
//        {
//            var tim = _dbContext.OrderDetail
//                .Join(_dbContext.Order, cthd => cthd.OrderId, hd => hd.id, (cthd, hd) => new { ChiTietHoaDon = cthd, HoaDon = hd }).
//                Where(x => x.HoaDon.PayDate.HasValue)
//                .GroupBy(x => x.HoaDon.PayDate.Value.Month).
//                Select(group => new ThongKeSDonTrongThang
//                {
//                    SoDon = group.Sum(x=>x.HoaDon.id!=null?1:0),
//                    Ngay = group.FirstOrDefault().HoaDon.PayDate.Value
//                }).Where(x => x.Ngay.Month == DateTime.Now.Month).FirstOrDefault();
//            return tim;
//        }
//    }



//}

