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
        public virtual async Task<ActionResult<List<TDTO>>> Get([FromQuery]TFilter filter)
        {
            List<TEntity> entities;
            if (filter != null)
            {
                entities = await repository.GetAllPaginated(filter);
            }
            else
            {
                entities =  await repository.GetAll();
            }

            return mapper.Map<List<TDTO>>(entities);
        } 

        [HttpGet("{Id}")]
        public virtual async Task<ActionResult<TDTO>> Get(TValue Id)
        {
            var entity =  await repository.Get(Id);

            if(entity == null)
            {
                return NotFound();
            }

            return mapper.Map<TDTO>(entity);
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
