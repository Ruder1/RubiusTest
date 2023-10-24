using BuisnessLogicLayer.DTO;
using BuisnessLogicLayer.Interfaces;
using DataAccessLayer.EF;
using Microsoft.AspNetCore.Mvc;
using RubiusUI.Areas.Model;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace RubiusUI.Areas.Users
{
    [Route("api/v1/[controller]/[action]")]
    [ApiController]
    public class UserController : Controller
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public IActionResult Users()
        {
            var result = _userService.GetUsers().ToList();
            return Ok(result);
        }

        [HttpGet]
        public IActionResult User(int id)
        {
            var result = _userService.GetUser(id);
            return Ok(result);
        }

        [HttpPost]
        public IActionResult CreateUser(UserViewModel user)
        {
            var userDto = new UserDTO
            {
                Surname = user.Surname,
                Name = user.Name,
                LastName = user.LastName,
                Email = user.Email,
                Divisions = user.Divisions,
                Salary = user.Salary
            };

            _userService.CreateUser(userDto);

            return Ok("Пользователь Успешно добавлен");

        }

        [HttpPut]
        public IActionResult ChangeUser(UserViewModel user)
        {
            var userDto = new UserDTO
            {
                Surname = user.Surname,
                Name = user.Name,
                LastName = user.LastName,
                Email = user.Email,
                Divisions = user.Divisions,
                Salary = user.Salary
            };
            _userService.UpdateUser(userDto);
            return Ok("Пользователь отредактирован");
        }

        [HttpDelete]
        public IActionResult DeleteUser(int id)
        {
            _userService.DeleteUser(id);

            return Ok("Пользователь удален");
        }
    }
}
