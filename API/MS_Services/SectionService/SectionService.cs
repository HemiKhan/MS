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
                return new Response<SectionViewModel>
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

        public async Task<Response<SectionViewModel>> DeleteSectionAsync(int SecId)
        {
            try
            {
                return new Response<SectionViewModel>
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

        public async Task<Response<Section>> GetBySectionIdAsync(int SecId)
        {
            try
            {
                return new Response<Section>
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

        public async Task<Response<Section>> GetSectionAsync()
        {
            try
            {
                return new Response<Section>
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

        public async Task<Response<SectionViewModel>> UpdateSectionAsync(Section model)
        {
            try
            {
                return new Response<SectionViewModel>
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
