using MCV.Models;

namespace MCV.ViewModel
{
    public class GioHangHungView
    {
        public CartDetail CartDetail { get; set; }
        public Cart Cart { get; set; }
        public ShoeDetail ShoeDetail { get; set; }   
        public Shoe Shoes { get; set; }
        public Size Sizes { get; set; }
        public Category Categories { get; set; }
        public Brand Brands { get; set; }
        public Color Color { get; set; }
    }
}
