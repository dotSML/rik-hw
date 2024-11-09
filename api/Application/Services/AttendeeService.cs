using api.Application.DTOs;
using api.Domain.Entities;
using api.Domain.Services;

public class AttendeeService : IAttendeeService
{
    private readonly IAttendeeRepository _attendeeRepository;
    private readonly IEventService _eventService;

    public AttendeeService(IAttendeeRepository attendeeRepository, IEventService eventService)
    {
        _attendeeRepository = attendeeRepository;
        _eventService = eventService;
    }

    // Create a new attendee for a given event
    public async Task<Guid> CreateAttendeeAsync(Guid eventId, CreateAttendeeDto dto)
    {
        // Check if the event exists using EventService
        if (!await _eventService.EventExistsAsync(eventId))
        {
            throw new ArgumentException("Event does not exist", nameof(eventId));
        }
        
        

        await _attendeeRepository.AddAsync(attendee);
        return attendee.AttendeeId;
    }

    // Retrieve all attendees for a specific event (optional if already handled in EventService)
    public async Task<IEnumerable<AttendeeDto>> GetAttendeesForEventAsync(Guid eventId)
    {
        if (!await _eventService.EventExistsAsync(eventId))
        {
            throw new ArgumentException("Event does not exist", nameof(eventId));
        }

        var attendees = await _eventService.GetAttendeesForEventAsync(eventId);
        return attendees.Select(a => new AttendeeDto(a)).ToList();
    }

    public async Task<AttendeeDto> GetByIdAsync(Guid attendeeId)
    {
        var attendee = await _attendeeRepository.GetByIdAsync(attendeeId);
        return attendee == null ? null : new AttendeeDto(attendee);
    }
}
