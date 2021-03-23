using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend_Condominio.Entities
{
    public class TypePayment
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public List<Payment> Payments { get; set; }

    }
}
