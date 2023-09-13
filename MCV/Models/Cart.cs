namespace MCV.Models
{
    public class Cart
    {
        public Guid id { get; set; }
        public bool Status { get; set; }

        public List<CartDetail> Details { get; set; }
        
    }
}
