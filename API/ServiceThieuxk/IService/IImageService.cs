using MCV.Models;

namespace MCV.Services.IService
{
    public interface IImageService
    {
        public List<Image> GetAll();
        public Image GetById(Guid id);
        public bool Create(Image a);
        // Phương thức Sửa
        public bool Update(Image a);
        // Phương thức xóa
        public bool Delete(Guid id);
    }
}
