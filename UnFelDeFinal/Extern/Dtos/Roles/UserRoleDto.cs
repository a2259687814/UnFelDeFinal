﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternProj.WebApi.Extern.Roles
{
    public class UserRoleDto
    {
        public string id { get; set; }
        public string UserName { get; set; }
        public bool IsSelected { get; set; }
    }
}
