using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend_Condominio.DTOs.Filters
{
    public class TypeNotificationFilter : PaginationDTO
    {

        public string Name { get; set; }
    }
}
