using AutoMapper;
using BuisnessLogicLayer.DTO;
using BuisnessLogicLayer.Infrastructure;
using BuisnessLogicLayer.Interfaces;
using DataAccessLayer.Entities;
using DataAccessLayer.Interfaces;


namespace BuisnessLogicLayer.Services
{
    public class UserService : IUserService
    {
        private IUnitOfWork Database { get; set; }

        public UserService(IUnitOfWork uow)
        {
            Database = uow;
        }

        public IEnumerable<UserDTO> GetUsers()
        {
            var userDB = Database.Users.GetAll().ToList();
            // применяем автомаппер для проекции одной коллекции на другую

            var mapper = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<User, UserDTO>();
                cfg.CreateMap<Division, DivisionDTO>();
            })
                .CreateMapper();
            var user = mapper.Map<List<User>, List<UserDTO>>(userDB);
            return user;
        }

        public UserDTO GetUser(int? id)
        {
            if (id == null)
                throw new ValidationException("Не установлено id Пользователя", "");
            var user = Database.Users.Get(id.Value);
            if (user == null)
                throw new ValidationException("Пользователь не найден", "");

            var mapper = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<User, UserDTO>();
                cfg.CreateMap<Division, DivisionDTO>();
            })
                .CreateMapper();

            var userResult = mapper.Map<User, UserDTO>(user);
            return userResult;
        }

        public void CreateUser(UserDTO userDto)
        {
            // валидация
            if (userDto == null)
                throw new ValidationException("Пользователь не найден", "");

            var mapper = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<UserDTO, User>();
                cfg.CreateMap<DivisionDTO, Division>();
            })
                .CreateMapper();
            var user = mapper.Map<UserDTO, User>(userDto);

            Database.Users.Create(user);
            Database.Save();
        }

        public void UpdateUser(UserDTO userDto)
        {
            var mapper = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<UserDTO, User>();
                cfg.CreateMap<DivisionDTO, Division>();
            })
                .CreateMapper();
            var user = mapper.Map<UserDTO, User>(userDto);

            Database.Users.Update(user);
            Database.Save();
        }



        public void DeleteUser(int id)
        {
            User? user = Database.Users.Get(id);
            if (user != null)
            {
                Database.Users.Delete(user);
                Database.Save();
            }
        }

        public void Dispose()
        {
            Database.Dispose();
        }
    }
}
