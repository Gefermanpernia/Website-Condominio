using Backend_Condominio.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend_Condominio.DTOs
{
    public class ServiceDTO
    {
        public string Name { get; set; }
        public ServiceStatus ServiceStatus { get; set; }
    }
}
