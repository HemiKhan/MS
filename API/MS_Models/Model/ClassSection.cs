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
        public bool IsFeeStructure { get; set; }
        public int? Fee { get; set; }

        public ICollection<Campus>? Campus { get; set; }
        public ICollection<Session>? Session { get; set; }
        public ICollection<Section>? Section { get; set; }
        public ICollection<Class>? Class { get; set; }
        public ICollection<Students>? Students { get; set; }
    }
}
