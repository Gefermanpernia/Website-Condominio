using Backend_Condominio.DTOs.Mail;

using System.Threading.Tasks;

namespace Backend_Condominio.Utilities
{
    public interface IMailSender
    {
        public Task Send(MailRequest mailRequest);
    }
}
