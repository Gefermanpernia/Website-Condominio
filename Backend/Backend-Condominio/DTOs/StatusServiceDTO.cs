using Backend_Condominio.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend_Condominio.DTOs
{
    public class StatusServiceDTO
    {
        public string Title { get; set; }
        public string Text { get; set; }
        public List<Service> Services { get; set; }
    }
}
