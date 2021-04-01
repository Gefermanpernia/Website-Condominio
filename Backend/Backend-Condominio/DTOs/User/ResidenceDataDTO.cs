using Backend_Condominio.Utilities;

using System.ComponentModel.DataAnnotations;

namespace Backend_Condominio.DTOs.User
{
    public class ResidenceDataDTO
    {
        [Range(1, ApplicationConstants.NumberOfFloors)]
        public int Floor { get; set; }
        [Range(1,ApplicationConstants.NumberOfApartment)]
        public int ApartmentNumber { get; set; }
     
        public string UserId { get; set; }
    }
}
