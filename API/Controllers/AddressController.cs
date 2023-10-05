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

        [HttpPost]
        public bool Post(Address obj)
        {
            Address ad = new Address();
            ad.id = obj.id;
            ad.AccountId = obj.AccountId;
            ad.Name = obj.Name; 
            ad.SpecificAddress = obj.SpecificAddress; 
            ad.PhoneNumber = obj.PhoneNumber; 
            ad.Ward = obj.Ward;
            ad.District = obj.District;
            ad.Province = obj.Province;
            ad.Note = obj.Note;
            return services.Add(ad);
        }
        // PUT api/< PaymentMethodController>/5
        [HttpPut("{id}")]
        public bool Put(Address obj)
        {
            Address ad = services.GetAll().FirstOrDefault(x => x.id == obj.id);
            ad.AccountId = obj.AccountId;
            ad.Name = obj.Name;
            ad.SpecificAddress = obj.SpecificAddress;
            ad.PhoneNumber = obj.PhoneNumber;
            ad.Ward = obj.Ward;
            ad.District = obj.District;
            ad.Province = obj.Province;
            ad.Note = obj.Note;
            return services.Update(ad);
        }
        // DELETE api/< PaymentMethodController>/5
        [HttpDelete("{id}")]
        public bool Delete(Guid id)
        {
            var sv = services.GetAll().FirstOrDefault(x => x.id == id);
            return services.Delete(sv);
        }
    }
}
