using AppAPI.IServices;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AppAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ThongKeKhachHangController : ControllerBase
    {
        private readonly IThongKeKhachHangService service;

        public ThongKeKhachHangController(IThongKeKhachHangService service)
        {
            this.service = service;
        }

        // GET: api/<ThongKeKhachHangService>
        [HttpGet("Khach-hang-moi-theo-ngay")]
        public ActionResult<int> ThongKeKhachHangMoiTheoNgay(DateTime date)
        {
            var kh = service.KhachHangMoiTheoNgay(date); return Ok(kh);
        }

        // GET api/<ThongKeKhachHangService>/5
        [HttpGet("Khach-hang-cu-theo-ngay")]
        public ActionResult<int> ThongKeKhachHangCuTheoNgay(DateTime date)
        {
            var kh = service.KhachHangCuTheoNgay(date); return Ok(kh);
        }

        // GET api/<ThongKeKhachHangService>/5
        [HttpGet("Khach-hang-cu/{month}/{year}")]
        public ActionResult<int> ThongKeKhachHangCuTheoThang(int month, int year)
        {
            var kh = service.KhachHangCuTheoThang(month, year); return Ok(kh);
        }

        // GET api/<ThongKeKhachHangService>/5
        [HttpGet("Khach-hang-moi/{month}/{year}")]
        public ActionResult<int> ThongKeKhachHangMoiTheoThang(int month, int year)
        {
            var kh = service.KhachHangMoiTheoThang(month, year); return Ok(kh);
        }

        // GET api/<ThongKeKhachHangService>/5
        [HttpGet("Khach-hang-cu/{year}")]
        public ActionResult<int> ThongKeKhachHangCuTheoNam(int year)
        {
            var kh = service.KhachHangCuTheoNam(year); return Ok(kh);
        }
        // GET api/<ThongKeKhachHangService>/5
        [HttpGet("Khach-hang-moi/{year}")]
        public ActionResult<int> ThongKeKhachHangMoiTheoNam(int year)
        {
            var kh = service.KhachHangMoiTheoNam(year); return Ok(kh);
        }

        //[HttpGet("Tong-Khach-hang/{year}")]
        //public IActionResult ThongKeKhachHangTheoNam(int year)
        //{
        //    var kh = service.TongKhachHangMuaTrongNam(year); return Ok(kh);
        //}
        //[HttpGet("Tong-Khach-hang/{date}")]
        //public IActionResult ThongKeKhachHangTheoNgay(DateTime date)
        //{
        //    var kh = service.TongKhachHangTrongNgay(date); return Ok(kh);
        //}
        //[HttpGet("Tong-Khach-thang/{mont}/{year}")]
        //public IActionResult ThongKeKhachHangTheoThang(int month,int year)
        //{
        //    var kh = service.TongKhachHangMuaTrongThang(month, year); return Ok(kh);
        //}

    }
}
