using Backend_Condominio.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend_Condominio.DTOs.Filters
{
    public class StatusServiceFilter : PaginationDTO
    {
        public string Title { get; set; }

        public List<Service> Services { get; set; }

    }
}
