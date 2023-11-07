using BuisnessLogicLayer.DTO;
using BuisnessLogicLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuisnessLogicLayer.Services
{
    public class ReportService : IReportService
    {
        private readonly IUserService _userService;

        public ReportService(IUserService userService)
        {
            _userService = userService;
        }

        public IEnumerable<ReportDTO> Averagesalary()
        {
            var users = _userService.GetUsers();
            var divisions = _userService.GetDivisions();

            var result = new List<ReportDTO>();

            foreach (var division in divisions)
            {
                var temp = users.Where(d => d.Divisions.Any(p => p.Id == division.Id));
                result.Add(new()
                {
                    AverageSalary = temp.Average(u => u.Salary),
                    Division = division.Name
                });
            }

            return result.OrderBy(p => p.Division);
        }

        public IEnumerable<ReportDTO> FilterAverageSalary(FiltredDataDTO filter)
        {
            var temp = Averagesalary();
            var result = temp.Where(avg => filter.MinSalary <= avg.AverageSalary && avg.AverageSalary <= filter.MaxSalary);
            return result.OrderBy(d => d.Division);
        }
    }
}
