
using api.Application.DTOs;
using api.Domain.Entities;

public interface IAttendeeService
{
    Task<Guid> CreateAttendeeAsync(Guid eventId, Attendee attendee);
    Task<IEnumerable<AttendeeDto>> GetAttendeesForEventAsync(Guid eventId);
    Task<AttendeeDto> GetByIdAsync(Guid attendeeId);
}