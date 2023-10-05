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
    public class OderController : ControllerBase
    {
        private readonly IAllServices<Order> services;
        DbSet<Order> dbSet;
        DBnhom6TT context = new DBnhom6TT();

        public OderController()
        {
            dbSet = context.Order;
            AllServices<Order> all = new AllServices<Order>(context, dbSet);
            services = all;
        }

        // GET: api/<OrderController>
        [HttpGet]
        public List<Order> Get()
        {
            return services.GetAll();
        }

        // GET api/<OrderController>/5
        [HttpGet("{id}")]
        public Order GetById(Guid id)
        {
            return services.GetAll().FirstOrDefault(x => x.id == id);
        }

        // POST api/<OrderController>
        [HttpPost]
        public bool Post(Order obj)
        {
            Order order = new Order();
            order.id = obj.id;
            order.AccountId = obj.AccountId;
            order.Code = obj.Code;
            order.CustomerName = obj.CustomerName;
            order.PhoneNumber = obj.PhoneNumber;
            order.Address = obj.Address;
            order.ShipFee = obj.ShipFee;
            order.MoneyReduce = obj.MoneyReduce;
            order.CreateDate = obj.CreateDate;
            order.PayDate = obj.PayDate;
            order.ShipDate = obj.ShipDate;
            order.ReceiveDate = obj.ReceiveDate;
            order.Status = obj.Status;
            return services.Add(order);
        }

        // PUT api/<OrderController>/5
        [HttpPut("{id}")]
        public bool Put(Order obj)
        {
            Order order = services.GetAll().FirstOrDefault(x => x.id == obj.id);
            order.AccountId = obj.AccountId;
            order.Code = obj.Code;
            order.CustomerName = obj.CustomerName;
            order.PhoneNumber = obj.PhoneNumber;
            order.Address = obj.Address;
            order.ShipFee = obj.ShipFee;
            order.MoneyReduce = obj.MoneyReduce;
            order.CreateDate = obj.CreateDate;
            order.PayDate = obj.PayDate;
            order.ShipDate = obj.ShipDate;
            order.ReceiveDate = obj.ReceiveDate;
            order.Status = obj.Status;
            return services.Update(order);
        }

        // DELETE api/<OrderController>/5
        [HttpDelete("{id}")]
        public bool Delete(Guid id)
        {
            var sv = services.GetAll().FirstOrDefault(x => x.id == id);
            return services.Delete(sv);
        }
    }
}
