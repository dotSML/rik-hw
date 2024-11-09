
using api.Application.DTOs;

public interface IAttendeeService
{
    Task<Guid> CreateAttendeeAsync(Guid eventId, CreateAttendeeDto dto);
    Task<IEnumerable<AttendeeDto>> GetAttendeesForEventAsync(Guid eventId);
    Task<AttendeeDto> GetByIdAsync(Guid attendeeId);
}