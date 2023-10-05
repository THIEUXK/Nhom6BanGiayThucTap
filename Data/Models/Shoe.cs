namespace MCV.Models
{
    public class Shoe
    {
        public Guid id { get; set; }

        public string name { get; set; }

        public bool Status { get; set; }

        public virtual List<ShoeDetail>? ShoeDetails { get; set; }
    }
}
