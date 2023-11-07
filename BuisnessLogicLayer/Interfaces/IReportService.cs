using BuisnessLogicLayer.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuisnessLogicLayer.Interfaces
{
    public interface IReportService
    {

        public IEnumerable<ReportDTO> Averagesalary();

        public IEnumerable<ReportDTO> FilterAverageSalary(FiltredDataDTO filter);
    }
}
