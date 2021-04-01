using AutoMapper;

using Backend_Condominio.DTOs.Filters;
using Backend_Condominio.DTOs.Notification;
using Backend_Condominio.Entities;
using Backend_Condominio.Helpers;

using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend_Condominio.Repositories
{
    public class NotificationRepository
    {
        private readonly ApplicationDbContext applicationDbContext;
        private readonly IMapper mapper;
        private readonly UserManager<User> userManager;

        public NotificationRepository(ApplicationDbContext applicationDbContext,
            IMapper mapper,
            UserManager<User> userManager)
        {
            this.applicationDbContext = applicationDbContext;
            this.mapper = mapper;
            this.userManager = userManager;
        }

        public  Task<List<Notification>> GetNotifications(NotificationFilter filter,bool IncludeType = false, bool IncludeUser=false)
        {
            var queryable = applicationDbContext.Notifications.AsQueryable();

            if (!string.IsNullOrEmpty(filter.UserId))
            {
                queryable = queryable.Where(n=> n.UserId == filter.UserId);
            }

            if (filter.OnlyNotSeen)
            {
                  queryable = queryable.Where(n =>!n.AlreadySeen);
            }

            if (filter.From.HasValue)
            {
                queryable = queryable.Where(n => n.Date > filter.From);
            }

            if (filter.Until.HasValue)
            {
                queryable = queryable.Where(n => n.Date < filter.Until);
            }

            if (filter.NotificationTypeId.HasValue)
            {
                queryable = queryable.Where(n => n.NotificationTypeId == filter.NotificationTypeId);
            }

            queryable = queryable.Paginate(filter);

            if (IncludeType)
            {
                queryable = queryable.Include(n => n.NotificationType);
            }
            if (IncludeUser)
            {
                queryable = queryable.Include(n => n.User);
            }

            queryable = queryable.OrderByDescending(n=> n.Date); 
            

            return queryable.ToListAsync();

        }

        public Task<Notification> GetNotification(int id,bool includeType= false, bool includeUser = false)
        {
            var queryable = applicationDbContext.Notifications.AsQueryable();

            if (includeType)
            {
                queryable = queryable.Include(n => n.NotificationType);
            }
            if (includeUser)
            {
                queryable = queryable.Include(n => n.User);
            }
            return queryable.FirstOrDefaultAsync(n => n.Id == id);
        }

        public async Task<bool> MarkAsSeen(int id)
        {
            var notification = await applicationDbContext.Notifications.FirstOrDefaultAsync(n => n.Id == id 
            && !n.AlreadySeen);
            if (notification == null)
            {
                return false;
            }

            applicationDbContext.Attach(notification);
            notification.AlreadySeen = true;

            await applicationDbContext.SaveChangesAsync();

            return true;

        }


        public async Task<Notification> AddUserNotification(NotificationCreationDTO notification)
        {
            try
            {
                var entity = mapper.Map<Notification>(notification);
                applicationDbContext.Add(entity);
                await applicationDbContext.SaveChangesAsync();
                return entity;
            }
            catch (DbUpdateException)
            {
                return null;
            }
        }

        public async Task<List<Notification>> AddNotificationForGroup(NotificationForGroupDTO notificationCreationDTO)
        {
            try
            {
                var users =await userManager.GetUsersInRoleAsync(notificationCreationDTO.Role);

                var notifications = Enumerable.Range(0, users.Count)
                    .Select(n => mapper.Map<Notification>(notificationCreationDTO))
                    .ToList();

                for(int i = 0; i < users.Count; i++)
                {
                    notifications[i].UserId = users[i].Id; 
                }

                applicationDbContext.AddRange(notifications);

                await applicationDbContext.SaveChangesAsync();

                return notifications;

            }
            catch (DbUpdateException)
            {
                return null;
            }

        }


    }
}
