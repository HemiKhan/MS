using MS_Data.AppContext;
using MS_Models.Common;
using MS_Models.Model;
using MS_Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MS_Services.ClassService
{
    public class ClassService : IClassService
    {
        private readonly AppDbContext db;
        public ClassService(AppDbContext db)
        {
            this.db = db;
        }


        public async Task<Response<ClassViewModel>> AddClassAsync(ClassViewModel model)
        {
            try
            {
                return new Response<ClassViewModel>
                {
                    Message = "Found Data Successfully",
                    Status = true
                };
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<Response<ClassViewModel>> DeleteClassAsync(int ClassId)
        {
            try
            {
                return new Response<ClassViewModel>
                {
                    Message = "Found Data Successfully",
                    Status = true
                };
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<Response<Class>> GetByClassIdAsync(int ClassId)
        {
            try
            {
                return new Response<Class>
                {
                    Message = "Found Data Successfully",
                    Status = true
                };
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<Response<Class>> GetClassAsync()
        {
            try
            {
                return new Response<Class>
                {
                    Message = "Found Data Successfully",
                    Status = true
                };
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<Response<ClassViewModel>> UpdateClassAsync(Class model)
        {
            try
            {
                return new Response<ClassViewModel>
                {
                    Message = "Found Data Successfully",
                    Status = true
                };
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
