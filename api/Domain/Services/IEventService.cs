using api.Application.DTOs;

namespace api.Domain.Services
{
    public interface IEventService
    {
        Task<Guid> CreateEventAsync(CreateEventDto dto);
        Task<IEnumerable<EventDto>> GetAllEventsAsync();
        Task<EventDto?> GetEventByIdAsync(Guid eventId);
        Task<bool> EventExistsAsync(Guid eventId);
    }
}