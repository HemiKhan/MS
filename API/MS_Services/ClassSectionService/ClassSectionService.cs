using MS_Data.AppContext;
using MS_Models.Common;
using MS_Models.Model;
using MS_Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MS_Services.ClassSectionService
{
    public class ClassSectionService : IClassSectionService
    {
        private readonly AppDbContext db;
        public ClassSectionService(AppDbContext db)
        {
            this.db = db;
        }


        public async Task<Response<ClassSectionViewModel>> AddClassSectionAsync(ClassSectionViewModel model)
        {
            try
            {
                return new Response<ClassSectionViewModel>
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

        public async Task<Response<ClassSectionViewModel>> DeleteClassSectionAsync(int ClassSecId)
        {
            try
            {
                return new Response<ClassSectionViewModel>
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

        public async Task<Response<ClassSectionViewModel>> GetByClassSectionIdAsync(int ClassSecId)
        {
            try
            {
                return new Response<ClassSectionViewModel>
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

        public async Task<Response<ClassSectionViewModel>> GetClassSectionAsync()
        {
            try
            {
                return new Response<ClassSectionViewModel>
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

        public async Task<Response<ClassSectionViewModel>> UpdateClassSectionAsync(ClassSection model)
        {
            try
            {
                return new Response<ClassSectionViewModel>
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
