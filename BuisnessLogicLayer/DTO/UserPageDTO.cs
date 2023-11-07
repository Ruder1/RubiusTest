namespace BuisnessLogicLayer.DTO
{
    public class UserPageDTO
    {
        public IEnumerable<UserDTO> Users { get; }
        public PagesDTO Pages { get; }
        public UserPageDTO(IEnumerable<UserDTO> users, PagesDTO viewModel)
        {
            Users = users;
            Pages = viewModel;
        }
    }
}
