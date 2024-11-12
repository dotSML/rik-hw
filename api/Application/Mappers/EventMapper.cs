using api.Application.DTOs;
using api.Domain.Models;

namespace api.Application.Mappers
{
    public static class EventMapper
    {
        public static Event ToEntity(this EventDto dto)
        {
            return new Event(dto.Name, DateTime.SpecifyKind(dto.Date, DateTimeKind.Utc), dto.Location, dto.AdditionalInfo, dto.Id);
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
