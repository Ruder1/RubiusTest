using Microsoft.AspNetCore.Mvc;

namespace RubiusUI.Areas.HomePage.Controllers
{
    
    [ApiController]
    [Area("HomePage")]
    public class HomeController : Controller
	{

		[HttpGet]
		[Route("{area?}/Home")]
		public IActionResult Index()
		{
			return View();
		}
	}
}
