using DataAccessLayer.EF;
using DataAccessLayer.Entities;
using DataAccessLayer.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Repository
{
    public class Pagination : IPagination<User>
    {
        private readonly UserContext _context;

        public Pagination(UserContext context)
        {
            _context = context;
        }

        public IQueryable<User> GetPage(int page, int pageSize)
        {
            IQueryable<User> source = _context.Users.Include(x => x.Divisions);
            return source;
        }
    }
}
