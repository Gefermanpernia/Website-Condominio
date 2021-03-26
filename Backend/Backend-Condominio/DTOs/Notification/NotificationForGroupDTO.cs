

using System;
using System.ComponentModel.DataAnnotations;


namespace Backend_Condominio.DTOs.Notification
{
    public class NotificationForGroupDTO
    {
        [Required]
        public string Role { get; set; }
        public int NotificationTypeId { get; set; }
        public DateTime Date { get; set; } = DateTime.Now;
        [Required]
        [MaxLength(1200)]
        public string Content { get; set; }
    }
}
