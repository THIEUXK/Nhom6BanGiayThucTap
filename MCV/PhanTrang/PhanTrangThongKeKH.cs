using AppData.ViewModels;
using AppData.ViewModels.ThongKe;

namespace AppView.PhanTrang
{
    public class PhanTrangThongKeKH
    {
        public IEnumerable<ThongKeKHMuaNhieu> listkhs { get; set; } = new List<ThongKeKHMuaNhieu>();
        public PagingInfo PagingInfo { get; set; } = new PagingInfo();
    }
}
