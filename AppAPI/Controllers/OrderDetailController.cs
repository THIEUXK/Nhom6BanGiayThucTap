using AppAPI.Services;
using MCV.Models.DBnhom6;
using MCV.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShopOganicAPI.IServices;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AppAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderDetailController : ControllerBase
    {
        private readonly IAllServices<OrderDetail> services;
        DbSet<OrderDetail> dbSet;
        DBnhom6TT context = new DBnhom6TT();

        public OrderDetailController()
        {
            dbSet = context.OrderDetail;
            AllServices<OrderDetail> all = new AllServices<OrderDetail>(context, dbSet);
            services = all;
        }

        // GET: api/<OrderDetailController>
        [HttpGet]
        public List<OrderDetail> Get()
        {
            return services.GetAll();
        }

        // GET api/<OrderDetailController>/5
        [HttpGet("{id}")]
        public OrderDetail GetById(Guid id)
        {
            return services.GetAll().FirstOrDefault(x => x.id == id);
        }

        // POST api/<OrderDetailController>
        [HttpPost]
        public bool Post(Guid shoeDetailId,Guid orderId, int quantity, float price, float discount, bool status)
        {
            OrderDetail order = new OrderDetail();
            order.id = Guid.NewGuid();
            order.ShoeDetailId = shoeDetailId;
            order.OrderId = orderId;
            order.Quantity = quantity;
            order.Price = price;
            order.Discount = discount;
            order.Status = status;
            return services.Add(order);
        }

        // PUT api/<OrderDetailController>/5
        [HttpPut("{id}")]
        public bool Put(Guid id, Guid shoeDetailId, Guid orderId, int quantity, float price, float discount, bool status)
        {
            var order = services.GetAll().FirstOrDefault(x => x.id == id);
            if (order != null)
            {
                order.ShoeDetailId = shoeDetailId;
                order.OrderId = orderId;
                order.Quantity = quantity;
                order.Price = price;
                order.Discount = discount;
                order.Status = status;
                return services.Update(order);
            }
            return false;
        }

        // DELETE api/<OrderDetailController>/5
        [HttpDelete("{id}")]
        public bool Delete(Guid id)
        {
            var sv = services.GetAll().FirstOrDefault(x => x.id == id);
            return services.Delete(sv);
        }
    }
}
