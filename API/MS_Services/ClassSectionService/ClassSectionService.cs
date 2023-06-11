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

namespace MS_Services.ClassSectionService
{
    public class ClassSectionService : IClassSectionService
    {
        private readonly AppDbContext db;
        public ClassSectionService(AppDbContext db)
        {
            this.db = db;
        }


        public async Task<Response<AddClassSectionViewModel>> AddClassSectionAsync(AddClassSectionViewModel model)
        {
            try
            {
                if (model.SessionId == 0)
                    return new Response<AddClassSectionViewModel>
                    {
                        Message = "Session Not Found",
                        Status = false
                    };

                if (model.SectionId == 0)
                    return new Response<AddClassSectionViewModel>
                    {
                        Message = "Section Not Found",
                        Status = false
                    };

                if (model.ClassId == 0)
                    return new Response<AddClassSectionViewModel>
                    {
                        Message = "Class Not Found",
                        Status = false
                    };

                if (model.StudentId == 0)
                    return new Response<AddClassSectionViewModel>
                    {
                        Message = "Student Not Found",
                        Status = false
                    };

                ClassSection cs = new ClassSection();
                cs.SessionId = model.SessionId;
                cs.SectionId = model.SectionId;
                cs.ClassId = model.ClassId;
                cs.StudentId = model.StudentId;
                cs.AdmissionDate = DateTime.Now;
                if (model.FeeStructureId > 0 && model.IsFeeStructure == true)
                {
                    cs.FeeStructureId = model.FeeStructureId;
                    cs.IsFeeStructure = model.IsFeeStructure;
                }
                else
                {
                    cs.DiscountedFee = model.DiscountedFee;
                }

                await db.ClassSections.AddAsync(cs);
                await db.SaveChangesAsync();

                return new Response<AddClassSectionViewModel>
                {
                    Message = "Class Section Added Successfully",
                    Status = true
                };
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<Response<ClassSectionViewModel>> DeleteClassSectionAsync(int ClassSecId)
        {
            try
            {
                if (ClassSecId == 0)
                    return new Response<ClassSectionViewModel>
                    {
                        Message = "Class Section Not Found",
                        Status = false
                    };

                var data = await db.ClassSections.Where(x => x.Id == ClassSecId).FirstOrDefaultAsync();
                if (data is null)
                    return new Response<ClassSectionViewModel>
                    {
                        Message = "Data Not Found",
                        Status = false
                    };

                db.ClassSections.Remove(data);
                await db.SaveChangesAsync();

                return new Response<ClassSectionViewModel>
                {
                    Message = "Class Section Removed Successfully",
                    Status = true
                };
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<Response<ClassSectionViewModel>> GetByClassSectionIdAsync(int ClassSecId)
        {
            try
            {
                if (ClassSecId == 0)
                    return new Response<ClassSectionViewModel>
                    {
                        Message = "Class Section Not Found",
                        Status = false
                    };

                var classSec = await db.ClassSections.Where(x => x.Id == ClassSecId).FirstOrDefaultAsync();
                if (classSec is null)
                    return new Response<ClassSectionViewModel>
                    {
                        Message = "Data Not Found",
                        Status = false
                    };

                ClassSectionViewModel data = new ClassSectionViewModel();

                var Session = await db.Sessions.Where(x => x.Id == classSec.SessionId).Select(s => s.SessionName).FirstOrDefaultAsync();
                if (Session is not null)
                    data.SessionName = Session;

                var Section = await db.Sections.Where(x => x.Id == classSec.SectionId).Select(s => s.SectionName).FirstOrDefaultAsync();
                if (Section is not null)
                    data.SectionName = Section;

                var Class = await db.Class.Where(x => x.Id == classSec.ClassId).Select(s => s.ClassName).FirstOrDefaultAsync();
                if (Class is not null)
                    data.ClassName = Class;

                var Student = await db.Students.Where(x => x.Id == classSec.StudentId).Select(s => new { s.Name,s.StudentCode }).FirstOrDefaultAsync();
                if (Student is not null)
                {
                    data.StudentName = Student.Name;
                    data.StudentName = Student.StudentCode;
                }

                if (classSec.IsFeeStructure == true || classSec.FeeStructureId > 0)
                {
                    var Fee = await db.FeeStructures.Where(x => x.Id == classSec.FeeStructureId).Select(s => s.Fee).FirstOrDefaultAsync();
                    if (Fee is not null)
                        data.Fee = Fee;
                }
                else
                {
                    data.Fee = classSec.DiscountedFee; 
                }

                data.AddmissionDate = classSec.AdmissionDate;

                return new Response<ClassSectionViewModel>
                {
                    Message = "Found Data Successfully",
                    Status = true,
                    Data = data
                };
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<Response<ClassSectionViewModel>> GetClassSectionAsync()
        {
            try
            {
                var data = await db.ClassSections.ToListAsync();
                if (data is null)
                    return new Response<ClassSectionViewModel>
                    {
                        Message = "Data Not Found",
                        Status = false
                    };

                return new Response<ClassSectionViewModel>
                {
                    Message = "Found Data Successfully",
                    Status = true,
                    //List = data
                };
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<Response<ClassSectionViewModel>> UpdateClassSectionAsync(ClassSection model)
        {
            try
            {
                return new Response<ClassSectionViewModel>
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
