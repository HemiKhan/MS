using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MS_Models.ViewModel
{
    public class AdmissionViewModel
    {
        public string? StudentCode { get; set; }
        public string? StudentName { get; set; }
        public string? Email { get; set; }
        public string? Address { get; set; }
        public string? Religion { get; set; }
        public string? StudentImage { get; set; }
        public IFormFile? StudentImageUpload { get; set; }
        public string? PreviousSchool { get; set; }
        public string? FatherName { get; set; }
        public string? FatherProfession { get; set; }
        public string? FatherCnic { get; set; }
        public string? MotherName { get; set; }
        public string? MotherProfession { get; set; }
        public string? MotherCnic { get; set; }
        public string? GuardianName { get; set; }
        public string? GuardianProfession { get; set; }
        public string? GuardianCnic { get; set; }
        public string? GuardianRelation { get; set; }
        public DateTime? DOB { get; set; }
        public DateTime? AdmissionDate { get; set; }
        public string? Gender { get; set; }
        public long? PhoneNumber { get; set; }
        public long? ParrentContact { get; set; }
        public string? HomeAddress { get; set; }
        public string? ParrentEmail { get; set; }
        public int? CampusId { get; set; }
        public int? SessionId { get; set; }
        public int? SectionId { get; set; }
        public int? ClassId { get; set; }
        public int? FeeStructureId { get; set; }
        public bool IsFeeStructure { get; set; }
        public int? Fee { get; set; }
    }
}
