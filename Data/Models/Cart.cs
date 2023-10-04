namespace MCV.Models
{
    public class Cart
    {
        public Guid id { get; set; }
        public Guid? AccountId { get; set; }
        public bool Status { get; set; }

        public List<CartDetail> Details { get; set; }
        public Account? Account { get; set; }
        
    }
}
