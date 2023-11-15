using MCV.Models;

namespace MCV.ViewModel.HoaDon
{
    public class HoaDonHungView
    {
        public Order Order { get; set; }
        public Address Address { get; set; }
        public PaymentMethod PaymentMethod { get; set; }
        public Account Account { get; set; }

    }
}
