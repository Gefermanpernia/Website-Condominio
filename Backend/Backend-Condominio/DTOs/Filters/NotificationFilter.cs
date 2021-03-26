using System;
using System.ComponentModel.DataAnnotations;

namespace Backend_Condominio.DTOs.Filters
{
    public class NotificationFilter : PaginationDTO
    {
        [Required]
        public string UserId { get; set; }
        public DateTime? From { get; set; }

        public DateTime? Until { get; set; }

        public bool OnlyNotSeen { get; set; } = false;

        public int? NotificationTypeId { get; set; }
    }
}
