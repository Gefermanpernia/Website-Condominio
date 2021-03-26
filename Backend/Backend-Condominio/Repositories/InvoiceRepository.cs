using AutoMapper;
using Backend_Condominio.DTOs.Invoice;
using Backend_Condominio.Entities;
using Backend_Condominio.Helpers;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend_Condominio.Repositories
{
    public class InvoiceRepository
    {
        private readonly ApplicationDbContext dbContext;
        private readonly IMapper mapper;

        public InvoiceRepository(ApplicationDbContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }

        public Task<List<Invoice>> GetInvoicesPaginated(InvoiceFilter invoiceFilter)
        {
            var queryable = dbContext.Invoices.AsQueryable();
            queryable = FindIds(invoiceFilter, queryable);

            queryable = queryable.Paginate(invoiceFilter);

            return queryable.ToListAsync();
        }

        private static IQueryable<Invoice> FindIds(InvoiceFilter invoiceFilter, IQueryable<Invoice> queryable)
        {
            if (!string.IsNullOrEmpty(invoiceFilter.UserId))
            {
                queryable = queryable.Where(x => x.UserId.Contains(invoiceFilter.UserId));
            }
            if (invoiceFilter.ActivityId.HasValue)
            {
                queryable = queryable.Where(x => x.ActivityId.Equals(invoiceFilter.ActivityId));
            }

            return queryable;
        }

        public Task<List<Invoice>> GetInvoices()
        {
            return dbContext.Invoices.ToListAsync();
        }
        public async Task<Invoice> CreateInvoiceForUser(Invoice invoiceCreationDTO)
        {
            if (!string.IsNullOrEmpty(invoiceCreationDTO.UserId))
            {
                dbContext.Add(invoiceCreationDTO);
                await dbContext.SaveChangesAsync();
                return invoiceCreationDTO;
            }
            return null;
        }
        public Task<Invoice> CreateInvoiceForRol(Invoice invoice)
        {

        }
        public async Task<bool> UpdateInvoice(InvoiceFilter invoiceFilter, InvoiceCreationDTO invoiceCreationDTO)
        {
            var entity = await dbContext.Invoices.FirstOrDefaultAsync(x => x.ActivityId.Equals(invoiceFilter.ActivityId) && x.UserId.Equals(invoiceFilter.UserId));
            if (entity==null)
            {
                return false;
            }
            mapper.Map(invoiceCreationDTO, entity);
            dbContext.Entry(entity).State = EntityState.Modified;
            await dbContext.SaveChangesAsync();
            return true;
        }
        public async Task<bool> DeleteInvoice(InvoiceFilter invoiceFilter)
        {
            var queryable = dbContext.Invoices.AsQueryable();
            queryable = FindIds(invoiceFilter, queryable);
            var entity = queryable.ToListAsync();
            if (entity == null)
            {
                return false;
            }
            dbContext.Entry(entity).State = EntityState.Deleted;
            await dbContext.SaveChangesAsync();
            return true;
        }
    }
}
