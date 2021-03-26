using Backend_Condominio.Entities;
using Backend_Condominio.Utilities;

using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Backend_Condominio
{
    public class ApplicationDbContext : IdentityDbContext<User>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
            

        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
           

            // ------- Add default Data--------------------------------------------
            builder.Entity<IdentityRole>().HasData(new IdentityRole
            {
                Id = ApplicationConstants.Roles.AdminRoleId,
                Name=ApplicationConstants.Roles.AdminRoleName,
                NormalizedName=ApplicationConstants.Roles.AdminRoleName
            });

            builder.Entity<IdentityRole>().HasData(new IdentityRole
            {
                Id = ApplicationConstants.Roles.CondominioMemberId,
                Name = ApplicationConstants.Roles.CondominioMemberName,
                NormalizedName = ApplicationConstants.Roles.CondominioMemberName
            });

            builder.Entity<IdentityRole>().HasData(new IdentityRole
            {
                Id = ApplicationConstants.Roles.ResidentId,
                Name = ApplicationConstants.Roles.ResidentName,
                NormalizedName = ApplicationConstants.Roles.ResidentName
            });


            //-----------------End default data---------------------------------
            //------------------Entities configuration----------------------

            builder.Entity<Invoice>().HasKey(x => new { x.UserId, x.ActivityId });
            builder.Entity<Notification>().HasKey(x => x.Id);
            builder.Entity<Notification>()
                .HasOne(n => n.NotificationType)
                .WithMany(n => n.Notifications)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<Notification>()
                .HasOne(n => n.User)
                .WithMany(n => n.Notifications)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<Payment>().HasKey(x => new { x.InvoiceId, x.TypePaymentId });

            builder.Entity<Service>()
                .HasOne(x => x.ServiceStatus)
                .WithMany(x => x.Services)
                .OnDelete(DeleteBehavior.SetNull);

            //----------------------End entities configuration
        }

        public DbSet<Activity> Activities { get; set; }
        public DbSet<Commentary> Commentaries { get; set; }
        public DbSet<ConversationTopic> ConversationTopics { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<Notification> Notifications { get; set; }
        public DbSet<NotificationType> NotificationTypes { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<TypePayment> TypePayments { get; set; }
        public DbSet<ResidenceData> ResidenceDatas { get; set; }
        public DbSet<Service> ServicesT { get; set; }
        public DbSet<ServiceStatus> ServiceStatuses { get; set; }

    }
}
