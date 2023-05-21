using Microsoft.EntityFrameworkCore;
using MS_Data.AppContext;
using MS_Models.Common;
using MS_Models.Model;
using MS_Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace MS_Services.OrganizationService
{
    public class OrganizationService : IOrganizationService
    {
        private readonly AppDbContext db;
        public OrganizationService(AppDbContext db)
        {
            this.db = db;
        }


        public async Task<Response<OrganizationViewModel>> AddOrgainzationAsync(OrganizationViewModel model)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(model.OrgName))
                    return new Response<OrganizationViewModel>
                    {
                        Message = "Organization Name Not Found",
                        Status = false
                    };

                Organization org = new Organization();
                org.OrgName = model.OrgName;
                org.Address = model.Address;
                org.Email = model.Email;
                org.Phone = model.Phone;
                org.IsActive = true;

                var data = await db.Organizations.AddAsync(org);
                await db.SaveChangesAsync();

                return new Response<OrganizationViewModel>
                {
                    Message = "Add Data Successfully",
                    Status = true,
                    Data = model
                };
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<Response<OrganizationViewModel>> DeleteOrgainzationAsync(int OrgId)
        {
            try
            {
                if (OrgId > 0)
                    return new Response<OrganizationViewModel>
                    {
                        Message = "Organization Id Not Found",
                        Status = false
                    };

                var data = await db.Organizations.Where(x => x.OrgId == OrgId).FirstOrDefaultAsync();
                if (data is null)
                    return new Response<OrganizationViewModel>
                    {
                        Message = "Data Not Found",
                        Status = false
                    };

                db.Organizations.Remove(data);
                await db.SaveChangesAsync();

                return new Response<OrganizationViewModel>
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

        public async Task<Response<Organization>> GetByOrgainzationIdAsync(int OrgId)
        {
            try
            {
                if (OrgId > 0)
                    return new Response<Organization>
                    {
                        Message = "Organization Id Not Found",
                        Status = false
                    };

                var data = await db.Organizations.Where(x => x.OrgId == OrgId).FirstOrDefaultAsync();
                if (data is null)
                    return new Response<Organization>
                    {
                        Message = "Data Not Found",
                        Status = false
                    };

                return new Response<Organization>
                {
                    Message = "Found Data Successfully",
                    Status = true,
                    Data = data
                };
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<Response<Organization>> GetOrgainzationAsync()
        {
            try
            {
                var data = await db.Organizations.ToListAsync();
                if (data is null)
                    return new Response<Organization>
                    {
                        Message = "Data Not Found",
                        Status = false
                    };

                return new Response<Organization>
                {
                    Message = "Found Data Successfully",
                    Status = true,
                    List = data
                };
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<Response<OrganizationViewModel>> UpdateOrgainzationAsync(Organization model)
        {
            try
            {
                var data = await db.Organizations.Where(x => x.OrgId == model.OrgId).FirstOrDefaultAsync();
                if (data is null)
                    return new Response<OrganizationViewModel>
                    {
                        Message = "Data Not Found",
                        Status = false
                    };

                Organization org = new Organization();
                data.OrgName = org.OrgName;
                data.Address = org.Address;
                data.Email = org.Email;
                data.Phone = org.Phone;  
                data.IsActive = org.IsActive;

                db.Organizations.Update(org);
                await db.SaveChangesAsync();

                return new Response<OrganizationViewModel>
                {
                    Message = "Update Data Successfully",
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
