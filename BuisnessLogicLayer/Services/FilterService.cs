using AutoMapper;
using BuisnessLogicLayer.DTO;
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
    public class FilterService : IFilterService
    {

        private IUnitOfWork Database { get; set; }

        private readonly IMapper _mapper;

        public FilterService(IUnitOfWork uow, IMapper mapper)
        {
            Database = uow;
            _mapper = mapper;
        }

        public IEnumerable<UserDTO> FilterData(FiltredDataDTO? data)
        {
            IEnumerable<User> users = Database.Users.GetAll();

            if (data.Division != null)
            {
                var division = Database.Divisions.Get(data.Division.Id);

                users = users.Where(d => d.Divisions.Contains(division));
            }

            if (data.MinSalary != null && data.MaxSalary != null)
            {
                users = users.Where(p => data.MinSalary <= p.Salary && p.Salary <= data.MaxSalary);
            }

            if (!string.IsNullOrEmpty(data.SearchString))
            {
                users = users.Where(p => p.Name.Contains(data.SearchString)
                || p.Surname.Contains(data.SearchString)
                || p.LastName.Contains(data.SearchString)
                || p.Email.Contains(data.SearchString));
            }            

            var userResult = _mapper.Map<List<User>, List<UserDTO>>(users.ToList());

            return userResult;
        }


        public void Dispose()
        {
            Database.Dispose();
        }
    }
}
