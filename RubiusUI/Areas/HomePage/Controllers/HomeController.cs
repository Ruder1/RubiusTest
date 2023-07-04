﻿using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

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
        /// <summary>
        /// Выводит страницу Index
        /// </summary>
        /// <returns></returns>
        [HttpGet]
		[Route("Index")]
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
	}
}
