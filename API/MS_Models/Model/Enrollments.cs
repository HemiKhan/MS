using MS_Models.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MS_Models.Model
{
    public class Enrollments : CommonProps
    {
        public int? StudentId { get; set; }
        public string? RollNo { get; set; }
        public string? Status { get; set; }
        public string? AddmissionDate { get; set; }
        public Students? Students { get; set; }
    }
}
