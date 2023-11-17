using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppData.ViewModels.ThongKe
{
    public  class ThongKeKHMuaNhieu
    {
       
        public Guid idkh { get; set; }
        public string Ten { get; set; }
        public string SDT { get; set; }
        public string Email { get; set; }
        public int SoDonMua { get; set; }
        public int TongSoTien { get; set; }
        public DateTime Ngay { get; set; }
    }
}
