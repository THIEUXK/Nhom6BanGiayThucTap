
namespace AppAPI.IServices
{
    public interface IThongKeKhachHangService
    {
        int KhachHangMoiTheoNgay(DateTime date);
        int KhachHangCuTheoNgay(DateTime date);
        int KhachHangMoiTheoThang(int month, int year);
        int KhachHangCuTheoThang(int month,int  year);
        int KhachHangCuTheoNam(int year);
        int KhachHangMoiTheoNam(int year);
        //IEnumerable<ChiTietHoaDon> TongKhachHangTrongNgay(DateTime date);
        //IEnumerable<ChiTietHoaDon> TongKhachHangMuaTrongThang(int month, int year);
        //IEnumerable<ChiTietHoaDon> TongKhachHangMuaTrongNam(int year);
    }
}
