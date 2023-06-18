using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MS_Models.ViewModel
{
    public class CampusViewModel
    {  
        public int? CampusId { get; set; }
        public string? CampusName { get; set; }
        public int? OrganizationId { get; set; }
        public bool IsActive { get; set; }
    }
}
