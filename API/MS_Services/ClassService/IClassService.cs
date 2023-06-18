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
    public interface IClassService
    {
        Task<Response<Class>> GetClassAsync();
        Task<Response<Class>> GetByClassIdAsync(int ClassId);
        Task<Response<ClassViewModel>> AddOrEditClassAsync(ClassViewModel model);
        Task<Response<ClassViewModel>> DeleteClassAsync(int ClassId);
    }
}
