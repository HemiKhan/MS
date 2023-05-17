using MS_Models.Common;
using MS_Models.FilterModel;
using MS_Services.UriFilterService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MS_Services.Pagination
{
    public class FilterHelper
    {
        public static FilterResponse<IQueryable<T>> CreatePagedReponse<T>(IQueryable<T> pagedData, FilterViewModel validFilter, int totalRecords, IUriService uriService, string route)
        {
            var respose = new FilterResponse<IQueryable<T>>(pagedData, validFilter.PageNo, validFilter.PageSize);
            var totalPages = ((double)totalRecords / (double)validFilter.PageSize);
            int roundedTotalPages = Convert.ToInt32(Math.Ceiling(totalPages));
            respose.NextPage =
                validFilter.PageNo >= 1 && validFilter.PageNo < roundedTotalPages
                ? uriService.GetPageUri(new FilterViewModel(validFilter.PageNo + 1, validFilter.PageSize), route)
                : null;
            respose.PreviousPage =
                validFilter.PageNo - 1 >= 1 && validFilter.PageNo <= roundedTotalPages
                ? uriService.GetPageUri(new FilterViewModel(validFilter.PageNo - 1, validFilter.PageSize), route)
                : null;
            respose.FirstPage = uriService.GetPageUri(new FilterViewModel(1, validFilter.PageSize), route);
            respose.LastPage = uriService.GetPageUri(new FilterViewModel(roundedTotalPages, validFilter.PageSize), route);
            respose.TotalPages = roundedTotalPages;
            respose.TotalRecords = totalRecords;
            return respose;
        }
    }
}
