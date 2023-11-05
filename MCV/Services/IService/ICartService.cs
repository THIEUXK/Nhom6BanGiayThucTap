using MCV.Models;

namespace MCV.Services.IService
{
    public interface ICartService
    {
        public List<Cart> GetAll();
        public Cart GetById(Guid id);
        public bool Create(Cart a);
        // Phương thức Sửa
        public bool Update(Cart a);
        // Phương thức xóa
        public bool Delete(Guid id);
    }
}
