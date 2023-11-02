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

        private readonly IMapper _mapper;

        public UserService(IUnitOfWork uow, IMapper mapper)
        {
            Database = uow;
            _mapper = mapper;
        }

        public IEnumerable<UserDTO> GetUsers()
        {
            var userDB = Database.Users.GetAll().ToList();
            // применяем автомаппер для проекции одной коллекции на другую
            var user = _mapper.Map<List<User>, List<UserDTO>>(userDB);
            return user;
        }

        public UserDTO GetUser(int? id)
        {
            if (id == null)
                throw new ValidationException("Не установлено id Пользователя", "");

            var user = Database.Users.Get(id.Value);

            if (user == null)
                throw new ValidationException("Пользователь не найден", "");

            var userResult = _mapper.Map<User, UserDTO>(user);
            return userResult;
        }

        public void CreateUser(UserDTO userDto)
        {
            // валидация
            if (userDto == null)
                throw new ValidationException("Пользователь не найден", "");
            
            var user = _mapper.Map<UserDTO, User>(userDto);

            Database.Users.Create(user);
            Database.Save();
        }

        public void UpdateUser(UserDTO userDto)
        {
            var user = _mapper.Map<UserDTO, User>(userDto);

            Database.Users.Update(user);
            Database.Save();
        }

        public IEnumerable<DivisionDTO> GetDivision()
        {
            var temp = Database.Divisions.GetAll();

            var result = _mapper.Map<IEnumerable<Division>, IEnumerable<DivisionDTO> >(temp);

            return result;
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
