using api.Domain.Models;

public interface IAttendeeRepository
{
    Task<Attendee> GetByIdAsync(Guid attendeeId);
    Task<IEnumerable<Attendee>> GetAllAsync();
    Task<IEnumerable<Attendee>> GetByEventIdAsync(Guid eventId);
    Task<Attendee> UpdateAsync(Attendee attendee);
    Task<Attendee> AddAsync(Attendee attendeeEntity);
    Task<Boolean> DeleteAsync(Guid attendeeId);
}