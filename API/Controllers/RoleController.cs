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
        public bool Post(Role obj)
        {
            Role role = new Role();
            role.id = obj.id;
            role.name = obj.name;
            role.Status = obj.Status;
            return services.Add(role);
        }

        // PUT api/<RoleController>/5
        [HttpPut("{id}")]
        public bool Put(Role obj)
        {
            var role = services.GetAll().FirstOrDefault(x => x.id == obj.id);
            role.name = obj.name;
            role.Status = obj.Status;
            return services.Update(role);
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
