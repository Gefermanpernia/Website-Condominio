﻿using System.ComponentModel.DataAnnotations;

namespace Backend_Condominio.DTOs.Invoice
{
    public class InvoiceCreationDTO
    {
        [Required]
        public int ActivityId { get; set; }
        [Required]
        public string UserId { get; set; }
        [Required]
        public double Price { get; set; }
        [Required]
        public bool IsPaid { get; set; }

    }
}
