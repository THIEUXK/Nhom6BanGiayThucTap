using AppAPI.IServices;
using AppData.IRepositories;
using AppData.Repositories;
using MCV.Models;
using MCV.Models.DBnhom6;

namespace AppAPI.Services
{
    public class ThongKeService : IThongKeService
    {
        private readonly IAllRepository <Order> repos;
        DBnhom6TT context = new DBnhom6TT();
        public ThongKeService()
        {
            repos = new AllRepository<Order>(context,context.Order);
        }
        public decimal DoanhThuNam(int year)
        {
            var nam = context.Order.Where(hd => hd.CreateDate.Year == year).ToList();
            decimal total = (decimal) nam.Sum(hd => hd.ShipFee);
            return total;
        }

        public decimal DoanhThuNgay(DateTime date)
        {
            var ngay = context.Order.Where(hd => hd.CreateDate.Date == date.Date).ToList();
            decimal total = (decimal)ngay.Sum(hd => hd.ShipFee);
            return total;
        }

        public decimal DoanhThuThang(int month, int year)
        {
            var thang = context.Order.Where(hd => hd.CreateDate.Month == month && hd.CreateDate.Year == year).ToList();
            decimal total = (decimal) thang.Sum(hd => hd.ShipFee);
            return total;
        }

    }
}
