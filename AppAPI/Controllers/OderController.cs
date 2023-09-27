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
        public bool Post(Guid accountId, string code, string customerName, int phoneNumber, string address, float shipFee, float moneyReduce, DateTime createDate, DateTime payDate, DateTime shipDate, DateTime receiveDate, bool status)
        {
            Order order = new Order();
            order.id = Guid.NewGuid();
            order.AccountId = accountId;
            order.Code = code;
            order.CustomerName = customerName;
            order.PhoneNumber = phoneNumber;
            order.Address = address;
            order.ShipFee = shipFee;
            order.MoneyReduce = moneyReduce;
            order.CreateDate = createDate;
            order.PayDate = payDate;
            order.ShipDate = shipDate;
            order.ReceiveDate = receiveDate;
            order.Status = status;
            return services.Add(order);
        }

        // PUT api/<OrderController>/5
        [HttpPut("{id}")]
        public bool Put(Guid id, Guid accountId, string code, string customerName, int phoneNumber, string address, float shipFee, float moneyReduce, DateTime createDate, DateTime payDate, DateTime shipDate, DateTime receiveDate, bool status)
        {
            var order = services.GetAll().FirstOrDefault(x => x.id == id);
            if (order != null)
            {
                order.AccountId = accountId;
                order.Code = code;
                order.CustomerName = customerName;
                order.PhoneNumber = phoneNumber;
                order.Address = address;
                order.ShipFee = shipFee;
                order.MoneyReduce = moneyReduce;
                order.CreateDate = createDate;
                order.PayDate = payDate;
                order.ShipDate = shipDate;
                order.ReceiveDate = receiveDate;
                order.Status = status;
                return services.Update(order);
            }
            return false;
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
