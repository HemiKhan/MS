using MS_Data.AppContext;
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
    public class StudentService : IStudentService
    {
        private readonly AppDbContext db;
        public StudentService(AppDbContext db)
        {
            this.db = db;
        }


        public async Task<Response<StudentsViewModel>> AddStudentsAsync(StudentsViewModel model)
        {
            try
            {
                return new Response<StudentsViewModel>
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

        public async Task<Response<StudentsViewModel>> DeleteStudentsAsync(int StdId)
        {
            try
            {
                return new Response<StudentsViewModel>
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

        public async Task<Response<StudentsViewModel>> GetByStudentsIdAsync(int StdId)
        {
            try
            {
                return new Response<StudentsViewModel>
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

        public async Task<Response<StudentsViewModel>> GetStudentsAsync()
        {
            try
            {
                return new Response<StudentsViewModel>
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

        public async Task<Response<StudentsViewModel>> UpdateStudentsAsync(Students model)
        {
            try
            {
                return new Response<StudentsViewModel>
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
