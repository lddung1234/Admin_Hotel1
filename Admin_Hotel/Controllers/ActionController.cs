using Admin_Hotel.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Admin_Hotel.Controllers
{
	public class ActionController : Controller
	{
		DBContext db = new DBContext();
		IWebHostEnvironment env;
		public ActionController(IWebHostEnvironment env)
		{
			this.env = env;
		}
		[Route("/dang-nhap", Name = "DangNhap")]
		public IActionResult Index()
		{
			ViewBag.LoginMessage = "Mời bạn đăng nhập";

			return View();
		}
		[HttpPost]
		[Route("/dang-nhap", Name = "DangNhap")]
		public IActionResult Index(User data)
		{
			if (data.Password == null)
			{
				ViewBag.LoginClass = "alert-danger";
				ViewBag.LoginMessage = "Vui lòng nhập Password";
				return View();
			}
			if (data.UserName == null)
			{
				ViewBag.LoginClass = "alert-danger";
				ViewBag.LoginMessage = "Vui lòng nhập UserName";
				return View();
			}
			var query = db.Users
						  .SingleOrDefault(x => x.UserName == data.UserName && x.Password == data.Password);
			if (query != null)
			{
				if (query.FullName != null)
				{
					HttpContext.Session.SetString("fullName", query.FullName);
				}
				if (query.Avatar != null)
				{
					HttpContext.Session.SetString("avatar", query.Avatar);
				}
				if (query.IsAdmin != null)
				{
					HttpContext.Session.SetString("isAdmin", query.IsAdmin.ToString());
				}
				HttpContext.Session.SetString("userName", query.UserName);

				return RedirectToRoute("Home");
			}
			ViewBag.LoginClass = "alert-danger";
			ViewBag.LoginMessage = "Tài khoản không hợp lệ";
			return View();
		}

		[Route("/dang-ki", Name = "DangKi")]
		public IActionResult Register()
		{
			ViewBag.RegisterMessage = "Vui lòng điền đầy đủ thông tin";
			return View();
		}
		[HttpPost]
		[Route("/dang-ki", Name = "DangKi")]
		public async Task<IActionResult> Register(User data, string pass1, IFormFile avatar)
		{
			if (data.FullName == null)
			{
				ViewBag.RegisterClass = "alert-danger";
				ViewBag.RegisterMessage = "Vui lòng nhập FullName";
				return View();
			}
			if (data.UserName == null)
			{
				ViewBag.RegisterClass = "alert-danger";
				ViewBag.RegisterMessage = "Vui lòng nhập UserName";
				return View();
			}
			if (data.Password == null)
			{
				ViewBag.RegisterClass = "alert-danger";
				ViewBag.RegisterMessage = "Vui lòng nhập Password";
				return View();
			}
			if (avatar == null)
			{
				ViewBag.RegisterClass = "alert-danger";
				ViewBag.RegisterMessage = "Vui lòng chọn avatar";
				return View();
			}
			if (db.Users.Any(x => x.UserName == data.UserName))
			{
				ViewBag.RegisterMessage = "Tên người dùng đã tồn tại.";
				return View();
			}

			var fileExtension = Path.GetExtension(avatar.FileName).ToLowerInvariant();
			var uploadFolder = Path.Combine(env.WebRootPath, $"assets/img/profiles");
			var fileName = $"{Guid.NewGuid()}{fileExtension}";
			var filePath = Path.Combine(uploadFolder, fileName);
			using (var stream = new FileStream(filePath, FileMode.Create))
			{
				await avatar.CopyToAsync(stream);
			}

			if (data.Password != pass1)
			{
				ViewBag.RegisterClass = "alert-danger";
				ViewBag.RegisterMessage = $"Vui lòng nhập khớp Password";
				return View();
			}

			var user = new User()
			{
				FullName = data.FullName,
				UserName = data.UserName,
				Password = data.Password,
				IsAdmin = data.IsAdmin ?? false,
				Avatar = Path.Combine("/assets/img/profiles/", fileName)
			};

			if (user.UserName != null)
			{
				db.Users.Add(user);

			}
			db.SaveChanges();
			ViewBag.RegisterMessage = "Đăng kí thành công!";
			return View();

		}
		[Route("/quen-mat-khau", Name = "QuenPassword")]
		public IActionResult ForgotPassword(string user)
		{
			var query = db.Users.SingleOrDefault(x => x.UserName.Equals(user));
			if (user != null)
			{
				if (query != null)
				{
					return RedirectToRoute("DoiPassword");
				}
				else
				{
					TempData["error-user"] = "Tên user không chính sác";
				}
			}

			return View();
		}
		[Route("/doi-mat-khau", Name = "DoiPassword")]
		public IActionResult ChangePassword()
		{
			ViewBag.ChangePasswordMessage = "Điền đầy đủ thông tin";
            return View();
		}
		[HttpPost]
		[Route("/doi-mat-khau", Name = "DoiPassword")]
		public IActionResult ChangePassword(string user, string pass, string pass1, string pass2)
		{
            if (pass == null)
            {
				ViewBag.RegisterClass = "alert-danger";
				ViewBag.ChangePasswordMessage = "Vui lòng nhập Password cũ";
                return View();
            }
            if (pass1 == null)
            {
				ViewBag.RegisterClass = "alert-danger";
				ViewBag.ChangePasswordMessage = "Vui lòng nhập Password";
                return View();
            }
            if (pass2 == null)
            {
				ViewBag.RegisterClass = "alert-danger";
				ViewBag.ChangePasswordMessage = "Vui lòng nhập lại Password";
                return View();
            }
            var query = db.Users.SingleOrDefault(x => x.UserName.Equals(user));
			if (query == null)
			{
				ViewBag.RegisterClass = "alert-danger";
				ViewBag.ChangePasswordMessage = "Đổi mật khẩu thất bại";
				return View();
			}
			if (query.Password != null && query.Password.Equals(pass))
			{
				if (pass2 == pass1 && pass1!=null && pass2 != null)
				{
					query.Password = pass1;
					db.SaveChanges();
					ViewBag.ChangePasswordMessage = "Đổi mật khẩu thành công";
					return View();
				}
				else
				{
					ViewBag.RegisterClass = "alert-danger";
					ViewBag.ChangePasswordMessage = "Mật khẩu mới không trùng khớp";
				}

			}
			else
			{
				ViewBag.RegisterClass = "alert-danger";
				ViewBag.ChangePasswordMessage = "Mật khẩu cũ không chính sác";
			}


			return View();
		}
		[Route("/khoa-man-hinh", Name = "Lookscreen")]
		public IActionResult Look()
		{

			return View();
		}
		[HttpPost]
		[Route("/khoa-man-hinh", Name = "Lookscreen")]
		public IActionResult Look(string user, string pass)
		{
			var query = db.Users.SingleOrDefault(x => x.UserName.Equals(user) && x.Password != null && x.Password.Equals(pass));

			if (query != null)
			{
				return RedirectToRoute("Home");
			}
			TempData["error"] = "Tài khoản hoặc mật khẩu không đúng";
			return View();
		}
		[Route("/profile", Name = "Profile")]
		public IActionResult Profile()
		{
			return View();
		}
		[Route("/profile-edit", Name = "ProfileEdit")]
		public IActionResult ProfileEdit()
		{
			return View();
		}

		[HttpGet]
		[Route("/dang-xuat", Name = "DangXuat")]
		public IActionResult Logout()
		{
			HttpContext.Session.Clear();
			return RedirectToRoute("DangNhap");
		}
	}
}
