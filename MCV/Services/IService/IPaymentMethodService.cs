using MCV.Models;

namespace MCV.Services.IService
{
    public interface IPaymentMethodService
    {
        public List<PaymentMethod> GetAll();
        public PaymentMethod GetById(Guid id);
        public bool Create(PaymentMethod a);
        // Phương thức Sửa
        public bool Update(PaymentMethod a);
        // Phương thức xóa
        public bool Delete(Guid id);
    }
}
