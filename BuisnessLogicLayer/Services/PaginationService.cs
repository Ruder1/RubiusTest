using AutoMapper;
using BuisnessLogicLayer.DTO;
using BuisnessLogicLayer.Interfaces;
using DataAccessLayer.Entities;
using DataAccessLayer.Interfaces;

namespace BuisnessLogicLayer.Services
{
    public class PaginationService : IPaginationService
    {
        private IUnitOfWork Database { get; set; }

        public PaginationService(IUnitOfWork uow)
        {
            Database = uow;
        }

        public UserPageDTO GetPage(IEnumerable<UserDTO> userList, int page, int pageSize)
        {

            var count = userList.Count();
            var items = userList.Skip((page - 1) * pageSize).Take(pageSize);

            PagesDTO pageDTO = new PagesDTO(count, page, pageSize);
            UserPageDTO userPage = new UserPageDTO(items, pageDTO);
            return userPage;
        }

        public void Dispose()
        {
            Database.Dispose();
        }
    }
}
