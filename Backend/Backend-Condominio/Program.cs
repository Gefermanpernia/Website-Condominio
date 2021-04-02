using Backend_Condominio.Utilities;

using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Backend_Condominio
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var webHost = CreateHostBuilder(args).Build();

            using var scope = webHost.Services.CreateScope();
            using var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

            if (dbContext != null)
            {
                dbContext.Database.Migrate();
            }

            //var emailSender = scope.ServiceProvider.GetRequiredService<IMailSender>();
            //emailSender.Send(new DTOs.Mail.MailRequest
            //{
            //    Body = "Manoooooooooooooooooo!!!",
            //    Destination= "gefermanp@gmail.com",
            //    Title="Email Prueba"
            //});


            webHost.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
