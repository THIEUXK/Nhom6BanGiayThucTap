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
    public class CategoryController : ControllerBase
    {
        private readonly IAllServices<Category> services;
        DbSet<Category> dbSet;
        DBnhom6TT context = new DBnhom6TT();
        public CategoryController()
        {
            dbSet = context.Categories;
            AllServices<Category> all = new AllServices<Category>(context, dbSet);
            services = all;
        }
        // GET: api/<BrandController>
        [HttpGet]
        public List<Category> Get()
        {
            return services.GetAll();
        }

        // GET api/<BrandController>/5
        [HttpGet("{id}")]
        public Category Get(Guid id)
        {
            return services.GetAll().FirstOrDefault(x => x.id == id);
        }

        // POST api/<BrandController>
        [HttpPost]
        public bool Post(Category obj)
        {
            Category categori = new Category();
            categori.id =obj.id;
            categori.name = obj.name;
            categori.Status = obj.Status;
            return services.Add(categori);
        }

        // PUT api/<ColorController>/5
        [HttpPut("{id}")]
        public bool Put(Category obj)
        {
            Category categori = services.GetAll().FirstOrDefault(x => x.id == obj.id);
            categori.name = obj.name;
            categori.Status = obj.Status;
            return services.Update(categori);
        }

        // DELETE api/<BrandController>/5
        [HttpDelete("{id}")]
        public bool Delete(Guid id)
        {
            var sv = services.GetAll().FirstOrDefault(x => x.id == id);
            return services.Delete(sv);
        }
    }
}
