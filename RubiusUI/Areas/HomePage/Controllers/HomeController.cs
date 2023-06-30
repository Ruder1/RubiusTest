using Microsoft.AspNetCore.Mvc;

namespace RubiusUI.Areas.HomePage.Controllers
{
	public class HomeController : Controller
	{
		[Area("HomePage")]
		public IActionResult Index()
		{
			return View();
		}
	}
}
