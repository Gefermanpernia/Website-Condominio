using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend_Condominio.Entities
{
    public class Service
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int ServicesStatusId { get; set; }

        public ServiceStatus ServiceStatus { get; set; }

    }
}
