using MCV.Models;
using MCV.Models.DBnhom6;
using MCV.Services.IService;

namespace MCV.Services.Service
{
    public class CartService : ICartService
    {
        public DBnhom6TT _db;

        public CartService()
        {
            _db = new DBnhom6TT();

        }
        public List<Cart> GetAll()
        {
            return _db.Carts.ToList();
        }

        public Cart GetById(Guid id)
        {
            return GetAll().FirstOrDefault(c => c.id == id);
        }

        public bool Create(Cart a)
        {
            try
            {
                _db.Carts.Add(a);
                _db.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool Update(Cart a)
        {
            try
            {
                _db.Carts.Update(a);
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
                _db.Carts.Remove(b);
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
