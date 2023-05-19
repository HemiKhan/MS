using MS_Models.Common;
using MS_Models.Model;
using MS_Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MS_Services.OrganizationService
{
    public interface IOrganizationService
    {
        Task<Response<OrganizationViewModel>> GetOrgainzationAsync();
        Task<Response<OrganizationViewModel>> GetByOrgainzationIdAsync(int OrgId);
        Task<Response<OrganizationViewModel>> AddOrgainzationAsync(OrganizationViewModel model);
        Task<Response<OrganizationViewModel>> UpdateOrgainzationAsync(Organization model);
        Task<Response<OrganizationViewModel>> DeleteOrgainzationAsync(int OrgId);
            
    }
}
