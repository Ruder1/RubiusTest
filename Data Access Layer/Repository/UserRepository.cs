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
        private UserContext db;

        public UserRepository(UserContext context)
        {
            this.db = context;
        }

        public IEnumerable<User> GetAll()
        {
            return db.Users;
        }

        public User Get(int id)
        {
            return db.Users.Find(id);
        }

        public void Create(User book)
        {
            db.Users.Add(book);
        }

        public void Update(User book)
        {
            db.Entry(book).State = EntityState.Modified;
        }

        public IEnumerable<User> Find(Func<User, Boolean> predicate)
        {
            return db.Users.Where(predicate).ToList();
        }

        public void Delete(int id)
        {
            User book = db.Users.Find(id);
            if (book != null)
                db.Users.Remove(book);
        }
    }
}
