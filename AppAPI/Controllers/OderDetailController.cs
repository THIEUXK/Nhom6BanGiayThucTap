
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
        public bool Post(OrderDetail a)
        {
            try
            {
                return services.Add(a);
            }
            catch (Exception e)
            {
                return false;
            }

        }
        // PUT api/< PaymentMethodController>/5
        [HttpPut("{id}")]
        public bool Put(OrderDetail a)
        {
            try
            {
                return services.Update(a);
            }
            catch (Exception e)
            {
                return false;
            }

        }
        //aaaaaa
        //delete
        // DELETE api/< PaymentMethodController>/5
        [HttpDelete("{id}")]
        public bool Delete(Guid id)
        {
            try
            {
                var sv = services.GetAll().FirstOrDefault(x => x.id == id);
                return services.Delete(sv);
            }
            catch (Exception e)
            {
                return false;
            }
        }
    }
}
