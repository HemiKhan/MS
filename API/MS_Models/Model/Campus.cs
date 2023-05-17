using MS_Models.Common;
using MS_Models.Relations.OneToMany;
using MS_Models.Relations.OneToOne;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MS_Models.Model
{
    public class Campus : CommonProps
    {
        public string? CampusName { get; set; }
        public int? OrganizationId { get; set; }
        public ClassSection? ClassSection { get; set; }
        public Organization? Organization { get; set; }
    }
}
