
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
//    public class CategoryController : ControllerBase
//    {
//        private readonly IAllServices<Category> services;
//        DbSet<Category> dbSet;
//        DBnhom6TT context = new DBnhom6TT();
//        //public CategoryController()
//        //{
//        //    dbSet = context.Categories;
//        //    AllServices<Category> all = new AllServices<Category>(context, dbSet);
//        //    services = all;
//        //}
//        // GET: api/<BrandController>
//        [HttpGet]
//        public List<Category> Get()
//        {
//            return services.GetAll();
//        }

//        // GET api/<BrandController>/5
//        [HttpGet("{id}")]
//        public Category Get(Guid id)
//        {
//            return services.GetAll().FirstOrDefault(x => x.id == id);
//        }

//        // POST api/<BrandController>
//        [HttpPost]
//        public bool Post(Category a)
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
//        public bool Put(Category a)
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
