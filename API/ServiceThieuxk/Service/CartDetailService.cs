using MCV.Models;
using MCV.Models.DBnhom6;
using MCV.Services.IService;
using Microsoft.EntityFrameworkCore;

namespace MCV.Services.Service
{
    public class CartDetailService : ICartDetailService
    {
        public DBnhom6TT _db;
        public CartDetailService()
        {
            _db = new DBnhom6TT();

        }
        public List<CartDetail> GetAll()
        {
            return _db.CartDetail.Include(c=>c.ShoeDetail.Shoe).Include(c => c.ShoeDetail).ToList();
        }

        public CartDetail GetById(Guid id)
        {
            return GetAll().FirstOrDefault(c => c.id == id);
        }

        public bool Create(CartDetail a)
        {
            try
            {
                _db.CartDetail.Add(a);
                _db.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool Update(CartDetail a)
        {
            try
            {
                _db.CartDetail.Update(a);
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
                _db.CartDetail.Remove(b);
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
