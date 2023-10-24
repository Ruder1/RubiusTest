using BuisnessLogicLayer.DTO;

namespace BuisnessLogicLayer.Interfaces
{
    public interface IPaginationService:IDisposable
    {
        public UserPageDTO GetPage(int page, int pageSize);
    }
}
