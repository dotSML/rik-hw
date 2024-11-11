using api.Domain.Entities;
using api.Domain.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

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
        var attendeeTypeConverter = new ValueConverter<AttendeeType, string>(
        v => v.ToString(), // Convert AttendeeType to string for storage
        v => (AttendeeType)Enum.Parse(typeof(AttendeeType), v) // Convert string back to AttendeeType
    );


        modelBuilder.Entity<Attendee>()
            .HasDiscriminator<AttendeeType>("AttendeeType")
            .HasValue<NaturalPersonAttendee>(AttendeeType.NaturalPerson)
            .HasValue<LegalEntityAttendee>(AttendeeType.LegalEntity);

        modelBuilder.Entity<Attendee>()
            .Property("AttendeeType")
            .HasConversion<string>();

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
