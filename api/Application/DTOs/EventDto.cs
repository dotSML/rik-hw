using api.Domain.Models;
using System.ComponentModel.DataAnnotations;

namespace api.Application.DTOs
{
    public class EventDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }
        public string Location { get; set; }
        public string? AdditionalInfo { get; set; }

        public EventDto()
        {
        }

        public EventDto(Event eventEntity)
        {
            Name = eventEntity.Name;
            Date = eventEntity.Date;
            Location = eventEntity.Location;
            AdditionalInfo = eventEntity.AdditionalInfo;
        }
    }
}
