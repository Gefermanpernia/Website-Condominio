using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend_Condominio.Entities
{
    public class NotificationType
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Notification> Notifications { get; set; }

    }
}
