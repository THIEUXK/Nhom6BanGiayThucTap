using MCV.Models;
using MCV.Models.DBnhom6;
using MCV.Services.IService;

namespace MCV.Services.Service
{
    public class OrderService : IOrderService
    {
        public DBnhom6TT _db;

        public OrderService()
        {
            _db = new DBnhom6TT();
        }
        public List<Order> GetAll()
        {
            return _db.Order.ToList();
        }

        public Order GetById(Guid id)
        {
            return GetAll().FirstOrDefault(c => c.id == id);
        }

        public bool Create(Order a)
        {
            try
            {
                _db.Order.Add(a);
                _db.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool Update(Order a)
        {
            try
            {
                _db.Order.Update(a);
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
                _db.Order.Remove(b);
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
