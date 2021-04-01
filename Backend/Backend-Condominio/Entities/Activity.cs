using System.Collections.Generic;

namespace Backend_Condominio.Entities
{
    public class Activity : ITKey<int>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public List<Invoice> Invoices { get; set; }

    }
}
