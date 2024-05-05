using Admin_Hotel.Models;


namespace Admin_Hotel.Helper
{
	public static class Commons
	{
		public static bool CheckAccount(string user, string password)
		{
			DBContext db = new DBContext();
			var userCheck = db.Users.FirstOrDefault(u => u.UserName == user && u.Password == password);

			bool check = false;

			if (user != null)
			{
				check = true;
			}
			else
			{
				check = false;
			}

			return check;
		}
	}
}
