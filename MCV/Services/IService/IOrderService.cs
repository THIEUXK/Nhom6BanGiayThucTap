using MCV.Models;

namespace MCV.Services.IService
{
    public interface IOrderService
    {
        public List<Order> GetAll();
        public Order GetById(Guid id);
        public bool Create(Order a);
        // Phương thức Sửa
        public bool Update(Order a);
        // Phương thức xóa
        public bool Delete(Guid id);
    }
}
