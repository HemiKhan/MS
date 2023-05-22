using MS_Models.Common;
using MS_Models.Model;
using MS_Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MS_Services.SectionService
{
    public interface ISectionService
    {
        Task<Response<Section>> GetSectionAsync();
        Task<Response<Section>> GetBySectionIdAsync(int SecId);
        Task<Response<SectionViewModel>> AddSectionAsync(SectionViewModel model);
        Task<Response<SectionViewModel>> UpdateSectionAsync(Section model);
        Task<Response<SectionViewModel>> DeleteSectionAsync(int SecId);
    }
}
