namespace MCV.Models
{
    public class ShoeDetail
    {
        public Guid id { get; set; }

        public Guid? ShoeId { get; set; }
        public Guid? SizeId { get; set; }
        public Guid? BrandId { get; set; }
        public Guid? CategoryId { get; set; }

        public Guid? ColorId { get; set; }
        public string Code { get; set; }

        public int PriceInput { get; set; }

        public int PriceOutput { get; set; }
        public int Quantity { get; set; }
        public bool Status { get; set;}

       

        public List<Image> Images { get; set; }
        public Size? Size { get; set; }
        public Category? Category { get; set; }
        public Brand? Brand { get; set; }
        public Color? Color { get; set; }
        public Shoe? Shoe { get; set; }

        public List<CartDetail> Carts { get; set; }

        public List<OrderDetail> OrderDetails { get; set; }
    }
}
