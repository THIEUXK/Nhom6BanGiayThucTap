using MCV.Models;
using MCV.Models.DBnhom6;
using MCV.Services.IService;

namespace MCV.Services.Service
{
    public class ShoeService : IShoeService
    {
        public DBnhom6TT _db;

        public ShoeService()
        {
            _db = new DBnhom6TT();
        }
        public List<Shoe> GetAll()
        {
            return _db.Shoe.ToList();
        }

        public Shoe GetById(Guid id)
        {
            return GetAll().FirstOrDefault(c => c.id == id);
        }

        public bool Create(Shoe a)
        {
            try
            {
                _db.Shoe.Add(a);
                _db.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool Update(Shoe a)
        {
            try
            {
                _db.Shoe.Update(a);
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
                _db.Shoe.Remove(b);
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
