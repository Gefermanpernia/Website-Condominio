﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend_Condominio.Entities
{
    public class Invoice
    {
        public string UserId { get; set; }

        public User User { get; set; }

        public int ActivityId { get; set; }

        public Activity Activity { get; set; }

        public double Price { get; set; }

        public bool IsPaid { get; set; }

        public List<Payment> Payments { get; set; }




    }
}