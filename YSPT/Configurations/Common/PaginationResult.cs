namespace YSPT.Configurations.Common;

public class PaginationResult<T>
{
    public long TotalItems { get; set; }
    public long TotalPages { get; set; }

    public int CurrentPageNo { get; set; }
    public int CurrentPageSize { get; }

    public bool HasNextPage => CurrentPageNo < TotalPages;
    public bool HasPreviousPage => CurrentPageNo > 1;

    public IList<T> Data { get; set; } = [];
}
