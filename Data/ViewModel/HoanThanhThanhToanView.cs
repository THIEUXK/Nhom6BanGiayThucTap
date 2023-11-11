using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.ViewModel
{
    public class HoanThanhThanhToanView
    {
        public string name { get; set; }
        public string DiachiNhanChiTiet { get; set; }
        public string Sodienthoai { get; set; }
        public string Email { get; set; }
        public string addDiaChi { get; set; }
        public Guid IdAddress { get; set; }
        public Guid IdPaymentMethod { get; set; }
        public float tienship { get; set; }
        public float tongtien { get; set; }
        public Guid IdKhachhang { get; set; }
    }
}
