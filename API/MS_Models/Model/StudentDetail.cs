using MS_Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MS_Models.Model
{
    public class StudentDetail : CommonProps
    {
        public int? StudentId { get; set; }
        public string? FatherName { get; set; }
        public string? MotherName { get; set; }
        public string? GuardianName { get; set; }
        public string? FaherCnic { get; set; }
        public string? MotherCnic { get; set; }
        public string? GuardianCnic { get; set; }
        public string? HomeAddress { get; set; }
        public long? ParentContactNumber { get; set; }
        public string? FatherEmail { get; set; }
        public string? FatherProfession { get; set; }
        public string? MotherProfession { get; set; }
        public string? GuardianProfession { get; set; }
        public string? GuardianRelation { get; set; }
        public Students? Students { get; set; }
    }
}
