﻿using MS_Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MS_Models.Model
{
    public class Class : CommonProps
    {
        public string? ClassName { get; set; }
        public ICollection<ClassSection>? ClassSection { get; set; }
        public ICollection<FeeStructure>? FeeStructure { get; set; }
    }
}
