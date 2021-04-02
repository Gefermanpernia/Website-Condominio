using Backend_Condominio.DTOs.Mail;
using Backend_Condominio.Settings;

using MailKit.Net.Smtp;

using Microsoft.Extensions.Options;

using MimeKit;

using System;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace Backend_Condominio.Utilities
{
    public class MailSenderUsingGmailSMTP : IMailSender
    {
        private MailSettings _mailSettings;
        private Channel<MailRequest> _emailChannel;
        private Task _emailSendingTask;
        public MailSenderUsingGmailSMTP(IOptions<MailSettings> options)
        {
            _mailSettings = options.Value;
            _emailChannel = Channel.CreateUnbounded<MailRequest>();
            _emailSendingTask = StartEmailPipeline();
        }

        private async Task StartEmailPipeline()
        {
            while (await _emailChannel.Reader.WaitToReadAsync())
            {
               
                if(_emailChannel.Reader.TryRead(out var emailRequest))
                {
                    try
                    { 
                        var client = await GetClient();
                        var message = BuildMessage(emailRequest);
                        await client.SendAsync(message);
                    }
                    catch (Exception ex)
                    {
                        //TODO:
                        //Log error
                        await Send(emailRequest);
                        await Task.Delay(1000);

                    }
                }
            }
        }

      

        private SmtpClient _emailClient;
        private async Task<SmtpClient> GetClient()
        {
            if(_emailClient == null)
            {
                _emailClient = new();
            }
            if (!_emailClient.IsConnected)
            {
                await _emailClient.ConnectAsync(_mailSettings.Host, _mailSettings.Port, 
                    MailKit.Security.SecureSocketOptions.StartTls);
            }
            if (!_emailClient.IsAuthenticated)
            {
                await _emailClient.AuthenticateAsync(_mailSettings.Mail, _mailSettings.Password);
            }

            return _emailClient;

        }
        private MimeMessage BuildMessage(MailRequest mailRequest)
        {
            BodyBuilder bodyBuilder = new BodyBuilder();
            bodyBuilder.TextBody = mailRequest.Body;
            var message = new MimeMessage
            {
                To=
                {
                    InternetAddress.Parse(mailRequest.Destination)
                },
                Subject = mailRequest.Title,
                Sender = MailboxAddress.Parse(_mailSettings.Mail),
                Body = bodyBuilder.ToMessageBody()
            };

            return message;   
        }
 
      public async Task Send(MailRequest mailRequest)
        {
            if(mailRequest == null)
            {
                throw new ArgumentException("Mail request can't be null");
            }
            if (string.IsNullOrEmpty(mailRequest.Destination))
            {
                throw new ArgumentException("Destination can't be empty");
            }
            await _emailChannel.Writer.WriteAsync(mailRequest);
        }
    }
}
