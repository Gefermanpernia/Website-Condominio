using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend_Condominio.Entities
{
    public class ServiceStatus
    {
        public int Id { get; set; }

        public string Title { get; set; }
        
        public string Text { get; set; }

        public List<Service> Services { get; set; }


    }
}
