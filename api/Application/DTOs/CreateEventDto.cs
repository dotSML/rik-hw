namespace api.Application.DTOs
{
    public class CreateEventDto:EventDto
    {
        public string Name { get; set; } = string.Empty;
        public DateTime Date { get; set; }
        public string Location { get; set; } = string.Empty;
        public string AdditionalInfo { get; set; } = string.Empty;
    }
}
