using BuisnessLogicLayer.DTO;

namespace RubiusUI.Areas.Model
{
    public class FilteredDataViewModel
    {
        public int? MinSalary { get; set; }

        public int? MaxSalary { get; set; }

        public string? SearchString { get; set; }

        public DivisionDTO? Division { get; set; }
    }
}
