namespace BuisnessLogicLayer.DTO
{
    public class PagesDTO
    {
        public int PageNumber { get; }
        public int TotalPages { get; }
        public bool HasPreviousPage => PageNumber > 1;
        public bool HasNextPage => PageNumber < TotalPages;

        public PagesDTO(int count, int pageNumber, int pageSize)
        {
            TotalPages = (int)Math.Ceiling(count / (double)pageSize);
            if(pageNumber > TotalPages) 
            {
                PageNumber = 1;
            }
            else
            {
                PageNumber = pageNumber;
            }
        }
    }
}
