using MS_Models.Common;
using MS_Models.Model;
using MS_Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MS_Services.AdmissionService
{
    public interface IAdmissionService
    {
        Task<Response<AdmissionViewModel>> AdmissionAsync(AdmissionViewModel model);
        Task<Response<AdmissionViewModel>> ViewAdmissionAsync();        
    }
}
