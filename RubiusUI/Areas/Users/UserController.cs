using Microsoft.AspNetCore.Mvc;

namespace RubiusUI.Areas.Users
{
    [Route("api/v1/[controller]/[action]")]
    [ApiController]
    public class UserController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
           return Ok("Cool Story");
        }
    }
}
