using MS_Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MS_Models.Model
{
    public class FeeStructure : CommonProps
    {
        public int? CampusId { get; set; }
        public int? SessionId { get; set; }
        public int? ClassId { get; set; }
        public int? SectionId { get; set; }
        public int? Fee { get; set; }

        public ICollection<ClassSection>? ClassSection { get; set; }
        public Campus? Campus { get; set; }
        public Session? Session { get; set; }
        public Section? Section { get; set; }
        public Class? Class { get; set; }
    }
}
