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
        public bool Post(Guid roleID,string name, bool status,string email,string password,string avatar)
        {
            Account account = new Account();
            account.id = Guid.NewGuid();
            account.RoleId = roleID;
            account.Avatar = avatar;
            account.Email = email;
            account.Password = password;
            account.Name = name;
            account.Status = status;
            return services.Add(account);
        }
        // PUT api/< PaymentMethodController>/5
        [HttpPut("{id}")]
        public bool Put(Guid id,Guid roleID, string name, bool status, string email, string password, string avatar)
        {
            var account = services.GetAll().FirstOrDefault(x => x.id ==id );
            if (account != null)
            {
                account.RoleId = roleID;
                account.Avatar = avatar;
                account.Email = email;
                account.Password = password;
                account.Name = name;
                account.Status = status;
                return services.Update(account);
            }
            return false;
        }
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
