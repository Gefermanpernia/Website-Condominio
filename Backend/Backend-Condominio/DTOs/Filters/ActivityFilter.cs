﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend_Condominio.DTOs.Filters
{
    public class ActivityFilter: PaginationDTO
    {
        public string Name { get; set; }  
    }
}
