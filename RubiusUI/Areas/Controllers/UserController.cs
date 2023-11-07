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

        private readonly IPaginationService _pageService;

        private readonly IMapper _mapper;

        public UserController(IUserService userService, IFilterService filterService, IPaginationService pagination, IMapper mapper)
        {
            _userService = userService;
            _filterService = filterService;
            _pageService = pagination;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult Users(int page, int pageSize)
        {
            var userList = _userService.GetUsers().ToList();

            var pagedList = _pageService.GetPage(userList, page, pageSize);

            var result = _mapper.Map<UserPageDTO, UserPageViewModel>(pagedList);

            return Ok(result);
        }

        [HttpGet("{id}")]
        public IActionResult User(int id, int page, int pageSize)
        {
            var user = _userService.GetUser(id);

            var temp = new List<UserDTO>()
            {
                user
            };
            var pagedList = _pageService.GetPage(temp, page, pageSize);

            var result = _mapper.Map<UserPageDTO, UserPageViewModel>(pagedList);

            return Ok(result);
        }

        [HttpPost]
        public IActionResult CreateUser(UserViewModel user)
        {
            var userDto = _mapper.Map<UserViewModel, UserDTO>(user);

            _userService.CreateUser(userDto);

            return Ok("Пользователь Успешно добавлен");

        }

        [HttpPut]
        public IActionResult ChangeUser(UserViewModel user)
        {
            var userDto = _mapper.Map<UserViewModel, UserDTO>(user);
            _userService.UpdateUser(userDto);
            return Ok("Пользователь отредактирован");
        }

        [HttpDelete("{id:int}")]
        public IActionResult DeleteUser(int id)
        {
            _userService.DeleteUser(id);

            return Ok("Пользователь удален");
        }

        [HttpPost]
        public IActionResult FiltredUsers(FilteredDataViewModel filtredData, int page = 1, int pageSize = 5)
        {
            if (filtredData == null)
            {
                return BadRequest("Data is null");
            }

            var dataDTO = _mapper.Map<FilteredDataViewModel, FiltredDataDTO>(filtredData);

            var filteredList = _filterService.FilterData(dataDTO);

            var pagedList = _pageService.GetPage(filteredList, page, pageSize);

            var result = _mapper.Map<UserPageDTO, UserPageViewModel>(pagedList);

            return Ok(result);
        }

        [HttpGet]
        public IActionResult GetDivisions()
        {
            var divisions = _userService.GetDivisions();

            var result = _mapper.Map<IEnumerable<DivisionDTO>, IEnumerable<DivisionViewModel>>(divisions);

            return Ok(result);
        }
    }
}
