using Microsoft.AspNetCore.Mvc;

namespace LawTrack.Controllers
{
	public class LogInController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
