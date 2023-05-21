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


        public async Task<Response<FeeStructure>> AddFeeStructureAsync(FeeStructure model)
        {
            try
            {
                return new Response<FeeStructure>
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

        public async Task<Response<FeeStructure>> DeleteFeeStructureAsync(int FeeId)
        {
            try
            {
                return new Response<FeeStructure>
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

        public async Task<Response<FeeStructure>> GetByFeeStructureIdAsync(int FeeId)
        {
            try
            {
                return new Response<FeeStructure>
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

        public async Task<Response<FeeStructure>> GetFeeStructureAsync()
        {
            try
            {
                return new Response<FeeStructure>
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

        public async Task<Response<FeeStructure>> UpdateFeeStructureAsync(FeeStructure model)
        {
            try
            {
                return new Response<FeeStructure>
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
