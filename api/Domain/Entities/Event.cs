namespace api.Domain.Entities
{
    public class Event
    {
        public Guid EventId { get; private set; }
        public string Name { get; private set; }
        public DateTime Date { get; private set; }
        public string Location { get; private set; }
        public string AdditionalInfo { get; private set; }
        private readonly List<EventAttendee> _eventAttendees = new List<EventAttendee>();
        public IReadOnlyCollection<EventAttendee> EventAttendees => _eventAttendees.AsReadOnly();

        public Event(string name, DateTime date, string location, string additionalInfo)
        {
            if (date <= DateTime.Now)
                throw new ArgumentException("The event date must be in the future.");

            EventId = Guid.NewGuid();
            Name = name;
            Date = date;
            Location = location;
            AdditionalInfo = additionalInfo;
        }

        public void AddAttendee(Guid attendeeId)
        {
            var eventAttendee = new EventAttendee(this.EventId, attendeeId);
            _eventAttendees.Add(eventAttendee);
        }

        public void RemoveAttendee(Attendee attendee)
        {
            _eventAttendees.RemoveAll(ea => ea.AttendeeId == attendee.AttendeeId);
        }

        public void UpdateEvent(string name, DateTime date, string location, string additionalInfo)
        {
            if (date <= DateTime.Now)
                throw new ArgumentException("The event date must be in the future.");

            Name = name;
            Date = date;
            Location = location;
            AdditionalInfo = additionalInfo;
        }

        
    }
}