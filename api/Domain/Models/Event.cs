
using api.Domain.Models;

public class Event
    {
        public Guid? EventId { get; private set; }
        public string Name { get; private set; }
        public DateTime Date { get; private set; }
        public string Location { get; private set; }
        public string AdditionalInfo { get; private set; }

        public ICollection<Attendee> Attendees { get; private set; } = new List<Attendee>();


    public Event() { }
        public Event(string name, DateTime date, string location, string additionalInfo, Guid? id)
        {
            if (date <= DateTime.UtcNow)
                throw new ArgumentException("The event date must be in the future.");

            EventId = id ?? Guid.NewGuid();
            Name = name;
            Date = date;
            Location = location;
            AdditionalInfo = additionalInfo;
        }

        public void UpdateEvent(string name, DateTime date, string location, string additionalInfo)
        {
            ValidateDate(date);

            Name = name;
            Date = date;
            Location = location;
            AdditionalInfo = additionalInfo;
        }

        private void ValidateDate(DateTime date)
        {
            if (date <= DateTime.UtcNow)
                throw new ArgumentException($"The event date must be in the future. sdfsdfsdf {date}");
        }


    }
