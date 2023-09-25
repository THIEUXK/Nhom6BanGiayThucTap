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
    public class SizeController : ControllerBase
    {
        private readonly IAllServices<Size> services;
        DbSet<Size> dbSet;
        DBnhom6TT context = new DBnhom6TT();
        public SizeController()
        {
            dbSet = context.Size;
            AllServices<Size> all = new AllServices<Size>(context, dbSet);
            services = all;
        }

        // GET: api/<SizeController>
        [HttpGet]
        public List<Size> Get()
        {
            return services.GetAll();
        }

        // GET api/<SizeController>/5
        [HttpGet("{id}")]
        public Size GetById(Guid id)
        {
            return services.GetAll().FirstOrDefault(x => x.id == id);
        }

        // POST api/<SizeController>
        [HttpPost]
        public bool Post(string name, bool status)
        {
            Size size = new Size();
            size.id = Guid.NewGuid();
            size.name = name;
            size.Status = status;
            return services.Add(size);
        }

        // PUT api/<SizeController>/5
        [HttpPut("{id}")]
        public bool Put(Guid id, string name, bool status)
        {
            var size = services.GetAll().FirstOrDefault(x => x.id == id);
            if (size != null)
            {
                size.name = name;
                size.Status = status;
                return services.Update(size);
            }
            return false;
        }

        // DELETE api/<SizeController>/5
        [HttpDelete("{id}")]
        public bool Delete(Guid id)
        {
            var sv = services.GetAll().FirstOrDefault(x => x.id == id);
            return services.Delete(sv);
        }
    }
}
