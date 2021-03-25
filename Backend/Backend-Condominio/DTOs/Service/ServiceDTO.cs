namespace Backend_Condominio.DTOs
{
    public class ServiceDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public StatusServiceDTO ServiceStatus { get; set; }
    }
}
