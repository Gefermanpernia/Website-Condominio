using AutoMapper;

using Backend_Condominio.DTOs;
using Backend_Condominio.Entities;

namespace Backend_Condominio.Utilities
{
    public class AutoMapperProfiles :Profile
    {
        public AutoMapperProfiles()
        {
            // =========================================================
            //                      Type Payment
            // =========================================================            
            CreateMap<TypePaymentCreationDTO, TypePayment>();
            CreateMap<TypePayment, TypePaymentDTO>().ReverseMap();
            // =========================================================
            //                      Type Notification
            // =========================================================
            CreateMap<TypeNotificationCreationDTO, NotificationType>();
            CreateMap<NotificationType, TypeNotificationDTO>().ReverseMap();
            // =========================================================
            //                      Service
            // ========================================================= 
            CreateMap<ServiceCreationDTO, Service>();
            CreateMap<Service, ServiceDTO>().ReverseMap();
            // =========================================================
            //                      Statu Service 
            // ========================================================= 
            CreateMap<StatusServiceCreationDTO, ServiceStatus>();
            CreateMap<ServiceStatus, StatusServiceDTO>().ReverseMap();
            // =========================================================
            //                      Payment
            // ========================================================= 

            // =========================================================
            //                      Activity
            // ========================================================= 

            // =========================================================
            //                      Commentary
            // ========================================================= 
        }
    }
}
