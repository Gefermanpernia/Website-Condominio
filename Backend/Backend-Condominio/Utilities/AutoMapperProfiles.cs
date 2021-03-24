using AutoMapper;

using Backend_Condominio.DTOs;
using Backend_Condominio.Entities;

namespace Backend_Condominio.Utilities
{
    public class AutoMapperProfiles :Profile
    {
        public AutoMapperProfiles()
        {
            // ---------------------------------------------TypePayments------------------------------------------
            CreateMap<TypePaymentCreationDTO, TypePayment>();
            CreateMap<TypePayment, TypePaymentDTO>().ReverseMap();
            //==========================TypeNotification===============//
            CreateMap<TypeNotificationCreationDTO, NotificationType>();
            CreateMap<NotificationType, TypeNotificationDTO>().ReverseMap();


        }
    }
}
