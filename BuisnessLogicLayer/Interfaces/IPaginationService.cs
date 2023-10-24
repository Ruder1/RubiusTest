using BuisnessLogicLayer.DTO;

namespace BuisnessLogicLayer.Interfaces
{
    public interface IPaginationService:IDisposable
    {
        public UserPageDTO GetPage(IEnumerable<UserDTO> userList, int page, int pageSize);
    }
}
