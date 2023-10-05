    
//using AppAPI.Services;
//using MCV.Models;
//using MCV.Models.DBnhom6;
//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.EntityFrameworkCore;
//using ShopOganicAPI.IServices;

//namespace API.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class PaymentMethodController : ControllerBase
//    {
//        private readonly IAllServices<PaymentMethod> services;
//        DbSet<PaymentMethod> dbSet;
//        DBnhom6TT context = new DBnhom6TT();
//        public PaymentMethodController()
//        {
//            dbSet = context.PaymentMethod;
//            AllServices<PaymentMethod> all = new AllServices<PaymentMethod>(/*context, dbSet*/);
//            services = all;
//        }

//        // GET: api/< PaymentMethodController>
//        [HttpGet]
//        public List<PaymentMethod> Get()
//        {
//            return services.GetAll();
//        }

//        // GET api/< PaymentMethodController>/5
//        [HttpGet("{id}")]
//        public PaymentMethod GetById(Guid id)
//        {
//            return services.GetAll().FirstOrDefault(x => x.id == id);
//        }

//        // POST api/< PaymentMethodController>
//        [HttpPost]
//        public bool Post(PaymentMethod a)
//        {
//            try
//            {
//                return services.Add(a);
//            }
//            catch (Exception e)
//            {
//                return false;
//            }

//        }
//        // PUT api/< PaymentMethodController>/5
//        [HttpPut("{id}")]
//        public bool Put(PaymentMethod a)
//        {
//            try
//            {
//                return services.Update(a);
//            }
//            catch (Exception e)
//            {
//                return false;
//            }

//        }
//        //aaaaaa
//        //delete
//        // DELETE api/< PaymentMethodController>/5
//        [HttpDelete("{id}")]
//        public bool Delete(Guid id)
//        {
//            try
//            {
//                var sv = services.GetAll().FirstOrDefault(x => x.id == id);
//                return services.Delete(sv);
//            }
//            catch (Exception e)
//            {
//                return false;
//            }
//        }
//    }
//}
