using AutoMapper;
using Backend_Condominio.DTOs.Activity;
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
    public class ActivityRepository: BaseRepository<Activity, int, ActivityFilter,ActivityCreationDTO>
    {
        private readonly ApplicationDbContext Dbcontext;

        public ActivityRepository(ApplicationDbContext applicationDbContext, IMapper mapper): base(applicationDbContext, mapper)
        {
            this.Dbcontext = applicationDbContext;
        }
        public override Task<List<Activity>> GetAllPaginated(ActivityFilter filter)
        {
            var queryable = Dbcontext.Activities.AsQueryable();
            if (filter!=null)
            {
                if (!string.IsNullOrEmpty(filter.Name))
                {
                    queryable = queryable.Where(x => x.Name.Contains(filter.Name));
                }
                queryable = queryable.Paginate(filter);
            }
            var entities = queryable.ToListAsync();
            return entities;
        }
    }
}
