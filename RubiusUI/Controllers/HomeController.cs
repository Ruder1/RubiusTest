﻿using Microsoft.AspNetCore.Mvc;

namespace RubiusUI.Controllers
{
	public class HomeController : Controller
	{
		[Route("Home/Index")]
		public IActionResult Index()
		{
			return View();
		}
	}
}
