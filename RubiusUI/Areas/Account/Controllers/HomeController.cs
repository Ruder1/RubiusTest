using Microsoft.AspNetCore.Mvc;

namespace RubiusUI.Areas.Account.Controllers
{
	public class HomeController : Controller
	{
		[Area("Account")]
		public IActionResult Index()
		{
			return View();
		}
	}
}
