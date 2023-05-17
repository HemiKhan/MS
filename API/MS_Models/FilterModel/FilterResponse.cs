using MS_Models.Common;

namespace MS_Models.FilterModel
{
    public class FilterResponse<T> : Response<T>
    {
        public int? PageNo { get; set; }
        public int? PageSize { get; set; }
        public Uri? FirstPage { get; set; }
        public Uri? LastPage { get; set; }
        public int? TotalPages { get; set; }
        public int? TotalRecords { get; set; }
        public Uri? NextPage { get; set; }
        public Uri? PreviousPage { get; set; }
        public FilterResponse(T data, int pageNumber, int pageSize)
        {
            PageNo = pageNumber;
            PageSize = pageSize;
            Data = data;
            Message = null;
            Status = true;
            Errors = null;
        }
    }
}
