using MCV.Models;

namespace MCV.Services.IService
{
    public interface ICartDetailService
    {
        public List<CartDetail> GetAll();
        public CartDetail GetById(Guid id);
        public bool Create(CartDetail a);
        // Phương thức Sửa
        public bool Update(CartDetail a);
        // Phương thức xóa
        public bool Delete(Guid id);
    }
}
