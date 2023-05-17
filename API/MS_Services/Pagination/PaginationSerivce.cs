using MS_Data.AppContext;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using MS_Models.FilterModel;
using MS_Models.Model;
using MS_Models.ViewModel;
using MS_Services.UriFilterService;
using MS_Models.Common;

namespace MS_Services.Pagination
{
    public class PaginationSerivce : IPaginationSerivce
    {
        private readonly AppDbContext context;
        private readonly IUriService uriService;
        private readonly IHttpContextAccessor httpContextAccessor;
        public PaginationSerivce(AppDbContext context, IUriService uriService, IHttpContextAccessor httpContextAccessor)
        {
            this.context = context;
            this.uriService = uriService;
            this.httpContextAccessor = httpContextAccessor;
        }

        public async Task<Response<object>> GetListAsync(FilterViewModel filter)
        {
            try
            {
                var data = context.Employees.AsQueryable();                
                if (data != null)
                {
                    if (!string.IsNullOrWhiteSpace(filter.Query))
                    {
                        data = data.Where(x => x.Name.ToLower().Contains(filter.Query) ||
                                              x.Designation.ToLower().Contains(filter.Query) ||
                                              x.Salary.ToString().Contains(filter.Query) ||
                                              x.IsActive.ToString().Contains(filter.Query) ||
                                              x.JoiningDate.ToString().Contains(filter.Query));
                    }

                    if (filter.SortDesc == true)
                    {
                        switch (filter.SortBy)
                        {
                            case "Name":
                                data = data.OrderByDescending(s => s.Name);
                                break;
                            case "Designation":
                                data = data.OrderByDescending(s => s.Designation);
                                break;
                            case "Salary":
                                data = data.OrderByDescending(s => s.Salary);
                                break;
                            case "JoiningDate":
                                data = data.OrderByDescending(s => s.JoiningDate);
                                break;
                            case "IsActive":
                                data = data.OrderByDescending(s => s.IsActive);
                                break;
                            default:
                                data = data.OrderByDescending(s => s.Name);
                                break;
                        }
                    }
                    else
                    {
                        switch (filter.SortBy)
                        {
                            case "Name":
                                data = data.OrderBy(s => s.Name);
                                break;
                            case "Designation":
                                data = data.OrderBy(s => s.Designation);
                                break;
                            case "Salary":
                                data = data.OrderBy(s => s.Salary);
                                break;
                            case "JoiningDate":
                                data = data.OrderBy(s => s.JoiningDate);
                                break;
                            case "IsActive":
                                data = data.OrderBy(s => s.IsActive);
                                break;
                            default:
                                data = data.OrderBy(s => s.Name);
                                break;
                        }
                    }

                    bool outparams;
                    if (!string.IsNullOrWhiteSpace(filter.EntityStatus))
                    {
                        if (bool.TryParse(filter.EntityStatus, out outparams))
                        {
                            data = data.Where(x => x.IsActive == outparams);
                        }
                    }

                    var totalRecords = await data.CountAsync();
                    var totalPage = ((double)totalRecords / (double)filter.PageSize);
                    int totalPagesCount = Convert.ToInt32(Math.Ceiling(totalPage));
                    var output = data.Skip(filter.PageSize * (filter.PageNo - 1)).Take(filter.PageSize).ToList().EmployeeMapperListing();

                    return new Response<object>
                    {
                        Message = "Record Found Successfully",
                        Status = true,
                        Data = new
                        {
                            Data = output,
                            TotalRecords = totalRecords,
                            TotalPage = totalPagesCount,
                        }
                    };
                }
                return new Response<object>
                {
                    Message = "Record Not Found",
                    Status = false
                };
            }
            catch
            {
                throw;
            }
        }

