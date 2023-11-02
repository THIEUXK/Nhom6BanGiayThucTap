using MCV.Models;

namespace MCV.Services.IService
{
    public interface IColorService
    {
        public List<Color> GetAll();
        public Color GetById(Guid id);
        public bool Create(Color a);
        // Phương thức Sửa
        public bool Update(Color a);
        // Phương thức xóa
        public bool Delete(Guid id);
    }
}
