using MCV.Models;

namespace MCV.Services.IService
{
    public interface IShoeService
    {
        public List<Shoe> GetAll();
        public Shoe GetById(Guid id);
        public bool Create(Shoe a);
        // Phương thức Sửa
        public bool Update(Shoe a);
        // Phương thức xóa
        public bool Delete(Guid id);
    }
}
