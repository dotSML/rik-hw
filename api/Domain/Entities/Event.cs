﻿namespace api.Domain.Entities
{
    public class Event
    {
        public Guid EventId { get; private set; }
        public string Name { get; private set; }
        public DateTime Date { get; private set; }
        public string Location { get; private set; }
        public string AdditionalInfo { get; private set; }
        public List<Attendee> Attendees { get; private set; }

        public Event(string name, DateTime date, string location, string additionalInfo)
        {
            if (date <= DateTime.Now)
                throw new ArgumentException("The event date must be in the future.");

            EventId = Guid.NewGuid();
            Name = name;
            Date = date;
            Location = location;
            AdditionalInfo = additionalInfo;
            Attendees = new List<Attendee>();
        }

        // Business method to add an attendee to the event
        public void AddAttendee(Attendee attendee)
        {
            Attendees.Add(attendee);
        }

        // Method to update event details
        public void UpdateEvent(string name, DateTime date, string location, string additionalInfo)
        {
            if (date <= DateTime.Now)
                throw new ArgumentException("The event date must be in the future.");

            Name = name;
            Date = date;
            Location = location;
            AdditionalInfo = additionalInfo;
        }

        // Method to remove an attendee
        public void RemoveAttendee(Attendee attendee)
        {
            Attendees.Remove(attendee);
        }
    }
}