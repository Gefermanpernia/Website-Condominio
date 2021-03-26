using AutoMapper;

using Backend_Condominio.DTOs.Filters;
using Backend_Condominio.DTOs.Notification;
using Backend_Condominio.Repositories;

using Microsoft.AspNetCore.Mvc;

using System.Threading.Tasks;

namespace Backend_Condominio.Controllers
{
    [ApiController]
    [Route("api/notifications")]
    public class NotificationsController:ControllerBase
    {
        private readonly NotificationRepository notificationRepository;
        private readonly IMapper mapper;

        public NotificationsController(NotificationRepository notificationRepository,
            IMapper mapper)
        {
            this.notificationRepository = notificationRepository;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<NotificationDTO>> GetNotifications([FromQuery] NotificationFilter notificationFilter)
        {
            var notifications = await notificationRepository.GetNotifications(notificationFilter,
                IncludeType:true);

            return mapper.Map<NotificationDTO>(notifications);


        }

        [HttpGet("{id}")]
        public async Task<ActionResult<NotificationDTO>> GetNotification(int id)
        {
            var notification = await notificationRepository.GetNotification(id,
                includeType: true);
            if (notification == null)
            {
                return NotFound();
            }

            return mapper.Map<NotificationDTO>(notification);

        }

        [HttpPost("{id}/markasseen")]
        public async Task<ActionResult> MarkAsSeen(int id)
        {
            var result =await notificationRepository.MarkAsSeen(id);

            if (result)
            {
                return NoContent();
            }

            return NotFound();
        }

        [HttpPost]
        public async Task<ActionResult> Post(NotificationCreationDTO notificationCreationDTO)
        {
            var notification = await notificationRepository.AddUserNotification(notificationCreationDTO);

            if (notification == null)
            {
                return BadRequest();
            }

            var dto = mapper.Map<NotificationDTO>(notification);

            return new CreatedAtActionResult(nameof(GetNotification), "Notifications", new { id = notification.Id }, dto);

        }

        [HttpPost("group")]

        public async Task<ActionResult> PostGroupNotification(
            NotificationForGroupDTO notificationForGroupDTO)
        {
            var notifications =await  notificationRepository.AddNotificationForGroup(notificationForGroupDTO);


            if (notifications.Count == 0)
            {
                return NotFound();
            }

            return NoContent();
        }

    }
}
