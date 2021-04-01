using Backend_Condominio.DTOs.Activities;
using Backend_Condominio.DTOs.Payment;
using Backend_Condominio.DTOs.User;
using Backend_Condominio.Entities;

using System.Collections.Generic;

namespace Backend_Condominio.DTOs.Invoice
{
    public class InvoiceDTO
    {
        public int Id { get; set; }
        public string UserId { get; set; }

        public UserDTO User { get; set; }

        public int ActivityId { get; set; }

        public ActivityDTO Activity { get; set; }

        public double Price { get; set; }

        public bool IsPaid { get; set; }

        public List<PaymentDTO> Payments { get; set; }
    }
}
