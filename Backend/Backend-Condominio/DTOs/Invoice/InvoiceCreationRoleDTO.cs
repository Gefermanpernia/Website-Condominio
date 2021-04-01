using System.ComponentModel.DataAnnotations;

namespace Backend_Condominio.DTOs.Invoice
{
    public class InvoiceCreationRoleDTO
    {
        [Required]
        public int ActivityId { get; set; }
        [Required]
        public string RoleName { get; set; }
        [Required]
        public double Price { get; set; }
        [Required]
        public bool IsPaid { get; set; }
    }
}
