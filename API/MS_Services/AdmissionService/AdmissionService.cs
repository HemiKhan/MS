
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

namespace MS_Services.AdmissionService
{
    public class AdmissionService : IAdmissionService
    {
        private readonly AppDbContext db;
        public AdmissionService(AppDbContext db)
        {
            this.db = db;
        }

        public async Task<Response<AdmissionViewModel>> AdmissionAsync(AdmissionViewModel model)
        {
            try
            {
                Students std = new Students();
                std.StudentCode = model.StudentCode;
                std.Name = model.StudentName;
                std.DOB = model.DOB;
                std.Gender = model.Gender;
                std.PhoneNo = model.PhoneNumber;
                std.Email = model.Email;
                std.Address = model.Address;
                std.Religion = model.Religion;
                if (model.StudentImage is not null || model.StudentImage != "")
                {
                    std.StudentImage = model.StudentImage;
                }
                std.PreviousSchool = model.PreviousSchool;
                std.CreatedDate = DateTime.Now;
                std.UpdatedDate = DateTime.Now;
                std.IsAtive = true;

                await db.Students.AddAsync(std);
                await db.SaveChangesAsync();

                var stdId = std.Id;

                StudentDetail stdDetail = new StudentDetail();
                stdDetail.StudentId = stdId;
                stdDetail.FatherName = model.FatherName;
                stdDetail.FatherCnic = model.FatherCnic;
                stdDetail.FatherProfession = model.FatherProfession;
                stdDetail.MotherName = model.MotherName;
                stdDetail.MotherCnic = model.MotherCnic;
                stdDetail.MotherProfession = model.MotherProfession;
                stdDetail.GuardianName = model.GuardianName;
                stdDetail.GuardianCnic = model.GuardianCnic;
                stdDetail.GuardianProfession = model.GuardianProfession;
                stdDetail.HomeAddress = model.HomeAddress;
                stdDetail.ParentContactNumber = model.ParrentContact;
                stdDetail.ParrentEmail = model.ParrentEmail;
                stdDetail.GuardianRelation = model.GuardianRelation;
                stdDetail.IsAtive = true;

                await db.StudentDetails.AddAsync(stdDetail);

                ClassSection classSection = new ClassSection();
                classSection.ClassId = model.ClassId;
                classSection.SessionId = model.SessionId;
                classSection.SectionId = model.SectionId;
                classSection.CampusId = model.CampusId;
                classSection.StudentId = stdId;
                classSection.AdmissionDate = model.AdmissionDate;
                classSection.IsFeeStructure = model.IsFeeStructure;
                if (model.IsFeeStructure == false)
                {
                    classSection.DiscountedFee = model.Fee;
                }
                else
                {
                    classSection.FeeStructureId = model.FeeStructureId;
                }
                await db.ClassSections.AddAsync(classSection);

                await db.SaveChangesAsync();

                return new Response<AdmissionViewModel>
                {
                    Message = "Admission Successfully Student Code is " + std.StudentCode + "",
                    Status = true,
                };
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<Response<AdmissionViewModel>> ViewAdmissionAsync()
        {
            try
            {
                List<AdmissionViewModel> res = new List<AdmissionViewModel>();
                var data = await db.ClassSections
                                   .Include(c => c.Campus)
                                   .Include(sess => sess.Session)
                                   .Include(sec => sec.Section)
                                   .Include(cls => cls.Class)
                                   .Include(std => std.Students)
                                   .Include(std_detail => std_detail.Students)
                                   .ToListAsync();

                foreach (var item in data)
                {
                    AdmissionViewModel admission = new AdmissionViewModel();
                    admission.StudentName = item.Students!.Name;
                    res.Add(admission);
                }

                return new Response<AdmissionViewModel>
                {
                    Message = "Data Found Successfully",
                    Status = true,
                };
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
