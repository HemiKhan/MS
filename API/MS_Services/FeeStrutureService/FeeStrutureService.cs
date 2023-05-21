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

namespace MS_Services.FeeStrutureService
{
    public class FeeStrutureService : IFeeStrutureService
    {
        private readonly AppDbContext db;
        public FeeStrutureService(AppDbContext db)
        {
            this.db = db;
        }


        public async Task<Response<FeeStructureViewModel>> AddFeeStructureAsync(FeeStructureViewModel model)
        {
            try
            {
                if (model.CampusId == 0)
                    return new Response<FeeStructureViewModel>
                    {
                        Message = "Campus Id Not Valid",
                        Status = false
                    };

                if (model.ClassId == 0)
                    return new Response<FeeStructureViewModel>
                    {
                        Message = "Class Id Not Valid",
                        Status = false
                    };

                if (model.SectionId == 0)
                    return new Response<FeeStructureViewModel>
                    {
                        Message = "Section Id Not Valid",
                        Status = false
                    };

                if (model.Fee == 0)
                    return new Response<FeeStructureViewModel>
                    {
                        Message = "Fee Not Valid",
                        Status = false
                    };

                FeeStructure fee = new FeeStructure();
                fee.CampusId = model.CampusId;
                fee.ClassId = model.ClassId;
                fee.SectionId = model.SectionId;
                fee.SessionId = model.SessionId;
                fee.Fee = model.Fee;
                fee.IsAtive = model.IsActive;

                await db.FeeStructures.AddAsync(fee);
                await db.SaveChangesAsync();

                return new Response<FeeStructureViewModel>
                {
                    Message = "Fee Structure Added Successfully",
                    Status = true
                };
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<Response<FeeStructureViewModel>> DeleteFeeStructureAsync(int FeeId)
        {
            try
            {
                if (FeeId == 0)
                    return new Response<FeeStructureViewModel>
                    {
                        Message = "Fee Id Not Found",
                        Status = false
                    };

                var data = await db.FeeStructures.Where(x => x.Id == FeeId).FirstOrDefaultAsync();
                if (data is null)
                    return new Response<FeeStructureViewModel>
                    {
                        Message = "Data Not Found",
                        Status = false
                    };

                db.FeeStructures.Remove(data);
                await db.SaveChangesAsync();

                return new Response<FeeStructureViewModel>
                {
                    Message = "Fee Structure Removed Successfully",
                    Status = true
                };
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<Response<FeeStructure>> GetByFeeStructureIdAsync(int FeeId)
        {
            try
            {
                if (FeeId == 0)
                    return new Response<FeeStructure>
                    {
                        Message = "Fee Id Not Valid",
                        Status = false
                    };

                var data = await db.FeeStructures.Where(x => x.Id == FeeId).FirstOrDefaultAsync();
                if (data is null)
                    return new Response<FeeStructure>
                    {
                        Message = "Data Not Found",
                        Status = false
                    };

                return new Response<FeeStructure>
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

        public async Task<Response<FeeStructure>> GetFeeStructureAsync()
        {
            try
            {
                var data = await db.FeeStructures.ToListAsync();
                if (data is null)
                    return new Response<FeeStructure>
                    {
                        Message = "Data Not Found",
                        Status = false
                    };

                return new Response<FeeStructure>
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

        public async Task<Response<FeeStructureViewModel>> UpdateFeeStructureAsync(FeeStructure model)
        {
            try
            {
                if (model.Id == 0)
                    return new Response<FeeStructureViewModel>
                    {
                        Message = "Session Id Not Found",
                        Status = false
                    };

                var data = await db.FeeStructures.Where(x => x.Id == model.Id).FirstOrDefaultAsync();
                if (data is null)
                    return new Response<FeeStructureViewModel>
                    {
                        Message = "Data Not Found",
                        Status = false
                    };

                data.ClassId = model.ClassId;
                data.SectionId = model.SectionId;
                data.SessionId = model.SessionId;
                data.Fee = model.Fee;
                data.IsAtive = model.IsAtive;

                db.FeeStructures.Update(data);
                await db.SaveChangesAsync();

                return new Response<FeeStructureViewModel>
                {
                    Message = "Fee Structure (" + data.Fee + ") Updated Successfully",
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
