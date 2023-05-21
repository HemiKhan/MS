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

namespace MS_Services.SectionService
{
    public class SectionService : ISectionService
    {
        private readonly AppDbContext db;
        public SectionService(AppDbContext db)
        {
            this.db = db;
        }


        public async Task<Response<SectionViewModel>> AddSectionAsync(SectionViewModel model)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(model.SectionName))
                    return new Response<SectionViewModel>
                    {
                        Message = "Section Name Not Found",
                        Status = false
                    };

                Section sec = new Section();
                sec.SectionName = model.SectionName;
                sec.IsAtive = model.IsActive;

                await db.Sections.AddAsync(sec);
                await db.SaveChangesAsync();

                return new Response<SectionViewModel>
                {
                    Message = "Section Added Successfully",
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

        public async Task<Response<SectionViewModel>> UpdateSectionAsync(Section model)
        {
            try
            {
                if (model.Id == 0)
                    return new Response<SectionViewModel>
                    {
                        Message = "Section Id Not Found",
                        Status = false
                    };

                var data = await db.Sections.Where(x => x.Id == model.Id).FirstOrDefaultAsync();
                if (data is null)
                    return new Response<SectionViewModel>
                    {
                        Message = "Data Not Found",
                        Status = false
                    };

                data.SectionName = model.SectionName;
                data.IsAtive = model.IsAtive;

                db.Sections.Update(data);
                await db.SaveChangesAsync();

                return new Response<SectionViewModel>
                {
                    Message = "Section (" + data.SectionName + ") Updated Successfully",
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
