using AppAPI.Services;
using MCV.Models;
using MCV.Models.DBnhom6;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShopOganicAPI.IServices;
using System.Net;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AppAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IAllServices<Order> services;
        DbSet<Order> dbSet;
        DBnhom6TT context = new DBnhom6TT();

        public OrderController()
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
        [HttpPost("Add")]
        public bool Post(Order a)
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
        [HttpPut("Update")]
        public bool Put(Order a)
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
        [HttpDelete("delete/{id}")]
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
