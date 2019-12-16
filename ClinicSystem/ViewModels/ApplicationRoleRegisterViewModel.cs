﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ClinicSystem.ViewModels
{
    public class ApplicationRoleRegisterViewModel
    {
        [Required]
        public string Name { get; set; }

        public bool IsSelected { get; set; }
    }
}
