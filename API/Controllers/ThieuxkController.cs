using MCV.Models;
using MCV.Models.DBnhom6;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ThieuxkController : Controller
    {
        public DBnhom6TT _db;
        public ThieuxkController()
        {
            _db = new DBnhom6TT();
        }
        // GET: ThieuxkController
        [HttpGet]
        public List<ShoeDetail> SanPhamBan()
        {

            return _db.ShoeDetail.Include(c=>c.Shoe).Include(c=>c.Size).Include(c=>c.Brand).Include(c=>c.Category).Include(c=>c.Color)
                .ToList();
        }

    }
}
