using MCV.Models;

namespace MCV.Services.IService
{
    public interface IBrandService
    {
        public List<Brand> GetAll();
        public Brand GetById(Guid id);
        public bool Create(Brand a);
        // Phương thức Sửa
        public bool Update(Brand a);
        // Phương thức xóa
        public bool Delete(Guid id);
    }
}
