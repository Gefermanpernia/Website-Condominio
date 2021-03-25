namespace Backend_Condominio.DTOs.Invoice
{
    public class InvoiceFilter : PaginationDTO
    {
        public int ActivityId { get; set; }
        public string UserId { get; set; }

    }
}
