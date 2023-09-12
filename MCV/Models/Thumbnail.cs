namespace MCV.Models
{
    public class Thumbnail
    {
        public Guid id { get; set; }
        public Guid? ShoeDetailId { get; set; }
        public string ImgUrl { get; set; }

        public ShoeDetail? ShoeDetail { get; set; }
    }
}
