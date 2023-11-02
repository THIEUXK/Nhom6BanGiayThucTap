using MCV.Models;

namespace MCV.Services.IService
{
    public interface IRoleService
    {
        public List<Role> GetAll();
        public Role GetById(Guid id);
        public bool Create(Role a);
        // Phương thức Sửa
        public bool Update(Role a);
        // Phương thức xóa
        public bool Delete(Guid id);
    }
}
