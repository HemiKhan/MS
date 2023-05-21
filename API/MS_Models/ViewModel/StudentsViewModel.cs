using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MS_Models.ViewModel
{
    public class StudentsViewModel
    {
        public int? StudentId { get; set; }
        public string? Name { get; set; }
        public string? DOB { get; set; }
        public string? Gender { get; set; }
        public long? PhoneNo { get; set; }
        public string? Email { get; set; }
        public string? Address { get; set; }
        public string? StudentImage { get; set; }
        public string? Religion { get; set; }
        public string? PrieviousSchool { get; set; }
        public string? FatherName { get; set; }
        public string? MotherName { get; set; }
        public string? Guardian { get; set; }
        public string? FatherOccupation { get; set; }
        public string? GuardianOccupation { get; set; }
        public string? FaherCnic { get; set; }
        public string? MotherCnic { get; set; }
        public string? GuardianCnic { get; set; }
        public string? HomeAddress { get; set; }
        public long? ParentContactNumber { get; set; }
        public string? FatherEmail { get; set; }
        public string? FatherProfession { get; set; }
        public string? MotherProfession { get; set; }
        public string? GuardianProfession { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public bool IsAtive { get; set; }
    }
    
}
