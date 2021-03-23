using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend_Condominio.Entities
{
    public class Notification
    {
        public string UserId { get; set; }

        public User User { get; set; }

        public int NotificationTypeId { get; set; }

        public NotificationType NotificationType { get; set; }
        
        public string Content { get; set; }
    }

}
