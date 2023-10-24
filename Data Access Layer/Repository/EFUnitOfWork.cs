using DataAccessLayer.EF;
using DataAccessLayer.Entities;
using DataAccessLayer.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Repository
{
    public class EFUnitOfWork : IUnitOfWork
    {
        private UserContext db;
        private UserRepository userRepository;
        private DivisionRepository divisionRepository;

        public EFUnitOfWork(DbContextOptions<UserContext> connectionString)
        {
            db = new UserContext(connectionString);
        }

        public IRepository<User> Users
        {
            get
            {
                if (userRepository == null)
                    userRepository = new UserRepository(db);
                return userRepository;
            }
        }

        public IRepository<Division> Divisions
        {
            get
            {
                if (divisionRepository == null)
                    divisionRepository = new DivisionRepository(db);
                return divisionRepository;
            }
        }

        public void Save()
        {
            db.SaveChanges();
        }

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
                this.disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
