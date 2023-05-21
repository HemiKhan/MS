using MS_Data.AppContext;
using MS_Models.Common;
using MS_Models.Model;
using MS_Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MS_Services.EnrollmentService
{
    public class EnrollmentService : IEnrollmentService
    {
        private readonly AppDbContext db;
        public EnrollmentService(AppDbContext db)
        {
            this.db = db;
        }


        public async Task<Response<Enrollments>> AddEnrollmentsAsync(Enrollments model)
        {
            try
            {
                return new Response<Enrollments>
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

        public async Task<Response<Enrollments>> DeleteEnrollmentsAsync(int EnrollId)
        {
            try
            {
                return new Response<Enrollments>
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

        public async Task<Response<Enrollments>> GetByEnrollmentsIdAsync(int EnrollId)
        {
            try
            {
                return new Response<Enrollments>
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

        public async Task<Response<Enrollments>> GetEnrollmentsAsync()
        {
            try
            {
                return new Response<Enrollments>
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

        public async Task<Response<Enrollments>> UpdateEnrollmentsAsync(Enrollments model)
        {
            try
            {
                return new Response<Enrollments>
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
