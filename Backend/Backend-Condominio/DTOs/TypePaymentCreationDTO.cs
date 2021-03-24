using System.ComponentModel.DataAnnotations;

namespace Backend_Condominio.DTOs
{
    public class TypePaymentCreationDTO
    {
        [Required]
        public string Name { get; set; }
    }
}
