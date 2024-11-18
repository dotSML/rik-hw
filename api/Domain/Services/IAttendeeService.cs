
using api.Application.DTOs;

public interface IAttendeeService
{
    Task<Guid> CreateAttendeeAsync(CreateAttendeeDto createAttendeeDto);
    Task<IEnumerable<AttendeeDto>> GetAttendeesForEventAsync(Guid eventId);
    Task<AttendeeDto> GetByIdAsync(Guid attendeeId);
    Task<AttendeeDto> UpdateByIdAsync(Guid attendeeId, UpdateAttendeeDto updateAttendeeDto);

    Task<Boolean> DeleteByIdAsync(Guid attendeeId);
}