using System;

namespace Backend_Condominio.DTOs.Notification
{
    public class NotificationDTO
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public int NotificationTypeId { get; set; }
        public string NotificationTypeName { get; set; }
        public bool AlreadySeen { get; set; }
        public DateTime Date { get; set; }
        public string Content { get; set; }
    }
}
