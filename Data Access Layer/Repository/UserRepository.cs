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
            return _context.Users.Include(division => division.Divisions)
                .OrderBy(s=>s.Surname)
                .ThenBy(n=>n.Name)
                .ThenBy(l=>l.LastName)
                .ToList();
        }

        public User Get(int id)
        {
            return _context.Users.Include(d => d.Divisions)
                .FirstOrDefault(u => u.Id == id);
        }

        public void Create(User user)
        {
            var division = new List<Division>();


            foreach (var item in user.Divisions)
            {
                division.Add(_context.Divisions.FirstOrDefault(d => d.Id == item.Id));
                
            }
            user.Divisions.Clear();

            _context.Divisions.AttachRange(division);
            user.Divisions.AddRange(division);

            _context.Users.Add(user);
        }

        public void Update(User user)
        {
            var temp = _context.Enrollments.Where(d => d.UserId == user.Id).ToList();
            foreach (var item in temp)
            {
                _context.Remove(item);
            }
            _context.SaveChanges();
            _context.Update(user);
        }

        public IEnumerable<User> Find(Func<User, Boolean> predicate)
        {
            IQueryable<User> user = _context.Users.Include(d => d.Divisions);
            return user.Where(predicate);
        }
                

        public void Delete(User user)
        {
            if (user != null)
                _context.Users.Remove(user);
        }
    }
}
