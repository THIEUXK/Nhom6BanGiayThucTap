namespace MCV.Models
{
    public class Order
    {
        public Guid id { get; set; }
        public Guid? AccountId { get; set; }
        public string Code { get; set; }
        public string CustomerName { get; set; }
        public int PhoneNumber { get; set; }
        public string Address { get; set; }
        public float ShipFee { get; set; }
        public float MoneyReduce { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime PayDate { get; set; }
        public DateTime ShipDate { get; set; }
        public DateTime ReceiveDate { get; set; }
        public bool Status { get; set; }


        public virtual IQueryable<OrderDetail>? Details { get; set; }
        public virtual IQueryable<PaymentMethod>? PaymentMethods { get; set; }
        public virtual Account? Account { get; set; }

    }
}
    