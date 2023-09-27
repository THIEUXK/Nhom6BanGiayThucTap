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
        public bool Post(Guid AccountId, string name, string specificAddress, string phoneNumber, string ward, string district, string province, string note)
        {
            Address ad = new Address();
            ad.id = Guid.NewGuid();
            ad.AccountId = AccountId;
            ad.Name = name; 
            ad.SpecificAddress = specificAddress; 
            ad.PhoneNumber = phoneNumber; 
            ad.Ward = ward;
            ad.District = district;
            ad.Province = province;
            ad.Note = note;
            return services.Add(ad);
        }
        // PUT api/< PaymentMethodController>/5
        [HttpPut("{id}")]
        public bool Put(Guid id,Guid AccountId, string name, string specificAddress, string phoneNumber, string ward, string district, string province, string note)
        {
            var ad = services.GetAll().FirstOrDefault(x => x.id == id);
            if (ad != null)
            {
                ad.AccountId = AccountId;
                ad.Name = name;
                ad.SpecificAddress = specificAddress;
                ad.PhoneNumber = phoneNumber;
                ad.Ward = ward;
                ad.District = district;
                ad.Province = province;
                ad.Note = note;
                return services.Update(ad);
            }
            return false;
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
