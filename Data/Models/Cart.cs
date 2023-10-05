namespace MCV.Models
{
    public class Cart
    {
        public Guid id { get; set; }
        public Guid? AccountId { get; set; }
        public bool Status { get; set; }

        public virtual IQueryable<CartDetail>? Details { get; set; }
        public virtual Account? Account { get; set; }
        
    }
}
