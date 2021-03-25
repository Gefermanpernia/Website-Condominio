using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend_Condominio.Entities
{
    public class Service : ITKey<int>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int? ServiceStatusId { get; set; }
        public ServiceStatus ServiceStatus { get; set; }

    }
}
