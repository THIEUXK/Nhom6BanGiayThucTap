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
        public bool Post(PaymentMethod obj)
        {
            PaymentMethod payment = new PaymentMethod();
            payment.id = obj.id;
            payment.Orderid = obj.Orderid;
            payment.Method = obj.Method;
            payment.Note = obj.Note;
            payment.Total = obj.Total;
            payment.Status = obj.Status;
            return services.Add(payment);
        }

        // PUT api/< PaymentMethodController>/5
        [HttpPut("{id}")]
        public bool Put(PaymentMethod obj)
        {
            PaymentMethod payment = services.GetAll().FirstOrDefault(x => x.id == obj.id);
            payment.id = obj.id;
            payment.Orderid = obj.Orderid;
            payment.Method = obj.Method;
            payment.Note = obj.Note;
            payment.Total = obj.Total;
            payment.Status = obj.Status;
            return services.Update(payment);
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
