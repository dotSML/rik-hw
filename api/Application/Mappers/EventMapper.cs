using api.Application.DTOs;
using api.Domain.Entities;

namespace api.Application.Mappers
{
    public static class EventMapper
    {
        public static Event ToEvent(this CreateEventDto dto)
        {
            return new Event(dto.Name, dto.Date, dto.Location, dto.AdditionalInfo);
        }
    }
}
