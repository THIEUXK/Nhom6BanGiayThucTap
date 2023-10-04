namespace MCV.Models
{
    public class PaymentMethod
    {
        public Guid id { get; set; }
        public Guid? Orderid { get; set; }
        public string Method { get; set; }

        public float Total { get; set; }
        public bool Status { get; set; }
        public string Note { get; set; }

        public Order? Order { get; set; }
    }
}
