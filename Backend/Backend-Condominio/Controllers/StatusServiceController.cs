using AutoMapper;
using Backend_Condominio.DTOs;
using Backend_Condominio.DTOs.Filters;
using Backend_Condominio.Entities;
using Backend_Condominio.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend_Condominio.Controllers
{
    [ApiController]
    [Route("api/StatusService")]
    public class StatusServiceController : ExtendedBaseController<StatusServiceRepository, int, ServiceStatus, StatusServiceFilter, StatusServiceCreationDTO, StatusServiceDTO>
    {
        public StatusServiceController(IMapper mapper, StatusServiceRepository statusServiceRepository) : base(mapper, statusServiceRepository, "StatusService")
        {

        }
    }
}
