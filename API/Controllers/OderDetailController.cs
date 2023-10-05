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
    public class OderDetailController : ControllerBase
    {
        private readonly IAllServices<OrderDetail> services;
        DbSet<OrderDetail> dbSet;
        DBnhom6TT context = new DBnhom6TT();

        public OderDetailController()
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
        public bool Post(OrderDetail obj)
        {
            OrderDetail order = new OrderDetail();
            order.id = obj.id;
            order.ShoeDetailId = obj.ShoeDetailId;
            order.OrderId = obj.OrderId;
            order.Quantity = obj.Quantity;
            order.Price = obj.Price;
            order.Discount = obj.Discount;
            order.Status = obj.Status;
            return services.Add(order);
        }

        // PUT api/<OrderDetailController>/5
        [HttpPut("{id}")]
        public bool Put(OrderDetail obj)
        {
            var order = services.GetAll().FirstOrDefault(x => x.id == obj.id);
            order.ShoeDetailId = obj.ShoeDetailId;
            order.OrderId = obj.OrderId;
            order.Quantity = obj.Quantity;
            order.Price = obj.Price;
            order.Discount = obj.Discount;
            order.Status = obj.Status;
            return services.Update(order);
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
