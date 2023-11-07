using DataAccessLayer.Entities;

namespace BuisnessLogicLayer.DTO
{
    public class DivisionDTO
    {
        public int Id { get; init; }
        public string Name { get; init; }

        public DivisionDTO? Parent { get; init; }

        public List<DivisionDTO> Children { get; init; } = new List<DivisionDTO>();
    }
}
