using AutoMapper;

using Backend_Condominio.DTOs;
using Backend_Condominio.DTOs.Filters;
using Backend_Condominio.Entities;


namespace Backend_Condominio.Repositories
{
    public class TypePaymentRepository :
        BaseRepository<TypePayment, int, TypePaymentFilter, TypePaymentCreationDTO>
    {


        public TypePaymentRepository(ApplicationDbContext applicationDbContext,
            IMapper mapper)
            :base(applicationDbContext,mapper)
        {}


      
    }
}
