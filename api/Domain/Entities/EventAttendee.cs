namespace api.Domain.Entities
{
    public class EventAttendee
    {
        public Guid EventId { get; private set; }
        public Event Event { get; private set; }
        public Guid AttendeeId { get; private set; }
        public Attendee Attendee { get; private set; }

        public DateTime RegistrationDate { get; private set; }

        private EventAttendee() { }

        public EventAttendee(Guid eventId, Guid attendeeId)
        {
            EventId = eventId;
            AttendeeId = attendeeId;
            RegistrationDate = DateTime.UtcNow;
        }
    }
}
