using MCV.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MCV.ViewModel
{
	public class ChiTietSanPhamBanvView
	{
		public List<SanPhamBan> BanHangViews { get; set; }
		public List<SelectListItem> SizeItems { get; set; }
		public Guid? SizeId { get; set; }
		public Shoe Shoe { get; set; } 
	}
}
