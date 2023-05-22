using MS_Models.Common;
using MS_Models.Model;
using MS_Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MS_Services.CampusService
{
    public interface ICampusService
    {
        Task<Response<Campus>> GetCampusAsync();
        Task<Response<Campus>> GetByCampusIdAsync(int CampusId);
        Task<Response<CampusViewModel>> AddCampusAsync(CampusViewModel model);
        Task<Response<CampusViewModel>> UpdateCampusAsync(Campus model);
        Task<Response<CampusViewModel>> DeleteCampusAsync(int CampusId);
    }
}
