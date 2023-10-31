
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
            return services.GetAll().ToList();
        }

        // GET api/<BrandController>/5
        [HttpGet("{id}")]
        public Image Get(Guid id)
        {
            return services.GetAll().FirstOrDefault(x => x.id == id);
        }

        // POST api/<BrandController>
        [HttpPost("Add")]
        public bool Post(Image a)
        {
            try
            {
                return services.Add(a);
            }
            catch (Exception e)
            {
                return false;
            }

        }
        // PUT api/< PaymentMethodController>/5
        [HttpPut("Update")]
        public bool Put(Image a)
        {
            try
            {
                return services.Update(a);
            }
            catch (Exception e)
            {
                return false;
            }

        }
        //aaaaaa
        //delete
        // DELETE api/< PaymentMethodController>/5
        [HttpDelete("delete/{id}")]
        public bool Delete(Guid id)
        {
            try
            {
                var sv = services.GetAll().FirstOrDefault(x => x.id == id);
                return services.Delete(sv);
            }
            catch (Exception e)
            {
                return false;
            }
        }
    }
}
