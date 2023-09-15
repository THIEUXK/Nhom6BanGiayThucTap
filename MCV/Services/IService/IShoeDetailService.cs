using MCV.Models;

namespace MCV.Services.IService
{
    public interface IShoeDetailService
    {
        public List<ShoeDetail> GetAll();
        public ShoeDetail GetById(Guid id);
        public bool Create(ShoeDetail a);
        // Phương thức Sửa
        public bool Update(ShoeDetail a);
        // Phương thức xóa
        public bool Delete(Guid id);
    }
}
