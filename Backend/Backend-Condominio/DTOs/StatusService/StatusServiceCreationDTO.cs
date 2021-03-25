using System.ComponentModel.DataAnnotations;

namespace Backend_Condominio.DTOs
{
    public class StatusServiceCreationDTO
    {
        [Required]
        public string Title { get; set; }
        [Required]
        public string Text { get; set; }
    }
}
