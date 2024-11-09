using api.Domain.Entities;

public interface IAttendeeRepository
{
    Task<Attendee> GetByIdAsync(Guid attendeeId);
    Task<IEnumerable<Attendee>> GetAllAsync();
    Task<IEnumerable<Attendee>> GetByEventIdAsync(Guid eventId);
    Task AddAsync(Attendee attendee);
    Task UpdateAsync(Attendee attendee);
    Task DeleteAsync(Guid attendeeId);
}
