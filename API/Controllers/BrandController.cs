
using AppAPI.Services;
using MCV.Models;
using MCV.Models.DBnhom6;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShopOganicAPI.IServices;

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
        [HttpPost("Add")]
public bool Post(Brand a)
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
public bool Put(Brand a)
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
