using MCV.Models;

namespace MCV.Services.IService
{
    public interface ISizeService
    {
        public List<Size> GetAll();
        public Size GetById(Guid id);
        public bool Create(Size a);
        // Phương thức Sửa
        public bool Update(Size a);
        // Phương thức xóa
        public bool Delete(Guid id);
    }
}
