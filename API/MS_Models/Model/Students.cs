using MS_Models.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MS_Models.Model
{
    public class Students : CommonProps
    {
        public string? StudentCode { get; set; }
        public string? Name { get; set; }
        public string? DOB { get; set; }
        public string? Gender { get; set; }
        public long? PhoneNo { get; set; }
        public string? Email { get; set; }
        public string? Address { get; set; }
        public string? StudentImage { get; set; }
        public string? Religion { get; set; }
        public string? PrieviousSchool { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public ClassSection? ClassSection { get; set; }
        public StudentDetail? StudentDetail { get; set; }
        public Enrollments? Enrollments { get; set; }
    }
}
