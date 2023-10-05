
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
//    public class ShoeController : ControllerBase
//    {
//        private readonly IAllServices<Shoe> services;
//        DbSet<Shoe> dbSet;
//        DBnhom6TT context = new DBnhom6TT();
//        public ShoeController()
//        {
//            dbSet = context.Shoe;
//            AllServices<Shoe> all = new AllServices<Shoe>(/*context, dbSet*/);
//            services = all;
//        }
//        [HttpGet]
//        public List<Shoe> Get()
//        {
//            return services.GetAll();
//        }

//        // GET api/<ProductController>/5
//        [HttpGet("{id}")]
//        public Shoe Get(Guid id)
//        {
//            return services.GetAll().FirstOrDefault(x => x.id == id);
//        }
//        [HttpPost]
//        public bool Post(Shoe a)
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
//        public bool Put(Shoe a)
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
