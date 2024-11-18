using api.Application.DTOs;
using api.Domain.Models;

namespace api.Application.Mappers
{
    public static class EventMapper
    {
        public static Event ToModel(this EventDto dto)
        {
            return new Event(dto.Name, DateTime.SpecifyKind(dto.Date, DateTimeKind.Utc), dto.Location, dto.AdditionalInfo, dto.Id);
        }


        public static Event ToModel(this CreateEventDto dto)
        {
            return new Event(dto.Name, DateTime.SpecifyKind(dto.Date, DateTimeKind.Utc), dto.Location, dto.AdditionalInfo, null);
        }


        public static EventDto ToDto(this Event entity)
        {
            return new EventDto
            {
                Id = entity.EventId,
                Name = entity.Name,
                Date = DateTime.SpecifyKind(entity.Date, DateTimeKind.Utc),
                Location = entity.Location,
                AdditionalInfo = entity.AdditionalInfo,
            };
        }
    }
}