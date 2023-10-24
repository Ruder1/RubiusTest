using BuisnessLogicLayer.DTO;
using BuisnessLogicLayer.Interfaces;
using DataAccessLayer.EF;
using Microsoft.AspNetCore.Mvc;
using RubiusUI.Areas.Model;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using AutoMapper;
using DataAccessLayer.Entities;

namespace RubiusUI.Areas.Controllers
{
    [Route("api/v1/[controller]/[action]")]
    [ApiController]
    public class UserController : Controller
    {
        private readonly IUserService _userService;

        private readonly IFilterService _filterService;

        public UserController(IUserService userService, IFilterService filterService)
        {
            _userService = userService;
            _filterService = filterService;
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
                Id = user.Id,
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

        [HttpPost]
        public IActionResult FiltredUsers(FilteredDataViewModel filtredData)
        {
            if (filtredData == null)
            {
                return BadRequest("Data is null");
            }

            var mapper = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<FilteredDataViewModel, FiltredDataDTO>();
            })
                .CreateMapper();
            var dataDTO = mapper.Map<FilteredDataViewModel, FiltredDataDTO>(filtredData);

            var result = _filterService.FilterData(dataDTO);

            return Ok(result);
        }
    }
}
