using BuisnessLogicLayer.DTO;

namespace RubiusUI.Areas.Model
{
    public class DivisionViewModel
    {
        public int Id { get; init; }
        public string Name { get; init; }

        public DivisionViewModel? Parent { get; init; }

        public List<DivisionViewModel> Children { get; init; } = new List<DivisionViewModel>();
    }
}
