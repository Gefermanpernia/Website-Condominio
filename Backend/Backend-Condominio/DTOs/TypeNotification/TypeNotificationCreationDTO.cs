using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Backend_Condominio.DTOs
{
    public class TypeNotificationCreationDTO
    {
        [Required]
        public string Name { get; set; }

    }
}
