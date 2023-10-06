
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
    public class ColorController : ControllerBase
    {
        private readonly IAllServices<Color> services;
        DbSet<Color> dbSet;
        DBnhom6TT context = new DBnhom6TT();
        public ColorController()
        {
            dbSet = context.Color;
            AllServices<Color> all = new AllServices<Color>(context, dbSet);
            services = all;
        }
        // GET: api/<ColorController>
        [HttpGet]
        public List<Color> Get()
        {
            return services.GetAll();
        }

        // GET api/<ColorController>/5
        [HttpGet("{id}")]
        public Color Get(Guid id)
        {
            return services.GetAll().FirstOrDefault(x => x.id == id);
        }

        // POST api/<ColorController>
        [HttpPost("Add")]
        public bool Post(Color a)
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
        public bool Put(Color a)
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
