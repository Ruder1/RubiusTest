using BuisnessLogicLayer.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuisnessLogicLayer.Interfaces
{
    public interface IUserService :IDisposable
    {
        public void CreateUser(UserDTO userDto);

        public UserDTO GetUser(int? id);

        public IEnumerable<UserDTO> GetUsers();

        public void UpdateUser(UserDTO userDto);

        public void DeleteUser(int id);

    }
}
