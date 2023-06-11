using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MS_Models.ViewModel
{
    public class ClassSectionViewModel
    {
        public string? OrgName { get; set; }
        public string? CampusName { get; set; }
        public string? SessionName { get; set; }
        public string? SectionName { get; set; }
        public string? ClassName { get; set; }
        public string? StudentName { get; set; }
        public string? RollNo { get; set; }
        public DateTime? AddmissionDate { get; set; }
        public bool IsFeeStructure { get; set; }
        public int? Fee { get; set; }
    }

    public class AddClassSectionViewModel
    {
        public int? CampusId { get; set; }
        public int? SessionId { get; set; }
        public int? SectionId { get; set; }
        public int? ClassId { get; set; }
        public int? StudentId { get; set; }
        public int? FeeStructureId { get; set; }
        public bool IsFeeStructure { get; set; }
        public int? DiscountedFee { get; set; }
    }
}
