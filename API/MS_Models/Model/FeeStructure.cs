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
        public ICollection<Session>? SessionId { get; set; }
        public ICollection<Section>? SectionId { get; set; }
        public ICollection<Class>? ClassId { get; set; }
        public int? Fee { get; set; }
    }
}
