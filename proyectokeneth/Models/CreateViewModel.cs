﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace proyectokeneth.Models
{
    public class CreateViewModel
    {
        [Required]
        public String RoleName { get; set; }

    }
}
