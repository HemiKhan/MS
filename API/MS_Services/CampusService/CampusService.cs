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
    }
}
