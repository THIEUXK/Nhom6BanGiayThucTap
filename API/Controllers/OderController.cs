
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

        // PUT api/<OrderController>/5
        [HttpPost("Update")]
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

        // DELETE api/<OrderController>/5
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
