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
    public class StatusServiceRepository : BaseRepository<ServiceStatus, int, StatusServiceFilter, StatusServiceCreationDTO>
    {
        private readonly ApplicationDbContext DbContext;

        public StatusServiceRepository(ApplicationDbContext applicationDbContext, IMapper mapper) : base(applicationDbContext, mapper)
        {
            this.DbContext = applicationDbContext;
        }

        public override async Task<List<ServiceStatus>> GetAllPaginated(StatusServiceFilter filter)
        {
            var queryable = DbContext.ServiceStatuses.AsQueryable();
            if (filter != null)
            {
                if (!string.IsNullOrEmpty(filter.Title))
                {
                    queryable = queryable.Where(x => x.Title.Contains(filter.Title));
                }
                if (filter.Services != null && filter.Services.Count > 0)
                {
                    queryable = queryable.Include(x => x.Services);
                    queryable = queryable.Where(serviceStatus => serviceStatus.Services.Any(service =>filter.Services.Contains(service)));

                }
                queryable = queryable.Paginate(filter);
            }


            var entities = await queryable.ToListAsync();
            return entities;
        }
    }
}
