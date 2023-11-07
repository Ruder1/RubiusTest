using AutoMapper;
using BuisnessLogicLayer.DTO;
using BuisnessLogicLayer.Interfaces;
using Microsoft.AspNetCore.Mvc;
using RubiusUI.Areas.Model;

namespace RubiusUI.Areas.Controllers
{
    [Route("api/v1/[controller]/[action]")]
    [ApiController]
    public class ReportController : Controller
    {

        private readonly IMapper _mapper;

        private readonly IReportService _reportService;

        public ReportController( IMapper mapper, IReportService reportService)
        {
            _mapper = mapper;
            _reportService = reportService;
        }

        [HttpGet]
        public IActionResult AverageSalary()
        {
            var tempAvg = _reportService.Averagesalary();

            var result = _mapper.Map<IEnumerable<ReportDTO>, IEnumerable<ReportViewModel>>(tempAvg);

            return Ok(result);
        }

        [HttpPost]
        public IActionResult FilterAverageSalary(FilteredDataViewModel filter)
        {
            var filterDTO = _mapper.Map<FilteredDataViewModel, FiltredDataDTO>(filter);

            var tempAvg = _reportService.FilterAverageSalary(filterDTO);

            var result = _mapper.Map<IEnumerable<ReportDTO>, IEnumerable<ReportViewModel>>(tempAvg);

            return Ok(result);
        }
    }
}
