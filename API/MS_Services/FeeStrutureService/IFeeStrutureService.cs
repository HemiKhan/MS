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
        Task<Response<Organization>> GetOrgainzationAsync();
        Task<Response<Organization>> GetByOrgainzationIdAsync(int OrgId);
        Task<Response<Organization>> AddOrgainzationAsync(OrganizationViewModel model);
        Task<Response<Organization>> UpdateOrgainzationAsync(Organization model);
        Task<Response<Organization>> DeleteOrgainzationAsync(int OrgId);
    }
}
