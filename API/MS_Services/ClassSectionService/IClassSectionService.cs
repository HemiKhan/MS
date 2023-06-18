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
    public interface IClassSectionService
    {
        Task<Response<ClassSectionViewModel>> GetClassSectionAsync();
        Task<Response<ClassSectionViewModel>> GetByClassSectionIdAsync(int ClassSecId);
        Task<Response<AddClassSectionViewModel>> AddClassSectionAsync(AddClassSectionViewModel model);
        Task<Response<ClassSectionViewModel>> UpdateClassSectionAsync(ClassSection model);
        Task<Response<ClassSectionViewModel>> DeleteClassSectionAsync(int ClassSecId);
    }
}
