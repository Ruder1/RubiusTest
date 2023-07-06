using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using Infrastructure;
using System.Data;
using Microsoft.AspNetCore.Http.HttpResults;
using Serilog;
using RubiusUI.Services.Logging;

namespace RubiusUI.Areas.HomePage.Controllers
{

    /// <summary>
	/// Контроллер для отображения начальной страницы
	/// </summary>
    [ApiController]
    [Area("HomePage")]
	[Route("api/v1/[controller]/[action]")]
    [Produces("application/json")]
    public class HomeController : Controller
	{
        private readonly Logger _logger = new Logger();
        /// <summary>
        /// Выводит страницу Index
        /// </summary>
        /// <returns></returns>
        [HttpGet]
		public IActionResult Index()
		{
			return View();
		}
        
        
        [HttpGet]
        public ActionResult<string> Check(int? number)
        {            
            string check = $"Proverka {number}";
            return check;
        }

        [HttpGet]
        public IDbConnection GetConnection()
        {
            _logger.InfoLogg();
            var check = Connection.GetConnection();
            return check;
        }

	}
}
