using AutoMapper;
using BuisnessLogicLayer.DTO;
using DataAccessLayer.Entities;
using RubiusUI.Areas.Model;

namespace RubiusUI.Services
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<FilteredDataViewModel, FiltredDataDTO>();
            CreateMap<UserPageDTO, UserPageViewModel>();
            CreateMap<PagesDTO, PageViewModel>();
            CreateMap<UserDTO, UserViewModel>();
            CreateMap<UserViewModel, UserDTO>();

            CreateMap<User, UserDTO>();
            CreateMap<Division, DivisionDTO>();
            CreateMap<DivisionDTO, Division>();

            CreateMap<UserDTO, User>();
            CreateMap<DivisionDTO, Division>();
            CreateMap<DivisionDTO, DivisionViewModel>();
            CreateMap<DivisionViewModel, DivisionDTO>();
        }
    }
}
