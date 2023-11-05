
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
    public class AccountController : ControllerBase
    {
        private readonly IAllServices<Account> services;
        DbSet<Account> dbSet;
        DBnhom6TT context = new DBnhom6TT();
        public AccountController()
        {
            dbSet = context.Accounts;
            AllServices<Account> all = new AllServices<Account>(context, dbSet);
            services = all;
        }
        [HttpGet]
        public List<Account> Get()
        {
            return services.GetAll();
        }
        [HttpGet("{id}")]
        public Account Get(Guid id)
        {

            return services.GetAll().FirstOrDefault(x => x.id == id);
        }
        [HttpPost("Add")]
        public bool Post(Account a)
        {
            try
            {   Account x = new Account();
                x.id = Guid.NewGuid();
              
                x.RoleId = a.RoleId;    
                x.Name = a.Name;
                x.Email = a.Email;
                x.Password = a.Password;
                x.Status = a.Status;
                x.Avatar = a.Avatar;
             
                return services.Add(x);
            }
            catch (Exception e)
            {
                return false;
            }
           
        }
        // PUT api/< PaymentMethodController>/5
        [HttpPut("Update")]
        public bool Put(Account a)
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
