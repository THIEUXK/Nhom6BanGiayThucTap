
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
        public bool Post(string name, bool status)
        {
            Category categori = new Category();
            categori.id = Guid.NewGuid();
            categori.name = name;
            categori.Status = status;
            return services.Add(categori);
        }

        // PUT api/<ColorController>/5
        [HttpPut("{id}")]
        public bool Put(Guid id, string name, bool status)
        {
            var categori = services.GetAll().FirstOrDefault(x => x.id == id);
            if (categori != null)
            {
                categori.name = name;
                categori.Status = status;
                return services.Update(categori);
            }
            return false;
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
