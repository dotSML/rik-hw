using api.Domain.Models;

public interface IAttendeeRepository
{
    Task<Attendee> GetByIdAsync(Guid attendeeId);
    Task<IEnumerable<Attendee>> GetAllAsync();
    Task<IEnumerable<Attendee>> GetByEventIdAsync(Guid eventId);
    Task UpdateAsync(Attendee attendeeEntity);
    Task<Attendee> AddAsync(Attendee attendeeEntity);
    Task DeleteAsync(Guid attendeeId);
}
