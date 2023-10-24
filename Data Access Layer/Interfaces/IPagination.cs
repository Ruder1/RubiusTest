namespace DataAccessLayer.Interfaces
{
    public interface IPagination<T> where T : class
    {
        public IQueryable<T> GetPage(int page, int pageSize);
    }
}
