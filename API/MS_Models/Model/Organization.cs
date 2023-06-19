using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MS_Models.Model
{
    public class Organization
    {
        [Key]
        public int OrgId { get; set; }
        public string? OrgName { get; set; }
        public string? Address { get; set; }
        public string? Email { get; set; }
        public long? Phone { get; set; }
        public bool IsActive { get; set; }
        public Campus? Campus { get; set; }
    }
}
