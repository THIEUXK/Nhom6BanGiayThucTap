namespace MCV.Models
{
    public class Cart
    {
        public Guid id { get; set; }
        public Guid? AccountId { get; set; }
        public bool Status { get; set; }
    }
}
