using AutoMapper;

using System;
using System.Collections.Generic;
using System.Linq;

namespace Backend_Condominio.Repositories
{
    public class NotificationRepository
    {
        private readonly ApplicationDbContext applicationDbContext;
        private readonly IMapper mapper;

        public NotificationRepository(ApplicationDbContext applicationDbContext,
            IMapper mapper)
        {
            this.applicationDbContext = applicationDbContext;
            this.mapper = mapper;
        }


    }
}
