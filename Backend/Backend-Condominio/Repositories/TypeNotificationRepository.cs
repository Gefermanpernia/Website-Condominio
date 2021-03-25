using AutoMapper;
using Backend_Condominio.DTOs;
using Backend_Condominio.DTOs.Filters;
using Backend_Condominio.Entities;
using Backend_Condominio.Helpers;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend_Condominio.Repositories
{
    public class TypeNotificationRepository : BaseRepository<NotificationType,int, TypeNotificationFilter, TypeNotificationCreationDTO >
    {
        public TypeNotificationRepository(ApplicationDbContext
            applicationDbContext, IMapper mapper) : base(applicationDbContext, mapper)
        {
            DbContext = applicationDbContext;
        }

        private ApplicationDbContext DbContext { get; }

        public async override Task<List<NotificationType>> GetAllPaginated(TypeNotificationFilter filter)
        {
            var queryable = DbContext.NotificationTypes.AsQueryable();
            if (filter!=null)
            {
                if (!string.IsNullOrEmpty(filter.Name))
                {
                    queryable = queryable.Where(x => x.Name.Contains(filter.Name));
                }
                queryable = queryable.Paginate(filter);

            }

            var entities = await queryable.ToListAsync();

            return entities;
            
        }
    }
}
