using MCV.Models;
using MCV.Models.DBnhom6;
using MCV.Services.IService;

namespace MCV.Services.Service
{
    public class AccountService : IAccountService
    {
        public DBnhom6TT _db;

        public AccountService()
        {
            _db = new DBnhom6TT();
        }
        public List<Account> GetAll()
        {
            return _db.Accounts.ToList();
        }

        public Account GetById(Guid id)
        {
            return GetAll().FirstOrDefault(c => c.id == id);
        }

        public bool Create(Account a)
        {
            try
            {
                _db.Accounts.Add(a);
                _db.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool Update(Account a)
        {
            try
            {
                _db.Accounts.Update(a);
                _db.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool Delete(Guid id)
        {
            try
            {
                var b = GetById(id);
                _db.Accounts.Remove(b);
                _db.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
    }
}
