using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend_Condominio.Entities
{
    public class ResidenceData
    {
        public int Id { get; set; }
        public int Floor { get; set; }
        public int ApartmentNumber { get; set; }
        public string UserId { get; set; }
        public User User { get; set; }


    }
}
