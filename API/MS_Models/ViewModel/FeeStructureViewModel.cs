using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MS_Models.ViewModel
{
    public class FeeStructureViewModel
    {
        public int? CampusId { get; set; }
        public int? SessionId { get; set; }
        public int? SectionId { get; set; }
        public int? ClassId { get; set; }
        public int? Fee { get; set; }
        public bool IsActive { get; set; }
    }

    public class GetFeeStructureViewModel
    {
        public int? FeeId { get; set; }
        public int? Fee { get; set; }
    }
}
