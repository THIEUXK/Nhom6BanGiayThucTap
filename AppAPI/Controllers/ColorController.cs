using AppAPI.Services;
using MCV.Models;
using MCV.Models.DBnhom6;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShopOganicAPI.IServices;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AppAPI.Controllers
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
        [HttpPost]
        public bool Post(string name, bool status)
        {
            Color color = new Color();
            color.id = Guid.NewGuid();
            color.name = name;
            color.Status = status;
            return services.Add(color);
        }

        // PUT api/<ColorController>/5
        [HttpPut("{id}")]
        public bool Put(Guid id, string name, bool status)
        {
            var color = services.GetAll().FirstOrDefault(x => x.id == id);
            if (color != null)
            {
                color.name = name;
                color.Status = status;
                return services.Update(color);
            }
            return false;
        }

        // DELETE api/<ColorController>/5
        [HttpDelete("{id}")]
        public bool Delete(Guid id)
        {
            var sv = services.GetAll().FirstOrDefault(x => x.id == id);
            return services.Delete(sv);
        }
    }
}
