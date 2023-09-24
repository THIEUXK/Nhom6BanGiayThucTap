using AppAPI.Services;
using MCV.Models;
using MCV.Models.DBnhom6;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShopOganicAPI.IServices;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AppAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly IAllServices<Role> services;
        DbSet<Role> dbSet;
        DBnhom6TT context = new DBnhom6TT();
        public RoleController()
        {
            dbSet = context.Role;
            AllServices<Role> all = new AllServices<Role>(context, dbSet);
            services = all;
        }

        // GET: api/<RoleController>
        [HttpGet]
        public List<Role> Get()
        {
            return services.GetAll();
        }

        // GET api/<RoleController>/5
        [HttpGet("{id}")]
        public Role GetById(Guid id)
        {
            return services.GetAll().FirstOrDefault(x => x.id == id);
        }

        // POST api/<RoleController>
        [HttpPost]
        public bool Post(string name, bool status)
        {
            Role role = new Role();
            role.id = Guid.NewGuid();
            role.name = name;
            role.Status = status;
            return services.Add(role);
        }

        // PUT api/<RoleController>/5
        [HttpPut("{id}")]
        public bool Put(Guid id, string name, bool status)
        {
            var role = services.GetAll().FirstOrDefault(x => x.id == id);
            if (role != null)
            {
                role.name = name;
                role.Status = status;
                return services.Update(role);
            }
            return false;
        }

        // DELETE api/<RoleController>/5
        [HttpDelete("{id}")]
        public bool Delete(Guid id)
        {
            var sv = services.GetAll().FirstOrDefault(x => x.id == id);
            return services.Delete(sv);
        }
    }
}
