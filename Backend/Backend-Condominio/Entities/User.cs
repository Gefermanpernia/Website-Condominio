using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace Backend_Condominio.Entities
{
    public class User : IdentityUser
    {
        public List<Invoice> Invoices { get; set; }
        public List<Notification> Notifications { get; set; }
        public string FullName { get; set; }
        public List<ResidenceData> ResidenceDatas { get; set; }

    }
}
