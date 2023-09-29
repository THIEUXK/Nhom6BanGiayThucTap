
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
        public bool Post(Guid accountId, bool status)
        {
            Cart cart = new Cart();
            cart.id = Guid.NewGuid();
            cart.AccountId = accountId;
            cart.Status = status;
            services.Add(cart);
            return true;
        }

        // PUT api/<CartController>/5
        [HttpPut("{id}")]
        public bool Put(Guid id, Guid accountId, bool status)
        {
            var cart = services.GetAll().FirstOrDefault(x => x.id == id);
            if (cart != null)
            {
                cart.AccountId = accountId;
                cart.Status = status;
                services.Update(cart);
                return true;
            }
            return false;
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
