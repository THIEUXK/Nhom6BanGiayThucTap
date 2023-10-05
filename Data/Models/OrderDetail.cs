namespace MCV.Models
{
    public class OrderDetail
    {
        public Guid id { get; set; }
        public Guid? ShoeDetailId { get; set; }
        public Guid? OrderId { get; set; }
        public int Quantity { get; set; }
        public float Price { get; set; }
        public float Discount { get; set; }
        public bool Status { get; set; }

        public virtual Order? Order { get; set; }
        public virtual ShoeDetail? ShoeDetail { get; set; }

    }
}
