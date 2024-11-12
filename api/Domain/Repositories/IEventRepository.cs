using api.Domain.Models;
using api.Infrastructure.Entities;

namespace api.Domain.Repositories
{
    public interface IEventRepository
    {
        Task<Event> GetByIdAsync(Guid eventId);
        Task<IEnumerable<Event>> GetAllAsync();
        Task<IEnumerable<Event>> GetUpcomingEventsAsync();
        Task<IEnumerable<Event>> GetPastEventsAsync();
        Task AddAsync(Event eventEntity);
        Task UpdateAsync(Event eventEntity);
        Task DeleteAsync(Guid eventId);
    }
}