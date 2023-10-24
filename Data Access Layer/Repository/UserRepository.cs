using DataAccessLayer.EF;
using DataAccessLayer.Entities;
using DataAccessLayer.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repository
{
    public class UserRepository : IRepository<User>
    {
        private readonly UserContext _context;

        public UserRepository(UserContext context)
        {
            _context = context;
        }

        public IEnumerable<User> GetAll()
        {
            //var users = _context.Users.Include(division => division.Divisions).ToList();
            var temp = _context.Users.Include(d => d.Division).ThenInclude(p => p.Division).ToList();
            return temp;
        }

        public User Get(int id)
        {
            return _context.Users.Include(d => d.Division).ThenInclude(p => p.Division).First(u=>u.Id==id);
        }

        public void Create(User user)
        {
            _context.Users.Add(user);
        }

        public void Update(User user)
        {
            //_context.Update(user);
            _context.Entry(user).State = EntityState.Modified;
        }

        public IEnumerable<User> Find(Func<User, Boolean> predicate)
        {
            return _context.Users.Where(predicate).ToList();
        }

        public void Delete(User user)
        {
            if (user != null)
                _context.Users.Remove(user);
        }
    }
}
