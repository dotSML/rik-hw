using System.ComponentModel.DataAnnotations;

namespace api.Application.DTOs
{
    public class CreateEventDto
    {
        public string Name { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        public string Location { get; set; }
        public string? AdditionalInfo { get; set; }
    }
}