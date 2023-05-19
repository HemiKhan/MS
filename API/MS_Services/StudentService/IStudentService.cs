using MS_Models.Common;
using MS_Models.Model;
using MS_Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MS_Services.StudentService
{
    public interface IStudentService
    {
        Task<Response<Students>> GetStudentsAsync();
        Task<Response<Students>> GetByStudentsIdAsync(int StdId);
        Task<Response<StudentsViewModel>> AddStudentsAsync(StudentsViewModel model);
        Task<Response<StudentsViewModel>> UpdateStudentsAsync(Students model);
        Task<Response<StudentsViewModel>> DeleteStudentsAsync(int StdId);
    }
}
