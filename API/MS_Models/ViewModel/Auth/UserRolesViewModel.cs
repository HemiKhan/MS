﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MS_Models.ViewModel.Auth
{
    public class UserRolesViewModel
    {
        public string? UserEmail { get; set; }
        public List<RoleViewModel>? Roles { get; set; }
    }
}