        //public async Task<Response<Employee>> FilterWithoutModel(FilterViewModel filter)
        //{
        //    try
        //    {
        //        var data = context.Employees.AsQueryable();
        //        if (data != null)
        //        {
        //            if (!string.IsNullOrWhiteSpace(filter.Query))
        //            {
        //                data = data.Where(x => x.Name.ToLower().Contains(filter.Query) ||
        //                                      x.Designation.ToLower().Contains(filter.Query) ||
        //                                      x.Salary.ToString().Contains(filter.Query) ||
        //                                      x.IsActive.ToString().Contains(filter.Query) ||
        //                                      x.JoiningDate.ToString().Contains(filter.Query));
        //            }

        //            var route = httpContextAccessor.HttpContext.Request.Path.Value;
        //            var validFilter = new FilterViewModel(filter.PageNo, filter.PageSize);
        //            var totalRecords = await context.Employees.CountAsync();
        //            var Pages = ((double)totalRecords / (double)validFilter.PageSize);
        //            int roundedTotalPages = Convert.ToInt32(Math.Ceiling(Pages));

        //            int totalPages = (filter.PageNo - 1) * filter.PageSize;
        //            data = data.Skip(totalPages).Take(filter.PageSize);

        //            var respose = new FilterResponse<IQueryable<Employee>>(data, validFilter.PageNo, validFilter.PageSize);         
        //            respose.NextPage = validFilter.PageNo >= 1 && validFilter.PageNo < roundedTotalPages
        //                               ? uriService.GetPageUri(new FilterViewModel(validFilter.PageNo + 1, validFilter.PageSize), route) : null;
        //            respose.PreviousPage = validFilter.PageNo - 1 >= 1 && validFilter.PageNo <= roundedTotalPages
        //                                   ? uriService.GetPageUri(new FilterViewModel(validFilter.PageNo - 1, validFilter.PageSize), route) : null;
        //            respose.FirstPage = uriService.GetPageUri(new FilterViewModel(1, validFilter.PageSize), route);
        //            respose.LastPage = uriService.GetPageUri(new FilterViewModel(roundedTotalPages, validFilter.PageSize), route);
        //            respose.TotalPages = roundedTotalPages;
        //            respose.TotalRecords = totalRecords;
        //            return new Response<Employee>
        //            {
        //                Message = "Record Found Successfully",
        //                Status = true,
        //                Data = respose
        //            };
        //        }
        //        return new Response<Employee>
        //        {
        //            Message = "Record Not Found",
        //            Status = false
        //        };
        //    }
        //    catch
        //    {
        //        throw;
        //    }
        //}

        //public async Task<Response<Employee>> FilterWithModel(FilterViewModel filter)
        //{
        //    try
        //    {
        //        var data = context.Employees.AsQueryable();
        //        if (data != null)
        //        {
        //            if (!string.IsNullOrWhiteSpace(filter.Query))
        //            {
        //                data = data.Where(x => x.Name.ToLower().Contains(filter.Query) ||
        //                                      x.Designation.ToLower().Contains(filter.Query) ||
        //                                      x.Salary.ToString().Contains(filter.Query) ||
        //                                      x.IsActive.ToString().Contains(filter.Query) ||
        //                                      x.JoiningDate.ToString().Contains(filter.Query));
        //            }

        //            var route = httpContextAccessor.HttpContext.Request.Path.Value;
        //            var validFilter = new FilterViewModel(filter.PageNo, filter.PageSize);
        //            var totalRecords = await context.Employees.CountAsync();
        //            int totalPages = (filter.PageNo - 1) * filter.PageSize;
        //            data = data.Skip(totalPages).Take(filter.PageSize);
        //            var pagedReponse = FilterHelper.CreatePagedReponse<Employee>(data, validFilter, totalRecords, uriService, route);
        //            return new Response<Employee>
        //            {
        //                Message = "Record Found Successfully",
        //                Status = true,
        //                FilterData = pagedReponse
        //            };
        //        }
        //        return new Response<Employee>
        //        {
        //            Message = "Record Not Found",
        //            Status = false
        //        };
        //    }
        //    catch
        //    {
        //        throw;
        //    }
        //}
    }
}
