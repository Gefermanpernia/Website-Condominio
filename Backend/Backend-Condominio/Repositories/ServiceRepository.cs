﻿using AutoMapper;
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
    public class ServiceRepository : BaseRepository<Service, int, ServiceFilter, ServiceCreationDTO>
    {
        private ApplicationDbContext DbContext;

        public ServiceRepository(ApplicationDbContext applicationDbContext, IMapper mapper) : base(applicationDbContext, mapper)
        {
            this.DbContext = applicationDbContext;
    
        }

        public override async Task<List<Service>> GetAllPaginated(ServiceFilter filter)
        {
            var queryable = DbContext.ServicesT.AsQueryable();
            queryable = queryable.Include(x => x.ServiceStatus);
            if (filter!=null)
            {
                if (!string.IsNullOrEmpty(filter.Name))
                {
                    queryable = queryable.Where(x => x.Name.Contains(filter.Name));
                }
                if (filter.ServiceStatusId.HasValue)
                {
                    queryable = queryable.Where(x => x.ServiceStatusId.Equals(filter.ServiceStatusId));
                }
                queryable = queryable.Paginate(filter);

            }
                var entities = await queryable.ToListAsync();

                return entities;
        }

        public override Task<Service> Get(int id)
        {
            return DbContext.ServicesT
                .Include(y => y.ServiceStatus)
                .FirstOrDefaultAsync(y => y.Id == id);
        }
    }
}
