namespace RubiusUI.Areas.Model
{
    public class PageViewModel
    {
        public int PageNumber { get; init; }
        public int TotalPages { get; init; }
        public bool HasPreviousPage => PageNumber > 1;
        public bool HasNextPage => PageNumber < TotalPages;
    }
}
