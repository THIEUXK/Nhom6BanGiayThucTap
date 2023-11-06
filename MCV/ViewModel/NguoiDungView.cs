using MCV.Services;

namespace MCV.ViewModel
{
	public class NguoiDungView
	{
		public string Use { get; set; }
		public void luu(HttpContext httpContext)
		{
			List<Models.Account> acc = SessionServices.LuuAcc(httpContext.Session, "ACC1");
			if (acc.Count > 0)
			{
				this.Use = acc[0].Name;
			}
			else
			{
				Use = "1";
			}
			
		}
	}
}
