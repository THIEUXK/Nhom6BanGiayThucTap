namespace MCV.Models
{
    public class PaymentMethod
    {
        public Guid id { get; set; }
        public string Method { get; set; }

        public bool Status { get; set; }
        public string Note { get; set; }

        public virtual List<Order>? Orders { get; set; }
    }
}
