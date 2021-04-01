using System;



namespace Backend_Condominio.DTOs.Payment
{
    public class PaymentDTO
    {
        public int TypePaymentId { get; set; }

        public string TypePaymentName { get; set; }
        public int InvoiceId { get; set; }

        public DateTime Date { get; set; }

        public string DepositNumber { get; set; }

        public double Amount { get; set; }
    }
}