using Microsoft.AspNetCore.Mvc.Rendering;

namespace MCV.ViewModel
{
    public class BanHangView
    {
        public List<SelectListItem> ShoeItems { get; set; }
        public List<SelectListItem> SizeItems { get; set; }
        public List<SelectListItem> CategoryItems { get; set; }
        public List<SelectListItem> BrandItems { get; set; }
        public List<SelectListItem> ColorItems { get; set; }

        public Guid id { get; set; }

        public Guid? ShoeId { get; set; }
        public Guid? SizeId { get; set; }
        public Guid? BrandId { get; set; }
        public Guid? CategoryId { get; set; }

        public Guid? ColorId { get; set; }
        public string Code { get; set; }

        public int PriceInput { get; set; }

        public int PriceOutput { get; set; }
        public int Quantity { get; set; }
        public bool Status { get; set; }
    }
}
