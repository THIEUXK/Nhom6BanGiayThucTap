using MCV.Models;

namespace MCV.Services.IService
{
    public interface IAddressService
    {
        public List<Address> GetAll();
        public Address GetById(Guid id);
        public bool Create(Address a);
        // Phương thức Sửa
        public bool Update(Address a);
        // Phương thức xóa
        public bool Delete(Guid id);
    }
}
