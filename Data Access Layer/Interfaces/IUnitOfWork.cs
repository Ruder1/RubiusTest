using DataAccessLayer.Entities;

namespace DataAccessLayer.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<User> Users { get; }

        IRepository<Division> Divisions { get; }

        IPagination<User> Pagination { get; }

        void Save();
    }
}
