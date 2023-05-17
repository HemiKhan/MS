using MS_Models.Common;
using MS_Models.Model;
using MS_Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MS_Services.Employees
{
    public interface IEmployeeService
    {
        Task<Response<EmployeeViewModel>> GetEmployeeAsync();
        Task<Response<EmployeeViewModel>> AddEmployeeAsync(Employee model);
        Task<Response<EmployeeViewModel>> EditEmployeeAsync(Employee model);
        Task<Response<EmployeeViewModel>> DeleteByIdEmployeeAsync(int EmpId);
        Task<Response<EmployeeViewModel>> EmployeeGetByIdAsync(int EmpId);
    }
}
