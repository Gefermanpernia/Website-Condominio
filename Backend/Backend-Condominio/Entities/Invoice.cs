using System.Collections.Generic;

namespace Backend_Condominio.Entities
{
    public class Invoice
    {
        public int Id { get; set; }
        public string UserId { get; set; }

        public User User { get; set; }

        public int ActivityId { get; set; }

        public Activity Activity { get; set; }

        public double Price { get; set; }

        public bool IsPaid { get; set; }

        public List<Payment> Payments { get; set; }




    }
}
