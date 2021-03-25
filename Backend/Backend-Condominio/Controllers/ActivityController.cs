using AutoMapper;
using Backend_Condominio.DTOs.Activity;
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
    [Route("api/Activity")]
    public class ActivityController: ExtendedBaseController<ActivityRepository, int, Activity, ActivityFilter,ActivityCreationDTO, ActivityDTO>
    {
        public ActivityController(IMapper mapper, ActivityRepository activityRepository): base(mapper, activityRepository, "Activity")
        {

        }
    }
}
