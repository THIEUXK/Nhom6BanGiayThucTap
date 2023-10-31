namespace MCV.Models
{
    public class Shoe
    {
        public Guid id { get; set; }

        public string name { get; set; }

		public bool Status { get; set; }
		public string avata { get; set; }

        public string Code { get; set; }

        public int PriceInput { get; set; }

        public int PriceOutput { get; set; }

        public virtual List<ShoeDetail>? ShoeDetails { get; set; }
    }
}
