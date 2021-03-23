using Backend_Condominio.DTOs;

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
    }
}
