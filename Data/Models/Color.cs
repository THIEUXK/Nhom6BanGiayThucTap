namespace MCV.Models
{
    public class Color
    {
        public Guid id { get; set; }

        public string name { get; set; }

        public bool Status { get; set; }

        public virtual IQueryable<ShoeDetail> ShoeDetails { get; set; }
    }
}
