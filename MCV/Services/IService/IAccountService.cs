using MCV.Models;

namespace MCV.Services.IService
{
    public interface IAccountService
    {
        public List<Account> GetAll();
        public Account GetById(Guid id);
        public bool Create(Account a);
        // Phương thức Sửa
        public bool Update(Account a);
        // Phương thức xóa
        public bool Delete(Guid id);
    }
}
