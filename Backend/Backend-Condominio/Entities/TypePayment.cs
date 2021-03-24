using System.Collections.Generic;

namespace Backend_Condominio.Entities
{
    public class TypePayment:ITKey<int>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public List<Payment> Payments { get; set; }

    }
}
