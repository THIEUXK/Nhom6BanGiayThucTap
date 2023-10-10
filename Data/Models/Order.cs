namespace MCV.Models
{
    public class Order
    {
        public Guid id { get; set; }
        public Guid? AccountId { get; set; }
        public Guid? PaymentMethodId { get; set; }
        public Guid? AccouAddressId  { get; set; }

        public string Code { get; set; }
        public string CustomerName { get; set; }
        public int PhoneNumber { get; set; }
        public float ShipFee { get; set; }
        public float MoneyReduce { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime PayDate { get; set; }
        public DateTime ShipDate { get; set; }
        public DateTime ReceiveDate { get; set; }
        public bool Status { get; set; }


        public virtual IQueryable<OrderDetail>? Details { get; set; }
        public virtual Account? Account { get; set; }
        public virtual PaymentMethod? PaymentMethod { get; set; }
        public virtual Address? Addresss { get; set; }

    }
}
    