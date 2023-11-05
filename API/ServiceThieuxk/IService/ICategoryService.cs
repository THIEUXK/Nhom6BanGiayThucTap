using MCV.Models;

namespace MCV.Services.IService
{
    public interface ICategoryService
    {
        public List<Category> GetAll();
        public Category GetById(Guid id);
        public bool Create(Category a);
        // Phương thức Sửa
        public bool Update(Category a);
        // Phương thức xóa
        public bool Delete(Guid id);
    }
}
