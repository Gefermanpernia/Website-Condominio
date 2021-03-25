using Backend_Condominio.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Backend_Condominio.DTOs
{
    public class ServiceCreationDTO
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public int ServiceStatusId { get; set; }

    }
}
