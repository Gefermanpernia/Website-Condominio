using System.ComponentModel.DataAnnotations;

namespace Backend_Condominio.DTOs.Auth
{
    public class RegisterDTO
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        public string Password { get; set; }

        public string FullName { get; set; }

    }
}
