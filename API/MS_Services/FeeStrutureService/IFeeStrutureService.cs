using MS_Models.Common;
using MS_Models.Model;
using MS_Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MS_Services.FeeStrutureService
{
    public interface IFeeStrutureService
    {
        Task<Response<FeeStructure>> GetFeeStructureAsync();
        Task<Response<FeeStructure>> GetByFeeStructureIdAsync(int FeeId);
        Task<Response<FeeStructureViewModel>> AddFeeStructureAsync(FeeStructureViewModel model);
        Task<Response<FeeStructureViewModel>> UpdateFeeStructureAsync(FeeStructure model);
        Task<Response<FeeStructureViewModel>> DeleteFeeStructureAsync(int FeeId);
    }
}
