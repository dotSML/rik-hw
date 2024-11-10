using api.Domain.Entities;
using Microsoft.EntityFrameworkCore;

public class AppDbContext : DbContext
{
    public DbSet<Event> Events { get; set; }
    public DbSet<Attendee> Attendees { get; set; }
    public DbSet<EventAttendee> EventAttendees { get; set; }

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

        modelBuilder.Entity<EventAttendee>()
    .HasKey(ea => new { ea.EventId, ea.AttendeeId });

        modelBuilder.Entity<EventAttendee>()
            .HasOne(ea => ea.Event)
            .WithMany(e => e.EventAttendees)
            .HasForeignKey(ea => ea.EventId);

        modelBuilder.Entity<EventAttendee>()
            .HasOne(ea => ea.Attendee)
            .WithMany(a => a.EventAttendees)
            .HasForeignKey(ea => ea.AttendeeId);



        base.OnModelCreating(modelBuilder);
    }
}
