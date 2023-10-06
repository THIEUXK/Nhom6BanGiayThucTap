
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
    public class AddressController : ControllerBase
    {
        private readonly IAllServices<Address> services;
        DbSet<Address> dbSet;
        DBnhom6TT context = new DBnhom6TT();
        public AddressController()
        {
            dbSet = context.Address;
            AllServices<Address> all = new AllServices<Address>(context, dbSet);
            services = all;
        }
        [HttpGet]
        public List<Address> Get()
        {
            return services.GetAll();
        }

        // GET api/<ProductController>/5
        [HttpGet("{id}")]
        public Address Get(Guid id)
        {
            return services.GetAll().FirstOrDefault(x => x.id == id);
        }

        [HttpPost("Add")]
        public bool Post(Address a)
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
        public bool Put(Address a)
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
