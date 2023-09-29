
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
    public class PaymentMethodController : ControllerBase
    {
        private readonly IAllServices<PaymentMethod> services;
        DbSet<PaymentMethod> dbSet;
        DBnhom6TT context = new DBnhom6TT();
        public PaymentMethodController()
        {
            dbSet = context.PaymentMethod;
            AllServices<PaymentMethod> all = new AllServices<PaymentMethod>(context, dbSet);
            services = all;
        }

        // GET: api/< PaymentMethodController>
        [HttpGet]
        public List<PaymentMethod> Get()
        {
            return services.GetAll();
        }

        // GET api/< PaymentMethodController>/5
        [HttpGet("{id}")]
        public PaymentMethod GetById(Guid id)
        {
            return services.GetAll().FirstOrDefault(x => x.id == id);
        }

        // POST api/< PaymentMethodController>
        [HttpPost]
        public bool Post(Guid orderId, string mehthod, float total, string note, bool status)
        {
            PaymentMethod payment = new PaymentMethod();
            payment.id = Guid.NewGuid();
            payment.Orderid = orderId;
            payment.Method = mehthod;
            payment.Note = note;
            payment.Total = total;
            payment.Status = status;
            return services.Add(payment);
        }

        // PUT api/< PaymentMethodController>/5
        [HttpPut("{id}")]
        public bool Put(Guid id, Guid orderId, string mehthod, float total, string note, bool status)
        {
            var payment = services.GetAll().FirstOrDefault(x => x.id == id);
            if (payment != null)
            {
                payment.Orderid = orderId;
                payment.Method = mehthod;
                payment.Note = note;
                payment.Total = total;
                payment.Status = status;
                return services.Update(payment);
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
