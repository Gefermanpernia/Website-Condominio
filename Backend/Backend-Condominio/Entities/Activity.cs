using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend_Condominio.Entities
{
    public class Activity: ITKey<int>
    {
        public int Id { get; set; }
<<<<<<< Updated upstream
        
        public string Name { get; set; }
=======

        public string Name { get; set; } 
>>>>>>> Stashed changes

        public string Description { get; set; } 

        public List<Invoice> Invoices { get; set; } 

    }
}
