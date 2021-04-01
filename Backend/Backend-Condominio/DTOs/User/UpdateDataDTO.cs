using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Backend_Condominio.DTOs.User
{
    public class UpdateDataDTO
    {
        [Required]
        public string UserId { get; set; }

        public string FullName { get; set; }
        public List<ResidenceDataCreationDTO> ResidenceDatas { get; set; } = new List<ResidenceDataCreationDTO>();

    }
}
