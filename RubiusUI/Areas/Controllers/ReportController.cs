using AutoMapper;
using BuisnessLogicLayer.Interfaces;
using Microsoft.AspNetCore.Mvc;
using RubiusUI.Areas.Model;

namespace RubiusUI.Areas.Controllers
{
    [Route("api/v1/[controller]/[action]")]
    [ApiController]
    public class ReportController : Controller
    {

        private readonly IUserService _userService;

        private readonly IFilterService _filterService;

        private readonly IMapper _mapper;

        public ReportController(IUserService userService, IFilterService filterService, IMapper mapper)
        {
            _userService = userService;
            _filterService = filterService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult AverageSalary()
        {
            var users = _userService.GetUsers();
            var divisions = _userService.GetDivisions();

            var result = new List<ReportViewModel>();

            foreach (var division in divisions)
            {
                var temp = users.Where(d => d.Divisions.Any(p => p.Id == division.Id));
                result.Add(new()
                {
                    AverageSalary = temp.Average(u => u.Salary),
                    Division = division.Name
                });
            }

            return Ok(result.OrderBy(p=>p.Division));
        }
    }
}
