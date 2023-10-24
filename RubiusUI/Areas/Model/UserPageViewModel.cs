namespace RubiusUI.Areas.Model
{
    public class UserPageViewModel
    {
        public IEnumerable<UserViewModel> Users { get; init; }
        public PageViewModel Pages{ get; init; }
    }
}
