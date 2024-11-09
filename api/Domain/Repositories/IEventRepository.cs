using api.Domain.Entities;

public interface IEventRepository
{
    Task<Event> GetByIdAsync(Guid eventId);
    Task<IEnumerable<Event>> GetAllAsync();
    Task<IEnumerable<Event>> GetUpcomingEventsAsync();
    Task<IEnumerable<Event>> GetPastEventsAsync();
    Task AddAsync(Event event);
    Task UpdateAsync(Event event);
    Task DeleteAsync(Guid eventId);
}
