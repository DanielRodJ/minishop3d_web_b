namespace Application.Common.Queries
{
    public abstract class BasePagedQuery
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public string? SearchTerm { get; set; }
        public string? Filters { get; set; }
        public string? SortBy { get; set; }
        public bool SortDescending { get; set; }

        public int? Skip => (PageNumber > 0 && PageSize > 0)
            ? (PageNumber - 1) * PageSize
            : null;

        public int? Take => (PageNumber > 0 && PageSize > 0)
            ? PageSize
            : null;

        protected BasePagedQuery() { }

        protected BasePagedQuery(
            int? pageNumber,
            int? pageSize,
            string? searchTerm,
            string? filters,
            string? sortBy,
            bool? sortDescending)
        {
            PageNumber = pageNumber is > 0 ? pageNumber.Value : 1;
            PageSize = pageSize is > 0 ? pageSize.Value : 10;
            SearchTerm = searchTerm;
            Filters = filters;
            SortBy = sortBy;
            SortDescending = sortDescending ?? false;
        }
    }
}