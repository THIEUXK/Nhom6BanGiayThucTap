using MCV.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MCV.ViewModel
{
    public class ListGioHangView
    {
        public GioHangHungView GioHangHungView { get; set; }
        public List<GioHangHungView> gioHangHungViews { get; set; }
        public List<SelectListItem> PaymentMethodItems { get; set; }
        public List<SelectListItem> AddressItems { get; set; }
        public Account Account { get; set; }
        public Address address { get; set; }
        public Guid IdAddress { get; set; }
        public Guid IdPaymentMethod { get; set; }
        public float Tong { get; set; }

    }
}
