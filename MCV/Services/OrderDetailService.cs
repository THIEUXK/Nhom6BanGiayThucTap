using MCV.Models;
using MCV.Models.DBnhom6;
using MCV.Services.IService;

namespace MCV.Services
{
    public class OrderDetailService:IOrderDetailService
    {
        public DBnhom6TT _db;

        public OrderDetailService()
        {
            _db = new DBnhom6TT();
        }
        public List<OrderDetail> GetAll()
        {
            return _db.OrderDetail.ToList();
        }

        public OrderDetail GetById(Guid id)
        {
            return GetAll().FirstOrDefault(c => c.id == id);
        }

        public bool Create(OrderDetail a)
        {
            try
            {
                _db.OrderDetail.Add(a);
                _db.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool Update(OrderDetail a)
        {
            try
            {
                _db.OrderDetail.Update(a);
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
                _db.OrderDetail.Remove(b);
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
