using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend_Condominio.DTOs.Auth
{
    public class ConfirmedUserPasswordDTO
    {
        public string Token { get; set; }
        public string UserId { get; set; }
        public string Password { get; set; } 
    }
}
