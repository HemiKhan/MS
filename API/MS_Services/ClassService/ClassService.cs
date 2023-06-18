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

namespace MS_Services.ClassService
{
    public class ClassService : IClassService
    {
        private readonly AppDbContext db;
        public ClassService(AppDbContext db)
        {
            this.db = db;
        }


        public async Task<Response<ClassViewModel>> AddClassAsync(ClassViewModel model)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(model.ClassName))
                    return new Response<ClassViewModel>
                    {
                        Message = "Class Name Not Found",
                        Status = false
                    };

                Class classes = new Class();
                classes.ClassName = model.ClassName;

                await db.Class.AddAsync(classes);
                await db.SaveChangesAsync();

                return new Response<ClassViewModel>
                {
                    Message = "Class Added Successfully",
                    Status = true
                };
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<Response<ClassViewModel>> DeleteClassAsync(int ClassId)
        {
            try
            {
                if (ClassId == 0)
                    return new Response<ClassViewModel>
                    {
                        Message = "Class Id Not Found",
                        Status = false
                    };

                var data = await db.Class.Where(x => x.Id == ClassId).FirstOrDefaultAsync();
                if (data is null)
                    return new Response<ClassViewModel>
                    {
                        Message = "Data Not Found",
                        Status = false
                    };

                db.Class.Remove(data);
                await db.SaveChangesAsync();

                return new Response<ClassViewModel>
                {
                    Message = "Class Removed Successfully",
                    Status = true
                };
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<Response<Class>> GetByClassIdAsync(int ClassId)
        {
            try
            {
                if (ClassId == 0)
                    return new Response<Class>
                    {
                        Message = "Class Id Not Found",
                        Status = false
                    };

                var data = await db.Class.Where(x => x.Id == ClassId).FirstOrDefaultAsync();
                if (data is null)
                    return new Response<Class>
                    {
                        Message = "Data Not Found",
                        Status = false
                    };

                return new Response<Class>
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

        public async Task<Response<Class>> GetClassAsync()
        {
            try
            {
                var data = await db.Class.ToListAsync();
                if (data is null)
                    return new Response<Class>
                    {
                        Message = "Data Not Found",
                        Status = false
                    };

                return new Response<Class>
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

        public async Task<Response<ClassViewModel>> UpdateClassAsync(Class model)
        {
            try
            {
                if (model.Id == 0)
                    return new Response<ClassViewModel>
                    {
                        Message = "Class Id Not Found",
                        Status = false
                    };

                var data = await db.Class.Where(x => x.Id == model.Id).FirstOrDefaultAsync();
                if (data is null)
                    return new Response<ClassViewModel>
                    {
                        Message = "Data Not Found",
                        Status = false
                    };

                data.ClassName = model.ClassName;
                data.IsAtive = model.IsAtive;

                db.Class.Update(data);
                await db.SaveChangesAsync();

                return new Response<ClassViewModel>
                {
                    Message = "Class Updated Successfully",
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
