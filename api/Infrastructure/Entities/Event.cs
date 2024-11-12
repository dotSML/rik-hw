namespace api.Infrastructure.Entities
{
    public class EventEntity
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public DateTime Date { get; private set; }
        public string Location { get; private set; }
        public string AdditionalInfo { get; private set; }

        public ICollection<AttendeeEntity> Attendees { get; set; } = new List<AttendeeEntity>();

        public EventEntity() { }
        public EventEntity(string name, DateTime date, string location, string additionalInfo)
        {
            Id = Guid.NewGuid();
            Name = name;
            Date = date;
            Location = location;
            AdditionalInfo = additionalInfo;
        }
    }
}