using AutoMapper;

using Backend_Condominio.DTOs;
using Backend_Condominio.Entities;
using Backend_Condominio.Helpers;

using Microsoft.EntityFrameworkCore;

using System.Collections.Generic;
using System.Threading.Tasks;

namespace Backend_Condominio.Repositories
{
    public class BaseRepository<TEntity, TValue, TFilter,TEntityUpdate>
        where TEntity : class, ITKey<TValue>
        where TEntityUpdate:class
        where TFilter :PaginationDTO
    {
        private readonly ApplicationDbContext applicationDbContext;
        private readonly IMapper mapper;

        public BaseRepository(
            ApplicationDbContext applicationDbContext,
            IMapper mapper)
        {
            this.applicationDbContext = applicationDbContext;
            this.mapper = mapper;
        }

        public virtual Task<List<TEntity>> GetAllPaginated(TFilter filter)
        {
            var queryable = applicationDbContext.Set<TEntity>().AsQueryable();

            queryable = queryable.Paginate(filter);

            return queryable.ToListAsync();

        }
        public virtual Task<List<TEntity>> GetAll()
        {
            return applicationDbContext.Set<TEntity>().ToListAsync();
        }

        public virtual Task<TEntity> Get(TValue id)
        {
            return applicationDbContext.Set<TEntity>().FirstOrDefaultAsync(e => e.Id.Equals(id));
        }


        public virtual async Task<TEntity> CreateEntity(TEntity entity)
        {
            applicationDbContext.Add(entity);
            await applicationDbContext.SaveChangesAsync();

            return entity;
        }

        public virtual async Task<bool> Update(TValue id,TEntityUpdate entityUpdate )
        {
            var entity = await applicationDbContext.Set<TEntity>().FirstOrDefaultAsync(e => e.Id.Equals(id));
                                                                                                   

            if(entity == null)
            {
                return false;
            }

            mapper.Map(entityUpdate, entity);

            applicationDbContext.Entry(entity).State = EntityState.Modified;

            await applicationDbContext.SaveChangesAsync();


            return true;
        }

        public virtual async Task<bool> Delete(TValue id)
        {
            var entity = await applicationDbContext.Set<TEntity>().FirstOrDefaultAsync(e => e.Id.Equals(id));
            if (entity == null)
            {
                return false;
            }
            applicationDbContext.Entry(entity).State = EntityState.Deleted;
            await applicationDbContext.SaveChangesAsync();

            return true;
        }

    }
}
