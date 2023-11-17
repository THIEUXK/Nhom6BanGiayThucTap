
namespace AppAPI.IServices
{
    public interface IThongKeService
    {
       
        decimal DoanhThuNgay(DateTime date);
        decimal DoanhThuThang(int month, int year);
        decimal DoanhThuNam(int year);
    }
}
