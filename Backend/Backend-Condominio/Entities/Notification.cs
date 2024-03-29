﻿using System;
using System.ComponentModel.DataAnnotations;

namespace Backend_Condominio.Entities
{
    public class Notification
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string UserId { get; set; }

        public User User { get; set; }

        
        public int NotificationTypeId { get; set; }

        public NotificationType NotificationType { get; set; }

        public bool AlreadySeen { get; set; }

        public DateTime Date { get; set; } = DateTime.Now;

        [Required]
        [MaxLength(1200)]
        public string Content { get; set; }
    }

}
