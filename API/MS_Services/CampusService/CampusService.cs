using MS_Data.AppContext;
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
    public class CampusService : ICampusService
    {
        private readonly AppDbContext db;
        public CampusService(AppDbContext db)
        {
            this.db = db;
        }


        public async Task<Response<CampusViewModel>> AddCampusAsync(CampusViewModel model)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(model.CampusName))
                    return new Response<CampusViewModel>
                    {
                        Message = "Campus Name Not Found",
                        Status = false
                    };

                Campus campus = new Campus();
                campus.CampusName = model.CampusName;
                campus.OrganizationId = model.OrganizationId;
                campus.IsAtive = model.IsActive;

                var data = await db.Campus.AddAsync(campus);
                await db.SaveChangesAsync();

                return new Response<CampusViewModel>
                {
                    Message = "Campus Added Successfully",
                    Status = true
                };
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<Response<CampusViewModel>> DeleteCampusAsync(int CampusId)
        {
            try
            {
                return new Response<CampusViewModel>
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

        public async Task<Response<Campus>> GetByCampusIdAsync(int CampusId)
        {
            try
            {
                return new Response<Campus>
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

        public async Task<Response<Campus>> GetCampusAsync()
        {
            try
            {
                return new Response<Campus>
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

        public async Task<Response<CampusViewModel>> UpdateCampusAsync(Campus model)
        {
            try
            {
                return new Response<CampusViewModel>
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
