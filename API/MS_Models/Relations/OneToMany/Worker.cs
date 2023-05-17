using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MS_Models.Relations.OneToMany
{
    public class Worker
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public Company? Company { get; set; }
    }
}
