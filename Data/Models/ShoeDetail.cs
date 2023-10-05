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

       

        public virtual List<Image> Images { get; set; }
        public virtual Size? Size { get; set; }
        public virtual Category? Category { get; set; }
        public virtual Brand? Brand { get; set; }
        public virtual Color? Color { get; set; }
        public virtual Shoe? Shoe { get; set; }

        public virtual List<CartDetail>? Carts { get; set; }

        public virtual List<OrderDetail>? OrderDetails { get; set; }
    }
}
