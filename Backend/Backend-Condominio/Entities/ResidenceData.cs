<<<<<<< Updated upstream
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
=======
﻿using Backend_Condominio.Utilities;

using System.ComponentModel.DataAnnotations;
>>>>>>> Stashed changes

namespace Backend_Condominio.Entities
{
    public class ResidenceData
    {
        [Range(1, ApplicationConstants.NumberOfFloors)]
        public int Floor { get; set; }
        [Range(1, ApplicationConstants.NumberOfApartment)]
        public int ApartmentNumber { get; set; }
        public string UserId { get; set; }
        public User User { get; set; }


    }
}
