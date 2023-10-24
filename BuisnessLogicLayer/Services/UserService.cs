using AutoMapper;
using BuisnessLogicLayer.DTO;
using BuisnessLogicLayer.Infrastructure;
using BuisnessLogicLayer.Interfaces;
using DataAccessLayer.Entities;
using DataAccessLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuisnessLogicLayer.Services
{
    public class UserService : IUserService
    {
        private IUnitOfWork Database { get; set; }

        public UserService(IUnitOfWork uow)
        {
            Database = uow;
        }
        public void CreateUser(UserDTO userDto)
        {
            // валидация
            if (userDto == null)
                throw new ValidationException("Пользователь не найден", "");

            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<UserDTO, User>()).CreateMapper();
            var user = mapper.Map<UserDTO, User>(userDto);

            Database.Users.Create(user);
            Database.Save();
        }

        public IEnumerable<UserDTO> GetUsers()
        {
            var userDB = Database.Users.GetAll().ToList();
            // применяем автомаппер для проекции одной коллекции на другую

            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<User, UserDTO>()).CreateMapper();
            var user = mapper.Map<IEnumerable<User>, List<UserDTO>>(userDB);
            mapper = new MapperConfiguration(cfg => cfg.CreateMap<Division, DivisionDTO>()).CreateMapper();

            for (var i = 0; i < userDB.Count; i++)
            {
                foreach (var item in userDB[i].Division)
                {
                    user[i].Divisions.Add(mapper.Map<Division, DivisionDTO>(item.Division));
                }
            }
            return user;
        }

        public UserDTO GetUser(int? id)
        {
            if (id == null)
                throw new ValidationException("Не установлено id Пользователя", "");
            var user = Database.Users.Get(id.Value);
            if (user == null)
                throw new ValidationException("Пользователь не найден", "");

            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<User, UserDTO>()).CreateMapper();
            var userResult = mapper.Map<User, UserDTO>(user);

            mapper = new MapperConfiguration(cfg => cfg.CreateMap<Division, DivisionDTO>()).CreateMapper();

            foreach (var item in user.Division)
            {
                userResult.Divisions.Add(mapper.Map<Division, DivisionDTO>(item.Division));
            }


            return userResult;
        }

        public void UpdateUser(UserDTO userDto)
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<UserDTO, User>()).CreateMapper();
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
