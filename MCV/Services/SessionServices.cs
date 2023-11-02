using MCV.Models;
using Newtonsoft.Json;

namespace MCV.Services
{
	public class SessionServices
	{
		public static void SetObjToJson(ISession session, string key, object value)
		{
			// Obj value là dữ liệu bạn muốn thêm vào Session
			// Chuyển đổi dữ liệu đó sang dạng JsonString
			var jsonString = JsonConvert.SerializeObject(value);
			session.SetString(key, jsonString);
		}
		// Lấy và đưa dữ liệu từ session về dạng List<obj>

		public static List<Account> LuuAcc(ISession session, string key)
		{
			var data = session.GetString(key); // Đọc dữ liệu từ Session ở dạng chuỗi
			if (data != null)
			{
				var listObj = JsonConvert.DeserializeObject<List<Account>>(data);
				return listObj;
			}
			else return new List<Account>();
		}
	}
}
