using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MS_Models.Common
{
    public class CommonProps
    {
        [Key]
        public int Id { get; set; }
        public bool IsAtive { get; set; }
    }
}
