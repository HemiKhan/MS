using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MS_Models.Model
{
    public class Student
    {
        [Key]
        public int Id { get; set; }
        public string? Name { get; set; }       
        public string? DOB { get; set; }       
        public string? Gender { get; set; }
        public string? PhoneNo { get; set; }
        public string? Email { get; set; }
        public string? Active { get; set; }
    } 
}
