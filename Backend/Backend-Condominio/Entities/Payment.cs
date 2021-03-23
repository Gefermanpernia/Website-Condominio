using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend_Condominio.Entities
{
    public class Payment
    {
        public int TypePaymentId { get; set; }
        
        public TypePayment TypePayment { get; set; }

        public int InvoiceId { get; set; }
        
        public Invoice Invoice { get; set; }

        public DateTime Date { get; set; }
        
        public string DepositNumber { get; set; }
        
        public double Amount { get; set; }

    }
}
