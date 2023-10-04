namespace MCV.Models
{
    public class CartDetail
    {
        public Guid id { get; set; }
        public Guid? CartId { get; set; }
        public Guid? ShoeDetailId { get; set; }
        public int Quantity { get; set; }

        public Cart Cart { get; set; }
        public ShoeDetail ShoeDetail { get; set; }

    }
}
