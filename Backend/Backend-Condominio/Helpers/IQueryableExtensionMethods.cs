using Backend_Condominio.DTOs;
using Backend_Condominio.DTOs.Filters;
using Backend_Condominio.Entities;

using Microsoft.EntityFrameworkCore;

using System.Linq;

namespace Backend_Condominio.Helpers
{
    public static class IQueryableExtensionMethods
    {
        public static IQueryable<T> Paginate<T>(this IQueryable<T> queryable, PaginationDTO paginationDTO)
        {
            return queryable.Skip((paginationDTO.Page - 1) * paginationDTO.RecordsPerPage)
                .Take(paginationDTO.RecordsPerPage);

        }

        public static IQueryable<Invoice> ApplyIncludes(this IQueryable<Invoice> queryable, InvoiceIncludeFilters invoiceIncludeFilters)
        {
            if (invoiceIncludeFilters.IncludeUser)
            {
                queryable = queryable.Include(x => x.User);
            }
            if (invoiceIncludeFilters.IncludeActivity)
            {
                queryable = queryable.Include(x => x.Activity);
            }

            if (invoiceIncludeFilters.IncludeTypePayments)
            {
                queryable = queryable.Include(x => x.Payments)
                    .ThenInclude(x => x.TypePayment);
            }
            else if (invoiceIncludeFilters.IncludePayments)
            {
                queryable = queryable.Include(x => x.Payments);
            }

            return queryable;
        }
    }
}
