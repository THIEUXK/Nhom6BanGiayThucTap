using MCV.Models;

namespace MCV.Services.IService
{
    public interface IOrderDetailService
    {
        public List<OrderDetail> GetAll();
        public OrderDetail GetById(Guid id);
        public bool Create(OrderDetail a);
        // Phương thức Sửa
        public bool Update(OrderDetail a);
        // Phương thức xóa
        public bool Delete(Guid id);
    }
}
