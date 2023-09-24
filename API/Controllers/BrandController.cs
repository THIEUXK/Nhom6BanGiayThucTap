using API.IServices;
using API.Services;
using MCV.Models;
using MCV.Models.DBnhom6;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandController : ControllerBase
    {
            private readonly IAllServices<Brand> services;
            DbSet<Brand> dbSet;
            DBnhom6TT context = new DBnhom6TT();
            public BrandController()
            {
                dbSet = context.Brands;
                AllServices<Brand> all = new AllServices<Brand>(context, dbSet);
                services = all;
            }
            // GET: api/<BrandController>
            [HttpGet]
            public List<Brand> Get()
            {
                return services.GetAll();
            }

            // GET api/<BrandController>/5
            [HttpGet("{id}")]
            public Brand Get(Guid id)
            {
                return services.GetAll().FirstOrDefault(x => x.id == id);
            }

            // POST api/<BrandController>
            [HttpPost]
            public bool Post(string name, bool status)
            {
                Brand brand = new Brand();
                brand.id = Guid.NewGuid();
                brand.name = name;
                brand.Status = status;
                return services.Add(brand);
            }

            // PUT api/<ColorController>/5
            [HttpPut("{id}")]
            public bool Put(Guid id, string name, bool status)
            {
                var brand = services.GetAll().FirstOrDefault(x => x.id == id);
                if (brand != null)
                {
                    brand.name = name;
                    brand.Status = status;
                    return services.Update(brand);
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
