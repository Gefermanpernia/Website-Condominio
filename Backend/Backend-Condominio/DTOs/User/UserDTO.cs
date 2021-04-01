using System.Collections.Generic;

namespace Backend_Condominio.DTOs.User
{
    public class UserDTO
    {
        public string FullName { get; set; }

        public List<ResidenceDataDTO> ResidenceDatas { get; set; }
    }
}
