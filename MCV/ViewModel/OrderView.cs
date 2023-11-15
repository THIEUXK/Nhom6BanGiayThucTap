using System.Collections;
using MCV.Models;

namespace MCV.ViewModel
{
    public class OrderView : IEnumerable
    {
        public List<Order> Orders { get; set; }
        public List<OrderDetail> OrderDetails { get; set; }

        public Order Order { get; set; }
        public IEnumerator GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
