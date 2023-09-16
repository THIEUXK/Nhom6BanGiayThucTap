using MCV.Models;
using MCV.Models.DBnhom6;
using MCV.Services.IService;

namespace MCV.Services
{
    public class BrandService:IBrandService
    {
        public DBnhom6TT _db;
        public BrandService()
        {
            _db = new DBnhom6TT();
        }
        public List<Brand> GetAll()
        {
            return _db.Brands.ToList();
        }

        public Brand GetById(Guid id)
        {
            return GetAll().FirstOrDefault(c => c.id == id);
        }

        public bool Create(Brand a)
        {
            try
            {
                _db.Brands.Add(a);
                _db.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool Update(Brand a)
        {
            try
            {
                _db.Brands.Update(a);
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
                _db.Brands.Remove(b);
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
