using BuisnessLogicLayer.DTO;
using BuisnessLogicLayer.Interfaces;
using Microsoft.AspNetCore.Mvc;
using RubiusUI.Areas.Model;
using AutoMapper;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Drawing.Printing;

namespace RubiusUI.Areas.Controllers
{
    [Route("api/v1/[controller]/[action]")]
    [ApiController]
    public class UserController : Controller
    {
        private readonly IUserService _userService;

        private readonly IFilterService _filterService;

        private readonly IPaginationService _pagination;

        public UserController(IUserService userService, IFilterService filterService, IPaginationService pagination)
        {
            _userService = userService;
            _filterService = filterService;
            _pagination = pagination;
        }

        [HttpGet]
        public IActionResult Users(int page, int pageSize)
        {
            var mapper = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<FilteredDataViewModel, FiltredDataDTO>();
                cfg.CreateMap<UserPageDTO, UserPageViewModel>();
                cfg.CreateMap<PagesDTO, PageViewModel>();
                cfg.CreateMap<UserDTO, UserViewModel>();
            })
                .CreateMapper();

            var userList = _userService.GetUsers().ToList();

            var pagedList = _pagination.GetPage(userList, page, pageSize);

            var result = mapper.Map<UserPageDTO, UserPageViewModel>(pagedList);

            return Ok(result);
        }

        [HttpGet("{id}")]
        public IActionResult User(int id, int page, int pageSize)
        {
            var mapper = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<FilteredDataViewModel, FiltredDataDTO>();
                cfg.CreateMap<UserPageDTO, UserPageViewModel>();
                cfg.CreateMap<PagesDTO, PageViewModel>();
                cfg.CreateMap<UserDTO, UserViewModel>();
            })
                .CreateMapper();

            var user = _userService.GetUser(id);

            var temp = new List<UserDTO>()
            {
                user
            };
            var pagedList = _pagination.GetPage(temp, page, pageSize);

            var result = mapper.Map<UserPageDTO, UserPageViewModel>(pagedList);

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
        public IActionResult FiltredUsers(FilteredDataViewModel filtredData, int page, int pageSize)
        {
            if (filtredData == null)
            {
                return BadRequest("Data is null");
            }

            var mapper = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<FilteredDataViewModel, FiltredDataDTO>();
                cfg.CreateMap<UserPageDTO, UserPageViewModel>();
                cfg.CreateMap<PagesDTO, PageViewModel>();
                cfg.CreateMap<UserDTO, UserViewModel>();
            })
                .CreateMapper();
            var dataDTO = mapper.Map<FilteredDataViewModel, FiltredDataDTO>(filtredData);

            var filteredList = _filterService.FilterData(dataDTO);

            var pagedList = _pagination.GetPage(filteredList, page, pageSize);

            var result = mapper.Map<UserPageDTO, UserPageViewModel>(pagedList);

            return Ok(result);
        }
    }
}
