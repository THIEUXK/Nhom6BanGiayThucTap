
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
    public class CartDetailController : ControllerBase
    {
        private readonly IAllServices<CartDetail> services;
        DbSet<CartDetail> dbSet;
        DBnhom6TT context = new DBnhom6TT();
        public CartDetailController()
        {
            dbSet = context.CartDetail;
            AllServices<CartDetail> all = new AllServices<CartDetail>(context, dbSet);
            services = all;
        }
        [HttpGet]
        public List<CartDetail> Get()
        {
            return services.GetAll();
        }

        // GET api/<ProductController>/5
        [HttpGet("{id}")]
        public CartDetail Get(Guid id)
        {
            return services.GetAll().FirstOrDefault(x => x.id == id);
        }

        [HttpPost]
        public bool Post(Guid cartId,Guid shoeDetailId,int quantity)
        {
            CartDetail cd = new CartDetail();
            cd.id = Guid.NewGuid();
            cd.CartId = cartId;
            cd.ShoeDetailId = shoeDetailId;
            cd.Quantity = quantity;
            return services.Add(cd);
        }
        // PUT api/< PaymentMethodController>/5
        [HttpPut("{id}")]
        public bool Put(Guid id, Guid cartId, Guid shoeDetailId, int quantity)
        {
            var cd = services.GetAll().FirstOrDefault(x => x.id == id);
            if (cd != null)
            {
                cd.CartId = cartId;
                cd.ShoeDetailId = shoeDetailId;
                cd.Quantity = quantity;
                return services.Update(cd);
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
