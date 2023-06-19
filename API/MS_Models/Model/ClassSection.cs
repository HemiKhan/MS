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
        public ICollection<Campus>? CampusId { get; set; }
        public ICollection<Session>? SessionId { get; set; }
        public ICollection<Section>? SectionId { get; set; }
        public ICollection<Class>? ClassId { get; set; }
        public ICollection<Students>? StudentId { get; set; }
        public bool IsFeeStructure { get; set; }
        public int? Fee { get; set; }
    }
}
