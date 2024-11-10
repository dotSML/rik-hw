namespace api.Domain.Entities
{
    public class EventAttendee
    {
        public Guid EventId { get; private set; }
        public Event Event { get; private set; }
        public Guid AttendeeId { get; private set; }
        public Attendee Attendee { get; private set; }

        private EventAttendee() { } 

        public EventAttendee(Event @event, Attendee attendee)
        {
        EventId = @event.EventId;
        Event = @event;
        AttendeeId = attendee.AttendeeId;
        Attendee = attendee;
        }
    }
}
