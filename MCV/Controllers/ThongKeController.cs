using AppData.ViewModels;
using AppData.ViewModels.ThongKe;
using AppView.PhanTrang;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace AppView.Controllers
{
    public class ThongKeController : Controller
    {
        private readonly HttpClient _httpClient;
        public ThongKeController()
        {
            _httpClient = new HttpClient();
        }
      
        #region Thống Kê Sản Phẩm Được Mua nhiều Theo Ngày, Tháng, Năm 
        [HttpGet]

        public async Task<IActionResult> ThongKeSP()
        {
            string apiUrl = $"https://localhost:7268/api/ThongKeView/ThongKeMSSanPhamBan";

            var response = await _httpClient.GetAsync(apiUrl);
            string apiData = await response.Content.ReadAsStringAsync();
            var ChatLieus = JsonConvert.DeserializeObject<List<ThongKeMSSanPhamTheoSoLuong>>(apiData);

            return View(ChatLieus);
        }
        [HttpGet]
        public async Task<IActionResult> ThongKeSPTheoThang(DateTime? ngay, DateTime? thang, DateTime? nam)
        {

            string apiUrl = $"https://localhost:7268/api/ThongKeView/ThongKeMSSanPhamBan";
            var response = await _httpClient.GetAsync(apiUrl);
            string apiData = await response.Content.ReadAsStringAsync();
            var ChatLieus = JsonConvert.DeserializeObject<List<ThongKeMSSanPhamTheoSoLuong>>(apiData);
            var timkiem = ChatLieus.ToList();

            if (ngay.HasValue)
            {
                timkiem = ChatLieus.Where(x => x.Ngay.Date == ngay.Value.Date && x.Ngay.Month == ngay.Value.Month && x.Ngay.Year == ngay.Value.Year).ToList();
            }
            if (thang.HasValue)
            {
                timkiem = ChatLieus.Where(x => x.Ngay.Month == thang.Value.Month && x.Ngay.Year == thang.Value.Year).ToList();
            }
            if (nam.HasValue)
            {
                timkiem = ChatLieus.Where(x => x.Ngay.Year == nam.Value.Year).ToList();
            }

            return View("ThongKeSP", timkiem);
        }
        #endregion
        #region Thông Kê Khách Hàng Mua Nhiêù Theo Ngày, Tháng , Năm
        public int PageSize = 8;
        [HttpGet]

        public async Task<IActionResult> ThongKeKH(int ProductPage = 1)
        {
            string apiUrl = $"https://localhost:7268/api/ThongKeView/ThongKeKHTheoSoLuongHoaDon";

            var response = await _httpClient.GetAsync(apiUrl);
            string apiData = await response.Content.ReadAsStringAsync();
            var ChatLieus = JsonConvert.DeserializeObject<List<ThongKeKHMuaNhieu>>(apiData);

            return View(new PhanTrangThongKeKH
            {
                listkhs = ChatLieus
                        .Skip((ProductPage - 1) * PageSize).Take(PageSize),
                PagingInfo = new PagingInfo
                {
                    ItemsPerPage = PageSize,
                    CurrentPage = ProductPage,
                    TotalItems = ChatLieus.Count()
                }

            }
                );
        }
        [HttpGet]
        public async Task<IActionResult> ThongKeSPKHTheoThang(DateTime ThangStart, DateTime ThangEnd, int ProductPage = 1)
        {

            string apiUrl = $"https://localhost:7268/api/ThongKeView/ThongKeKHTheoSoLuongHoaDon";
            var response = await _httpClient.GetAsync(apiUrl);
            string apiData = await response.Content.ReadAsStringAsync();
            var ChatLieus = JsonConvert.DeserializeObject<List<ThongKeKHMuaNhieu>>(apiData);
            var timkiem = ChatLieus.ToList();

            timkiem = timkiem.Where(x => x.Ngay.Month >= ThangStart.Month && x.Ngay.Month <= ThangEnd.Month).ToList();

            return View("ThongKeKH",new PhanTrangThongKeKH
            {
                listkhs = timkiem
                         .Skip((ProductPage - 1) * PageSize).Take(PageSize),
                PagingInfo = new PagingInfo
                {
                    ItemsPerPage = PageSize,
                    CurrentPage = ProductPage,
                    TotalItems = timkiem.Count()
                }

            }
                 );
        }
       
        #endregion
        #region Thông Kê Doanh Thu  Theo Ngày, Tháng , Năm
        [HttpGet]
        public async Task<IActionResult> ThongKeDoanhThuTheoNgay()
        {
            string apiUrl = $"https://localhost:7268/api/ThongKeView/ThongKeDoanhThuTheoNgay";

            var response = await _httpClient.GetAsync(apiUrl);
            string apiData = await response.Content.ReadAsStringAsync();
            var ChatLieus = JsonConvert.DeserializeObject<List<ThongKeDoanhThu>>(apiData);

            return View(ChatLieus);
        }
        [HttpGet]
        public async Task<IActionResult> LocThongKeDoanhThuTheoNgay(DateTime NgayStart,DateTime NgayEnd)
        {
            string apiUrl = $"https://localhost:7095/api/ThongKeView/ThongKeDoanhThuTheoNgay";

            var response = await _httpClient.GetAsync(apiUrl);
            string apiData = await response.Content.ReadAsStringAsync();
            var ChatLieus = JsonConvert.DeserializeObject<List<ThongKeDoanhThu>>(apiData);
            var timkiem = ChatLieus.ToList();
            timkiem=timkiem.Where(x=>x.Ngay.Date>=NgayStart.Date&&x.Ngay.Date<=NgayEnd.Date).ToList();
            return View("ThongKeDoanhThuTheoNgay", timkiem);
        }
        [HttpGet]
        public async Task<IActionResult> ThongKeDoanhThuTheoThang()
        {
            string apiUrl = $"https://localhost:7095/api/ThongKeView/ThongKeDoanhThuTheoThang";

            var response = await _httpClient.GetAsync(apiUrl);
            string apiData = await response.Content.ReadAsStringAsync();
            var ChatLieus = JsonConvert.DeserializeObject<List<ThongKeDoanhThu>>(apiData);

            return View(ChatLieus);
        }
        [HttpGet]
        public async Task<IActionResult> LocThongKeDoanhThuTheoThang(DateTime NgayStart, DateTime NgayEnd)
        {
            string apiUrl = $"https://localhost:7268/api/ThongKeView/ThongKeDoanhThuTheoThang";

            var response = await _httpClient.GetAsync(apiUrl);
            string apiData = await response.Content.ReadAsStringAsync();
            var ChatLieus = JsonConvert.DeserializeObject<List<ThongKeDoanhThu>>(apiData);
            var timkiem = ChatLieus.ToList();
            timkiem = timkiem.Where(x => x.Ngay.Month >= NgayStart.Month && x.Ngay.Month<= NgayEnd.Month).ToList();

            return View("ThongKeDoanhThuTheoThang", timkiem);
        }
        [HttpGet]
        public async Task<IActionResult> ThongKeDoanhThuTheoNam()
        {
            string apiUrl = $"https://localhost:7268/api/ThongKeView/ThongKeDoanhThuTheoNam";

            var response = await _httpClient.GetAsync(apiUrl);
            string apiData = await response.Content.ReadAsStringAsync();
            var ChatLieus = JsonConvert.DeserializeObject<List<ThongKeDoanhThu>>(apiData);

            return View(ChatLieus);
        }
        [HttpGet]
        public async Task<IActionResult> LocThongKeDoanhThuTheoNam(DateTime NgayStart, DateTime NgayEnd)
        {
            string apiUrl = $"https://localhost:7268/api/ThongKeView/ThongKeDoanhThuTheoNam";

            var response = await _httpClient.GetAsync(apiUrl);
            string apiData = await response.Content.ReadAsStringAsync();
            var ChatLieus = JsonConvert.DeserializeObject<List<ThongKeDoanhThu>>(apiData);
            var timkiem = ChatLieus.ToList();
            timkiem = timkiem.Where(x => x.Ngay.Year >= NgayStart.Year && x.Ngay.Year <= NgayEnd.Year).ToList();
            return View("ThongKeDoanhThuTheoNam", timkiem);
        }
        #endregion
        #region Thống Kê Số liệu 
        [HttpGet]
        public async Task<IActionResult> ThongKe()
        {
            string apiUrl = $"https://localhost:7268/api/ThongKeView/ThongKeSLCTSPBan";
            var response = await _httpClient.GetAsync(apiUrl);
            string apiData = await response.Content.ReadAsStringAsync();
            var ThongKeSLSPBan = JsonConvert.DeserializeObject<ThongKeSLSPDaBan>(apiData);
            ViewBag.ThongKeSLSPDaBan = ThongKeSLSPBan;

            string apiUrl1 = $"https://localhost:7268/api/ThongKeView/ThongKeSLCTSP";

            var response1 = await _httpClient.GetAsync(apiUrl1);
            string apiData1 = await response1.Content.ReadAsStringAsync();
            var ThongKeSLCTSP = JsonConvert.DeserializeObject<int>(apiData1);
            ViewBag.ThongKeSLCTSP = ThongKeSLCTSP;

            string apiUrl2 = $"https://localhost:7268/api/ThongKeView/ThongKeTongDTTrongThang";
            var response2 = await _httpClient.GetAsync(apiUrl2);
            string apiData2= await response2.Content.ReadAsStringAsync();
            var ThongKeDTTrongThang= JsonConvert.DeserializeObject<ThongKeDTTrongThang>(apiData2);
            ViewBag.ThongKeDTTrongThang = ThongKeDTTrongThang;

            string apiUrl3 = $"https://localhost:7268/api/ThongKeView/ThongKeSoDonTrongThang";
            var response3 = await _httpClient.GetAsync(apiUrl3);
            string apiData3 = await response3.Content.ReadAsStringAsync();
            var ThongKeSDonTrongThang = JsonConvert.DeserializeObject<ThongKeSDonTrongThang>(apiData3);
            ViewBag.ThongKeSDonTrongThang= ThongKeSDonTrongThang;

            string apiUrl4 = $"https://localhost:7268/api/ThongKeView/ThongKeKHTheoSoLuongHoaDon";
            var response4 = await _httpClient.GetAsync(apiUrl4);
            string apiData4 = await response4.Content.ReadAsStringAsync();
            var ChatLieus = JsonConvert.DeserializeObject<List<ThongKeKHMuaNhieu>>(apiData4);
            var timkiem = ChatLieus.ToList();

            timkiem = timkiem.Where(x => x.Ngay.Month ==DateTime.Now.Month).Take(7).ToList();
            ViewBag.ThongKeKHMuaNhieu = timkiem;

            string apiUrl5 = $"https://localhost:7268/api/ThongKeView/ThongKeDoanhThuTheoNgay";

            var response5 = await _httpClient.GetAsync(apiUrl5);
            string apiData5 = await response5.Content.ReadAsStringAsync();
            var ThongKeDoanhThuTheoNgay = JsonConvert.DeserializeObject<List<ThongKeDoanhThu>>(apiData5);
            ViewBag.ThongKeDoanhThuTheoNgay= ThongKeDoanhThuTheoNgay;

            string apiUrl6 = $"https://localhost:7268/api/ThongKeView/ThongKeDoanhThuTheoThang";

            var response6 = await _httpClient.GetAsync(apiUrl6);
            string apiData6 = await response6.Content.ReadAsStringAsync();
            var ThongKeDoanhThuTheoThang = JsonConvert.DeserializeObject<List<ThongKeDoanhThu>>(apiData6);
            ViewBag.ThongKeDoanhThuTheoThang = ThongKeDoanhThuTheoThang;

            string apiUrl7 = $"https://localhost:7268/api/ThongKeView/ThongKeMSSanPhamBan";

            var response7 = await _httpClient.GetAsync(apiUrl7);
            string apiData7 = await response7.Content.ReadAsStringAsync();
            var ThongKeMSSanPhamTheoSoLuong = JsonConvert.DeserializeObject<List<ThongKeMSSanPhamTheoSoLuong>>(apiData7);
            ViewBag.ThongKeMSSanPhamTheoSoLuong= ThongKeMSSanPhamTheoSoLuong;

            return View();
        }
        #endregion
    }
}
