namespace BuisnessLogicLayer.DTO
{
    public class UserDTO
    {
        public int Id { get; init; }
        public string Surname { get; init; }
        public string Name { get; init; }
        public string LastName { get; init; }
        public string Email { get; init; }
        public int Salary { get; init; }
        public List<DivisionDTO> Divisions { get; init; } = new();
    }
}