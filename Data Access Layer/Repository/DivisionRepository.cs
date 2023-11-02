using DataAccessLayer.EF;
using DataAccessLayer.Entities;
using DataAccessLayer.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repository
{
    public class DivisionRepository : IRepository<Division>
    {
        private readonly UserContext _context;

        public DivisionRepository(UserContext context)
        {
            _context = context;
        }

        public void Create(Division item)
        {
            throw new NotImplementedException();
        }

        public void Delete(Division item)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Division> Find(Func<Division, bool> predicate)
        {
            throw new NotImplementedException();
        }

        public Division Get(int id)
        {
            return _context.Divisions.FirstOrDefault(u => u.Id == id);
        }

        public IEnumerable<Division> GetAll()
        {
            return _context.Divisions;
        }

        public void Update(Division item)
        {
            throw new NotImplementedException();
        }
    }
}
