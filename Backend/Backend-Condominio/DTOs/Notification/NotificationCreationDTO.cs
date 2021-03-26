using System;
using System.ComponentModel.DataAnnotations;

namespace Backend_Condominio.DTOs.Notification
{
    public class NotificationCreationDTO
    {
        public string UserId { get; set; }
        public int NotificationTypeId { get; set; }
        public bool AlreadySeen { get; set; } = false;
        public DateTime Date { get; set; } = DateTime.Now;
        [Required]
        [MaxLength(1200)]
        public string Content { get; set; }
    }
}
