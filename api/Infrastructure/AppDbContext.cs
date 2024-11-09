using api.Domain.Entities;
using Microsoft.EntityFrameworkCore;

public class AppDbContext : DbContext
{
    public DbSet<Event> Events { get; set; }
    public DbSet<Attendee> Attendees { get; set; }

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Attendee>()
                .HasDiscriminator<string>("AttendeeType")
                .HasValue<NaturalPersonAttendee>("NaturalPerson")
                .HasValue<LegalEntityAttendee>("LegalEntity");

        modelBuilder.Entity<Attendee>()
            .Property("AttendeeType")
            .HasMaxLength(50);

        modelBuilder.Entity<Attendee>()
            .OwnsOne(a => a.PaymentMethod);

        base.OnModelCreating(modelBuilder);
    }
}
