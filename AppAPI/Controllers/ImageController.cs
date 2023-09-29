
using AppAPI.Services;
using MCV.Models;
using MCV.Models.DBnhom6;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShopOganicAPI.IServices;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImageController : ControllerBase
    {
        private readonly IAllServices<Image> services;
        DbSet<Image> dbSet;
        DBnhom6TT context = new DBnhom6TT();
        public ImageController()
        {
            dbSet = context.Image;
            AllServices<Image> all = new AllServices<Image>(context, dbSet);
            services = all;
        }
        // GET: api/<BrandController>
        [HttpGet]
        public List<Image> Get()
        {
            return services.GetAll();
        }

        // GET api/<BrandController>/5
        [HttpGet("{id}")]
        public Image Get(Guid id)
        {
            return services.GetAll().FirstOrDefault(x => x.id == id);
        }

        // POST api/<BrandController>
        [HttpPost]
        public bool Post(Guid shoeDetailId, string imgUrl)
        {
            Image image = new Image();
            image.id = Guid.NewGuid();
            image.ShoeDetailId = shoeDetailId;
            image.ImgUrl = imgUrl;
            return services.Add(image);
        }

        // PUT api/<ColorController>/5
        [HttpPut("{id}")]
        public bool Put(Guid id,Guid shoeDetailId, string imgUrl)
        {
            var image = services.GetAll().FirstOrDefault(x => x.id == id);
            if (image != null)
            {
                image.ShoeDetailId = shoeDetailId;
                image.ImgUrl = imgUrl;
                return services.Update(image);
            }
            return false;
        }

        // DELETE api/<BrandController>/5
        [HttpDelete("{id}")]
        public bool Delete(Guid id)
        {
            var sv = services.GetAll().FirstOrDefault(x => x.id == id);
            return services.Delete(sv);
        }
    }
}
