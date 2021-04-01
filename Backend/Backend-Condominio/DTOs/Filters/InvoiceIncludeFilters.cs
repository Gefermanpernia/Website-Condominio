namespace Backend_Condominio.DTOs.Filters
{
    public class InvoiceIncludeFilters
    {
        public bool IncludeUser { get; set; } = false;
        public bool IncludeActivity { get; set; } = false;
        public bool IncludePayments { get; set; } = false;
        public bool IncludeTypePayments { get; set; } = false;
    }
}
