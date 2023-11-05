using MCV.Models;
using MCV.Models.DBnhom6;
using MCV.Services.IService;

namespace MCV.Services
{
    public class ShoeDetailService:IShoeDetailService
    {
        public DBnhom6TT _db;

        public ShoeDetailService()
        {
            _db = new DBnhom6TT();
        }
        public List<ShoeDetail> GetAll()
        {
            return _db.ShoeDetail.ToList();
        }

        public ShoeDetail GetById(Guid id)
        {
            return GetAll().FirstOrDefault(c => c.id == id);
        }

        public bool Create(ShoeDetail a)
        {
            try
            {
                _db.ShoeDetail.Add(a);
                _db.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool Update(ShoeDetail a)
        {
            try
            {
                _db.ShoeDetail.Update(a);
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
                _db.ShoeDetail.Remove(b);
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
