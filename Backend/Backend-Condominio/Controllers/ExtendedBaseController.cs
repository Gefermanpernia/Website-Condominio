using AutoMapper;

using Backend_Condominio.DTOs;
using Backend_Condominio.Entities;
using Backend_Condominio.Repositories;

using Microsoft.AspNetCore.Mvc;

using System.Collections.Generic;
using System.Threading.Tasks;

namespace Backend_Condominio.Controllers
{
    public class ExtendedBaseController<TRepository,
        TValue, 
        TEntity, 
        TFilter, 
        TCreation, 
        TDTO>
        : ControllerBase
        where TEntity : class, ITKey<TValue>
        where TFilter : PaginationDTO
        where TCreation : class
        where TRepository : BaseRepository<TEntity, TValue, TFilter, TCreation>

    {
        private readonly IMapper mapper;
        private readonly TRepository repository;
        private readonly string controllerName;

        public ExtendedBaseController(
            IMapper mapper,
            TRepository repository,
            string ControllerName)
        {
            this.mapper = mapper;
            this.repository = repository;
            controllerName = ControllerName;
        }

        [HttpGet]
        public virtual async Task<ActionResult<List<TEntity>>> Get(TFilter filter)
        {
            if (filter != null)
            {
                return await repository.GetAllPaginated(filter);
            }

            return await repository.GetAll();
        } 

        [HttpGet("{Id}")]
        public virtual async Task<ActionResult<TEntity>> Get(TValue Id)
        {
            return await repository.Get(Id);
        }

        [HttpPost]
        public virtual async Task<ActionResult> Post(TCreation creation)
        {
            var entity = mapper.Map<TEntity>(creation);

            entity = await repository.CreateEntity(entity);

            var dto = mapper.Map<TDTO>(entity);

            return new CreatedAtActionResult(nameof(Get), controllerName, new { Id = entity.Id }, dto);
        }


        [HttpPut("{Id}")]
        public virtual async Task<ActionResult> Put(TValue Id,TCreation creation)
        {
            var result = await repository.Update(Id, creation);
            if (!result)
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpDelete("{Id}")]
        public virtual async Task<ActionResult> Delete(TValue Id)
        {
            var result = await repository.Delete(Id);
            if (!result)
            {
                return NotFound();
            }

            return NoContent();
        }


    }

}
