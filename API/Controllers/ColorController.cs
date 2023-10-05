using API.IServices;
using API.Services;
using MCV.Models;
using MCV.Models.DBnhom6;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
        [HttpPost]
        public bool Post(Color obj)
        {
            Color color = new Color();
            color.id = obj.id;
            color.name = obj.name;
            color.Status = obj.Status;
            return services.Add(color);
        }

        // PUT api/<ColorController>/5
        [HttpPut("{id}")]
        public bool Put(Color obj)
        {
            Color color = services.GetAll().FirstOrDefault(x => x.id == obj.id);
            color.id = obj.id;
            color.name = obj.name;
            color.Status = obj.Status;
            return services.Update(color);
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
