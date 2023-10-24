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

        public UserPageDTO GetPage(int page, int pageSize)
        {
            var source = Database.Pagination.GetPage(page, pageSize);

            var mapper = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<User, UserDTO>();
                cfg.CreateMap<Division, DivisionDTO>();
            })
                .CreateMapper();
            var user = mapper.Map<List<User>, List<UserDTO>>(source.ToList());

            var count = user.Count();
            var items = user.Skip((page - 1) * pageSize).Take(pageSize);

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
