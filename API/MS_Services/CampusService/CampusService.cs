using Microsoft.EntityFrameworkCore;
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

        public async Task<Response<CampusViewModel>> AddOrEditCampusAsync(CampusViewModel model)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(model.CampusName))
                    return new Response<CampusViewModel>
                    {
                        Message = "Campus Name Not Found",
                        Status = false
                    };

                var msg = "";

                if (model.CampusId > 0 || model.CampusId != null)
                {
                    var data = await db.Campus.Where(x => x.Id == model.CampusId).FirstOrDefaultAsync();
                    if (data is null)
                        return new Response<CampusViewModel>
                        {
                            Message = "Data Not Found",
                            Status = false
                        };

                    data.CampusName = model.CampusName;
                    data.IsAtive = model.IsActive;
                    db.Campus.Update(data);
                    msg = "Campus (" + data.CampusName + ") Updated Successfully";
                }
                else
                {
                    Campus campus = new Campus();
                    campus.CampusName = model.CampusName;
                    campus.OrganizationId = model.OrganizationId;
                    campus.IsAtive = model.IsActive;
                    await db.Campus.AddAsync(campus);
                    msg = "Campus (" + campus.CampusName + ") Added Successfully";
                }

                await db.SaveChangesAsync();

                return new Response<CampusViewModel>
                {
                    Message = msg,
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
                if (CampusId == 0)
                    return new Response<CampusViewModel>
                    {
                        Message = "Campus Id Not Found",
                        Status = false
                    };

                var data = await db.Campus.Where(x => x.Id == CampusId).FirstOrDefaultAsync();
                if (data is null)
                    return new Response<CampusViewModel>
                    {
                        Message = "Data Not Found",
                        Status = false
                    };

                db.Campus.Remove(data);
                await db.SaveChangesAsync();

                return new Response<CampusViewModel>
                {
                    Message = "Campus Removed Successfully",
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
                if (CampusId == 0)
                    return new Response<Campus>
                    {
                        Message = "Campus Id Not Found",
                        Status = false
                    };

                var data = await db.Campus.Where(x => x.Id == CampusId).FirstOrDefaultAsync();
                if (data is null)
                    return new Response<Campus>
                    {
                        Message = "Data Not Found",
                        Status = false
                    };

                return new Response<Campus>
                {
                    Message = "Data Found Successfully",
                    Status = true,
                    Data = data
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
                var data = await db.Campus.ToListAsync();
                if (data is null)
                    return new Response<Campus>
                    {
                        Message = "Data Not Found",
                        Status = false
                    };

                return new Response<Campus>
                {
                    Message = "Data Found Successfully",
                    Status = true,
                    List = data
                };
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
