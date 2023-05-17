using MS_Models.Common;
using MS_Models.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MS_Services.Pagination
{
    public interface IPaginationSerivce
    {
        Task<Response<object>> GetListAsync(FilterViewModel filter);
        //Task<Response<Employee>> FilterWithoutModel(FilterViewModel filter);
        //Task<Response<Employee>> FilterWithModel(FilterViewModel filter);
    }
}
