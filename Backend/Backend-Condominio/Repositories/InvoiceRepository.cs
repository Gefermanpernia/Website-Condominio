using AutoMapper;

using Backend_Condominio.DTOs.Filters;
using Backend_Condominio.DTOs.Invoice;
using Backend_Condominio.Entities;
using Backend_Condominio.Helpers;

using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace Backend_Condominio.Repositories
{
    public class InvoiceRepository
    {
        private readonly ApplicationDbContext dbContext;
        private readonly IMapper mapper;
        private readonly UserManager<User> userManager;

        public InvoiceRepository(ApplicationDbContext dbContext, IMapper mapper,
            UserManager<User> userManager)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
            this.userManager = userManager;
        }

        public  Task<Invoice> GetInvoice(string userId,int activityId,InvoiceIncludeFilters invoiceIncludeFilters)
        {
            var queryable = dbContext.Invoices.AsQueryable();

            queryable = queryable.ApplyIncludes(invoiceIncludeFilters);

            return queryable.FirstOrDefaultAsync(a => a.ActivityId == activityId && a.UserId == userId);
        }
        public Task<List<Invoice>> GetInvoicesPaginated(InvoiceFilter invoiceFilter,InvoiceIncludeFilters invoiceIncludeFilters)
        {
            var queryable = dbContext.Invoices.AsQueryable();

            queryable = queryable.ApplyIncludes(invoiceIncludeFilters);

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

        public async Task<Invoice> CreateInvoiceForUser(InvoiceCreationDTO invoice)
        {
            try
            {
                var entity = mapper.Map<Invoice>(invoice);
                dbContext.Add(entity);
                await dbContext.SaveChangesAsync();
                return entity;
            }
            catch (DbUpdateException)
            {
                return null;
            }
        }
        public async Task<List<Invoice>> CreateInvoiceForRol(InvoiceCreationRoleDTO invoice)
        {
            var roleExist = await dbContext.Roles.AnyAsync(x => x.NormalizedName == invoice.RoleName);
            if (!roleExist)
            {
                return null;
            }
            var usersInRole = await userManager.GetUsersInRoleAsync(invoice.RoleName);
     
            var invoices = usersInRole.Select(id => mapper.Map<Invoice>(invoice)).ToList();
            try
            {
                for (int i = 0; i < usersInRole.Count; i++)
                {
                    invoices[i].UserId = usersInRole[i].Id;
                }
                dbContext.AddRange(invoices);

                await dbContext.SaveChangesAsync();

                return invoices;
            }
            catch (DbUpdateException)
            {
                return null;
            }
        }
        public async Task<bool> UpdateInvoice(InvoiceFilter invoiceFilter, InvoiceCreationDTO invoiceCreationDTO)
        {
            var entity = await dbContext.Invoices.FirstOrDefaultAsync(x => x.ActivityId.Equals(invoiceFilter.ActivityId) && x.UserId.Equals(invoiceFilter.UserId));
            if (entity == null)
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
            if (invoiceFilter.ActivityId.HasValue && !string.IsNullOrEmpty(invoiceFilter.UserId))
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
            return false;

        }
    }
}
