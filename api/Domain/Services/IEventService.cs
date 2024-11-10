using api.Application.DTOs;
using api.Domain.Entities;

namespace api.Domain.Services
{
    public interface IEventService
    {
        Task<Guid> CreateEventAsync(CreateEventDto dto);
        Task<IEnumerable<EventDto>> GetAllEventsAsync();
        Task<EventDto> GetEventByIdAsync(Guid eventId);

        Task AddAttendeeToEventAsync(Guid eventId, Attendee attendee);
        Task<bool> EventExistsAsync(Guid eventId);
        Task<IEnumerable<Attendee>> GetAttendeesForEventAsync(Guid eventId);
    }
}