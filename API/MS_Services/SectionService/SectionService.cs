using Microsoft.EntityFrameworkCore;
using MS_Data.AppContext;
using MS_Models.Common;
using MS_Models.Model;
using MS_Models.ViewModel;

namespace MS_Services.SectionService
{
    public class SectionService : ISectionService
    {
        private readonly AppDbContext db;
        public SectionService(AppDbContext db)
        {
            this.db = db;
        }

        public async Task<Response<SectionViewModel>> AddOrEditSectionAsync(SectionViewModel model)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(model.SectionName))
                    return new Response<SectionViewModel>
                    {
                        Message = "SectionName Name Not Found",
                        Status = false
                    };

                var msg = "";

                if (model.SectionId > 0 || model.SectionId != null)
                {
                    var data = await db.Sections.Where(x => x.Id == model.SectionId).FirstOrDefaultAsync();
                    if (data is null)
                        return new Response<SectionViewModel>
                        {
                            Message = "Data Not Found",
                            Status = false
                        };

                    data.SectionName = model.SectionName;
                    data.IsAtive = model.IsActive;
                    db.Sections.Update(data);
                    msg = "Section (" + data.SectionName + ") Updated Successfully";
                }
                else
                {
                    Section secs = new Section();
                    secs.SectionName = model.SectionName;
                    secs.IsAtive = model.IsActive;
                    await db.Sections.AddAsync(secs);
                    msg = "Section (" + secs.SectionName + ") Added Successfully";
                }

                await db.SaveChangesAsync();

                return new Response<SectionViewModel>
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

        public async Task<Response<SectionViewModel>> DeleteSectionAsync(int SecId)
        {
            try
            {
                if (SecId == 0)
                    return new Response<SectionViewModel>
                    {
                        Message = "Section Id Not Found",
                        Status = false
                    };

                var data = await db.Sections.Where(x => x.Id == SecId).FirstOrDefaultAsync();
                if (data is null)
                    return new Response<SectionViewModel>
                    {
                        Message = "Data Not Found",
                        Status = false
                    };

                db.Sections.Remove(data);
                await db.SaveChangesAsync();

                return new Response<SectionViewModel>
                {
                    Message = "This " + data.SectionName + " Section Removed Successfully",
                    Status = true
                };
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<Response<Section>> GetBySectionIdAsync(int SecId)
        {
            try
            {
                if (SecId == 0)
                    return new Response<Section>
                    {
                        Message = "Section Id Not Valid",
                        Status = false
                    };

                var data = await db.Sections.Where(x => x.Id == SecId).FirstOrDefaultAsync();
                if (data is null)
                    return new Response<Section>
                    {
                        Message = "Data Not Found",
                        Status = false
                    };

                return new Response<Section>
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

        public async Task<Response<Section>> GetSectionAsync()
        {
            try
            {
                var data = await db.Sections.ToListAsync();
                if (data is null)
                    return new Response<Section>
                    {
                        Message = "Data Not Found",
                        Status = false
                    };

                return new Response<Section>
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
