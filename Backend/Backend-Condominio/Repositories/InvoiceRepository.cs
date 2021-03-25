using AutoMapper;
using Backend_Condominio.DTOs.Invoice;
using Backend_Condominio.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend_Condominio.Repositories
{
    public class InvoiceRepository : BaseRepository<Invoice, int, InvoiceFilter, InvoiceCreationDTO>
    {
        private readonly ApplicationDbContext dbContext;

        public InvoiceRepository(ApplicationDbContext dbContext, IMapper mapper): base(dbContext, mapper)
        {
            this.dbContext = dbContext;
        }
    }
}
