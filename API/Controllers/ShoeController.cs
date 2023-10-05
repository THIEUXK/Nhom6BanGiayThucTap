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
    public class ShoeController : ControllerBase
    {
        private readonly IAllServices<Shoe> services;
        DbSet<Shoe> dbSet;
        DBnhom6TT context = new DBnhom6TT();
        public ShoeController()
        {
            dbSet = context.Shoe;
            AllServices<Shoe> all = new AllServices<Shoe>(context, dbSet);
            services = all;
        }
        [HttpGet]
        public List<Shoe> Get()
        {
            return services.GetAll();
        }

        // GET api/<ProductController>/5
        [HttpGet("{id}")]
        public Shoe Get(Guid id)
        {
            return services.GetAll().FirstOrDefault(x => x.id == id);
        }

        [HttpPost]
        public bool Post(Shoe obj)
        {
            Shoe sh = new Shoe();
            sh.id = obj.id;
            sh.name = obj.name;
            sh.Status = obj.Status;
            return services.Add(sh);
        }
        // PUT api/< PaymentMethodController>/5
        [HttpPut("{id}")]
        public bool Put(Shoe obj)
        {
            Shoe sh = services.GetAll().FirstOrDefault(x => x.id == obj.id);
            sh.name = obj.name;
            sh.Status = obj.Status;
            return services.Update(sh);
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
