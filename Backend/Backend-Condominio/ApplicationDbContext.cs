using Backend_Condominio.Entities;

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
            builder.Entity<Invoice>().HasKey(x => new { x.UserId, x.ActivityId });
            builder.Entity<Commentary>().HasKey(x => new { x.UserId, x.CoversationTopicId });
            builder.Entity<Notification>().HasKey(x => new { x.UserId, x.NotificationTypeId });
            builder.Entity<Payment>().HasKey(x => new { x.InvoiceId, x.TypePaymentId });
            builder.Entity<ResidenceData>().HasKey(x => new { x.UserId, x.Id });
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
        public DbSet<User> Users { get; set; }

    }
}
