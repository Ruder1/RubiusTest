using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuisnessLogicLayer.DTO
{
    public class FiltredDataDTO
    {
        public int? MinSalary { get; set; }

        public int? MaxSalary { get; set; }

        public string? SearchString { get; set; }

        public List<int>? Divisions { get; set; }
    }
}
