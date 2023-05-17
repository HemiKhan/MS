using MS_Data.AppContext;
using Microsoft.EntityFrameworkCore;
using MS_Models.Model;
using MS_Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MS_Models.Common;

namespace MS_Services.Employees
{
    public class EmployeeService : IEmployeeService
    {
        private readonly AppDbContext context;
        public EmployeeService(AppDbContext context)
        {
            this.context = context;
        }

        public async Task<Response<EmployeeViewModel>> GetEmployeeAsync()
        {
            try
            {
                var data = await context.Employees.ToListAsync();
                if (data != null)
                {
                    return new Response<EmployeeViewModel>
                    {
                        Message = "Record Found Successfully",
                        Status = true,
                        List = EmployeeExtensions.EmployeeMapperListing(data),
                    };
                }
                return new Response<EmployeeViewModel>
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

        public async Task<Response<EmployeeViewModel>> AddEmployeeAsync(Employee model)
        {
            try
            {
                if (model is null)
                    throw new NullReferenceException("Model is Null Here....");
                model.JoiningDate = DateTime.Now;
                var data = await context.Employees.AddAsync(model);
                await context.SaveChangesAsync();
                return new Response<EmployeeViewModel>
                {
                    Message = "Record Submitted Successfully",
                    Status = true
                };
            }
            catch
            {
                throw;
            }
        }

        public async Task<Response<EmployeeViewModel>> EditEmployeeAsync(Employee model)
        {
            try
            {
                if (model is null)
                    throw new NullReferenceException("Model is Null Here....");
                var data = await context.Employees.FindAsync(model.EmpID);
                if (data != null)
                {
                    data.Name = model.Name;
                    data.Designation = model.Designation;
                    data.Salary = model.Salary;
                    data.IsActive = model.IsActive;
                    data.JoiningDate = DateTime.Now;
                    context.Employees.Update(data);
                    await context.SaveChangesAsync();
                    return new Response<EmployeeViewModel>
                    {
                        Message = "Record Updated Successfully",
                        Status = true
                    };
                }
                return new Response<EmployeeViewModel>
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

        public async Task<Response<EmployeeViewModel>> DeleteByIdEmployeeAsync(int EmpId)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(EmpId.ToString()))
                    throw new NullReferenceException("Model is Empty");
                var data = await context.Employees.FindAsync(EmpId);
                if (data != null)
                {
                    context.Employees.Remove(data);
                    await context.SaveChangesAsync();
                    return new Response<EmployeeViewModel>
                    {
                        Message = "Record Is Deleted Successfully",
                        Status = true
                    };
                }
                return new Response<EmployeeViewModel>
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

        public async Task<Response<EmployeeViewModel>> EmployeeGetByIdAsync(int EmpId)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(EmpId.ToString()))
                    throw new NullReferenceException("Model is Empty");
                var data = await context.Employees.FindAsync(EmpId);
                if (data != null)
                {                    
                    return new Response<EmployeeViewModel>
                    {
                        Message = "Data found successfully",
                        Status = true,
                        Data = EmployeeExtensions.EmployeeMapper(data)
                    };
                }
                return new Response<EmployeeViewModel>
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
    }
}
