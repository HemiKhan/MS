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
    public interface IEnrollmentService
    {
        Task<Response<Enrollments>> GetEnrollmentsAsync();
        Task<Response<Enrollments>> GetByEnrollmentsIdAsync(int EnrollId);
        Task<Response<Enrollments>> AddEnrollmentsAsync(Enrollments model);
        Task<Response<Enrollments>> UpdateEnrollmentsAsync(Enrollments model);
        Task<Response<Enrollments>> DeleteEnrollmentsAsync(int EnrollId);
    }
}
