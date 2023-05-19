using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MS_Models.ViewModel
{
    public class OrganizationViewModel
    {
        public string? OrgName { get; set; }
        public string? Address { get; set; }
        public string? Email { get; set; }
        public long? Phone { get; set; }
        public bool IsActive { get; set; }
    }
}
