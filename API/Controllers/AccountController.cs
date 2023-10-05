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
        [HttpPost]
        public bool Post(Account obj)
        {
            Account account = new Account();
            account.id = obj.id;
            account.RoleId =obj.RoleId;
            account.Avatar = obj.Avatar;
            account.Email = obj.Email;
            account.Password = obj.Password;
            account.Name = obj.Name;
            account.Status = obj.Status;
            return services.Add(account);
        }
        // PUT api/< PaymentMethodController>/5
        [HttpPut("{id}")]
        public bool Put(Account obj)
        {
            Account account = services.GetAll().FirstOrDefault(x => x.id ==obj.id );
            account.RoleId = obj.RoleId;
            account.Avatar = obj.Avatar;
            account.Email = obj.Email;
            account.Password = obj.Password;
            account.Name = obj.Name;
            account.Status = obj.Status;
            return services.Update(account);
        }
        //aaaaaa
        //delete
        // DELETE api/< PaymentMethodController>/5
        [HttpDelete("{id}")]
        public bool Delete(Guid id)
        {
            var sv = services.GetAll().FirstOrDefault(x => x.id == id);
            return services.Delete(sv);
        }

    }
}
