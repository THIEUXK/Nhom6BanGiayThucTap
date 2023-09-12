namespace MCV.Models
{
    public class Size
    {
        public Guid id { get; set; }

        public string name { get; set; }

        public bool Status { get; set; }

        public List<ShoeDetail> PhanLoaiSps { get; set; }
    }
}
