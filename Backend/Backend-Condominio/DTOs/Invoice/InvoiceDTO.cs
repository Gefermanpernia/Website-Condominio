using Backend_Condominio.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend_Condominio.DTOs.Invoice
{
    public class InvoiceDTO
    {
        public string UserId { get; set; }

        public Entities.User User { get; set; }

        public int ActivityId { get; set; }

        public Activity Activity { get; set; }

        public double Price { get; set; }

        public bool IsPaid { get; set; }

        public List<Entities.Payment> Payments { get; set; }
    }
}
