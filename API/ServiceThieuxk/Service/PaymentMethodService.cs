using MCV.Models;
using MCV.Models.DBnhom6;
using MCV.Services.IService;

namespace MCV.Services.Service
{
    public class PaymentMethodService : IPaymentMethodService
    {
        public DBnhom6TT _db;

        public PaymentMethodService()
        {
            _db = new DBnhom6TT();

        }
        public List<PaymentMethod> GetAll()
        {
            return _db.PaymentMethod.ToList();
        }

        public PaymentMethod GetById(Guid id)
        {
            return GetAll().FirstOrDefault(c => c.id == id);
        }

        public bool Create(PaymentMethod a)
        {
            try
            {
                _db.PaymentMethod.Add(a);
                _db.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool Update(PaymentMethod a)
        {
            try
            {
                _db.PaymentMethod.Update(a);
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
                _db.PaymentMethod.Remove(b);
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
