using AutoMapper;

using Backend_Condominio.DTOs;
using Backend_Condominio.DTOs.Filters;
using Backend_Condominio.Entities;
using Backend_Condominio.Repositories;

using Microsoft.AspNetCore.Mvc;

namespace Backend_Condominio.Controllers
{
    [ApiController]
    [Route("api/typepayments")]
    public class TypePaymentsController :
        ExtendedBaseController<TypePaymentRepository,int,TypePayment,TypePaymentFilter,TypePaymentCreationDTO,TypePaymentDTO>
    {
        public TypePaymentsController(IMapper mapper,
            TypePaymentRepository typePaymentRepository)
            :base(mapper,typePaymentRepository, "TypePayments")
        {

        }
    }
}
