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
        public int? SessionId { get; set; }
        public int? SectionId { get; set; }
        public int? ClassId { get; set; }
        public int? Fee { get; set; }

        public ICollection<Session>? Session { get; set; }
        public ICollection<Section>? Section { get; set; }
        public ICollection<Class>? Class { get; set; }
    }
}
