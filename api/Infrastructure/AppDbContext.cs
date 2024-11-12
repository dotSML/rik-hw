using api.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;

namespace api.Infrastructure
{
    public class AppDbContext : DbContext
    {
        public DbSet<EventEntity> Events { get; set; }
        public DbSet<AttendeeEntity> Attendees { get; set; }
        public DbSet<PaymentMethodEntity> PaymentMethods { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<AttendeeEntity>().UseTphMappingStrategy().HasDiscriminator<string>("AttendeeType")
                .HasValue<NaturalPersonAttendeeEntity>("NaturalPerson")
                .HasValue<LegalEntityAttendeeEntity>("LegalEntity");

            modelBuilder.Entity<AttendeeEntity>()
                .HasOne(a => a.Event)
                .WithMany()
                .HasForeignKey(a => a.EventId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<AttendeeEntity>()
            .HasOne(a => a.PaymentMethod)
            .WithMany()
            .HasForeignKey(a => a.PaymentMethodId)
            .OnDelete(DeleteBehavior.Restrict);



            modelBuilder.Entity<NaturalPersonAttendeeEntity>()
                .Property(np => np.PersonalIdCode)
                .IsRequired();

            modelBuilder.Entity<LegalEntityAttendeeEntity>()
                .Property(le => le.CompanyName)
                .IsRequired();

            modelBuilder.Entity<PaymentMethodEntity>().HasData(
                new PaymentMethodEntity { Id = Guid.NewGuid(), Method = "Bank transfer" },
                new PaymentMethodEntity { Id = Guid.NewGuid(), Method = "Cash" });
        }
    }
}