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
        public bool Post(string name, bool status)
        {
            Shoe sh = new Shoe();
            sh.id = Guid.NewGuid();
            sh.name = name;
            sh.Status = status;
            return services.Add(sh);
        }
        // PUT api/< PaymentMethodController>/5
        [HttpPut("{id}")]
        public bool Put(Guid id, string name, bool status)
        {
            var sh = services.GetAll().FirstOrDefault(x => x.id == id);
            if (sh != null)
            {
                sh.name = name;
                sh.Status = status;
                return services.Update(sh);
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
