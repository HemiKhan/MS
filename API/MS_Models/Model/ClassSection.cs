using MS_Models.Common;
using MS_Models.Relations.OneToMany;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MS_Models.Model
{
    public class ClassSection : CommonProps
    {
        public int? CampusId { get; set; }
        public int? SessionId { get; set; }
        public int? SectionId { get; set; }
        public int? ClassId { get; set; }
        public int? StudentId { get; set; }
        public int? FeeStructureId { get; set; }
        public bool IsFeeStructure { get; set; }
        public int? DiscountedFee { get; set; }

        public Campus? Campus { get; set; }
        public Session? Session { get; set; }
        public Section? Section { get; set; }
        public Class? Class { get; set; }
        public Students? Students { get; set; }
        public FeeStructure? FeeStructure { get; set; }
    }
}
