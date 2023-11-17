//using AppAPI.IServices;
//using AppData.Models;
//using Microsoft.AspNetCore.Authorization;
//using Microsoft.EntityFrameworkCore;

//namespace AppAPI.Services
//{
//    public class ThongKeSanPhamService : IThongKeSanPhamService
//    {
//        private readonly AssignmentDBContext context;

//        public ThongKeSanPhamService(AssignmentDBContext context)
//        {
//            this.context = context;
//        }

//        public async Task<List<SanPham>> Top10SanPhamTrongNam(int year)
//        {
//            var top = await context.ChiTietHoaDons.Include(a => a.ChiTietSanPham).Include(a => a.ChiTietSanPham.SanPham).Where(a => a.HoaDon.NgayTao.Year == year).GroupBy(a => a.ChiTietSanPham.SanPham).OrderByDescending(a => a.Sum(s => s.SoLuong)).Select(a => a.Key).Take(10).ToListAsync();
//            return top;
//        }

//        public async Task<List<SanPham>> Top10SanPhamTrongNgay(DateTime date)
//        {
//            var top = await context.ChiTietHoaDons.Include(a => a.ChiTietSanPham).Include(a => a.ChiTietSanPham.SanPham).Where(a => a.HoaDon.NgayTao.Date == date.Date ).GroupBy(a=>a.ChiTietSanPham.SanPham).OrderByDescending(a=>a.Sum(s=>s.SoLuong)).Select(a=>a.Key).Take(10).ToListAsync();   return top;
//        }

//        public async Task<List<SanPham>>Top10SanPhamTrongThang(int month, int year)
//        {
//            var top = await context.ChiTietHoaDons.Include(a => a.ChiTietSanPham).Include(a => a.ChiTietSanPham.SanPham).Where(a => a.HoaDon.NgayTao.Month == month && a.HoaDon.NgayTao.Year== year).GroupBy(a => a.ChiTietSanPham.SanPham).OrderByDescending(a => a.Sum(s => s.SoLuong)).Select(a => a.Key).Take(10).ToListAsync(); return top;
//        }
//    }
//}
