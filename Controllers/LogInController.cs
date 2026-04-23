using Microsoft.AspNetCore.Mvc;

namespace LawTrack.Controllers
{
	public class LogInController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}

		[HttpPost]
		public IActionResult LogIn(string Username, string Password, bool RememberMe)
		{
			try
			{
				if (string.IsNullOrEmpty(Username) || string.IsNullOrEmpty(Password))
				{
					return Json(new { success = false, message = "Please fill all fields" });
				}

				// 🔐 Example login check (replace with your logic)
				if (Username == "admin" && Password == "123")
				{
					return Json(new { success = true });
				}

				return Json(new { success = false, message = "Invalid username or password" });
			}
			catch
			{
				return Json(new { success = false, message = "Server error" });
			}
		}

	}
}
