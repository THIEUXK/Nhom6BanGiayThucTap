//using AppAPI.IServices;
//using Microsoft.AspNetCore.Mvc;

//// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

//namespace AppAPI.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class ThongKeSanPhamController : ControllerBase
//    {
//        private readonly IThongKeSanPhamService service;

//        public ThongKeSanPhamController(IThongKeSanPhamService service)
//        {
//            this.service = service;
//        }

//        // GET: api/<ThongKeSanPhamController>
//        [HttpGet("top10sanphamtrongngay")]
//        public async Task<IActionResult> GetTop10SanphamTrongNgay([FromQuery] DateTime date)
//        {
//            var top = await service.Top10SanPhamTrongNgay(date);
//            return Ok(top); 
//        }

//        // GET api/<ThongKeSanPhamController>/5
//        [HttpGet("top10sanphamtrongthang")]
//        public async Task<IActionResult> GetTop10SanphamTrongThang([FromQuery]  int month, int year)
//        {
//            var top = await service.Top10SanPhamTrongThang(month, year);
//            return Ok(top);
//        }
//        // GET api/<ThongKeSanPhamController>/5
//        [HttpGet("top10sanphamtrongnam")]
//        public async Task<IActionResult> GetTop10SanphamTrongNam([FromQuery] int year)
//        {
//            var top = await service.Top10SanPhamTrongNam(year);
//            return Ok(top);
//        }
//    }
//}
