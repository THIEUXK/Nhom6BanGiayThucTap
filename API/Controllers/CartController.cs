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
    public class CartController : ControllerBase
    {
        private readonly IAllServices<Cart> services;
        DbSet<Cart> dbSet;
        DBnhom6TT context = new DBnhom6TT();
        public CartController()
        {
            dbSet = context.Carts;
            AllServices<Cart> all = new AllServices<Cart>(context, dbSet);
            services = all;
        }
        // GET: api/<CartController>
        [HttpGet]
        public List<Cart> Get()
        {
            return services.GetAll();
        }

        // GET api/<CartController>/5
        [HttpGet("{id}")]
        public Cart Get(Guid id)
        {
            return services.GetAll().FirstOrDefault(x => x.id == id);
        }

        // POST api/<CartController>
        [HttpPost]
        public bool Post(Cart obj)
        {
            Cart cart = new Cart();
            cart.id = obj.id;
            cart.AccountId = obj.AccountId;
            cart.Status = obj.Status;
            services.Add(cart);
            return services.Add(cart);
        }

        // PUT api/<CartController>/5
        [HttpPut("{id}")]
        public bool Put(Cart obj)
        {
            Cart cart = services.GetAll().FirstOrDefault(x => x.id == obj.id);
            cart.AccountId = obj.AccountId;
            cart.Status = obj.Status;
            services.Add(cart);
            return services.Update(cart);
        }

        // DELETE api/<CartController>/5
        [HttpDelete("{id}")]
        public bool Delete(Guid id)
        {
            var sv = services.GetAll().FirstOrDefault(x => x.id == id);
            return services.Delete(sv);
        }
    }
}
