using MCV.Models;
using MCV.Models.DBnhom6;
using MCV.Services.IService;

namespace MCV.Services.Service
{
    public class AddressService : IAddressService
    {
        public DBnhom6TT _db;

        public AddressService()
        {
            _db = new DBnhom6TT();
        }
        public List<Address> GetAll()
        {
            return _db.Address.ToList();
        }

        public Address GetById(Guid id)
        {
            return GetAll().FirstOrDefault(c => c.id == id);
        }

        public bool Create(Address a)
        {
            try
            {
                _db.Address.Add(a);
                _db.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool Update(Address a)
        {
            try
            {
                _db.Address.Update(a);
                _db.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool Delete(Guid id)
        {
            try
            {
                var b = GetById(id);
                _db.Address.Remove(b);
                _db.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
    }
}
