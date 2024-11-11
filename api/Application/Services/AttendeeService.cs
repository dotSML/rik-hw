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

    public async Task<Guid> CreateAttendeeAsync(Guid eventId, CreateAttendeeDto dto)
    {
        if (!await _eventService.EventExistsAsync(eventId))
        {
            throw new ArgumentException("Event does not exist", nameof(eventId));
        }

        var newAttendee = await _attendeeRepository.AddAsync(dto.ToAttendeeFromCreate());

        await _eventService.AddAttendeeToEventAsync(eventId, newAttendee.AttendeeId);

        return newAttendee.AttendeeId;
    }

    public async Task<IEnumerable<AttendeeDto>> GetAttendeesForEventAsync(Guid eventId)
    {
        var eventEntity = await _eventService.GetEventByIdAsync(eventId);

        if (eventEntity == null)
        {
            throw new ArgumentException("Event does not exist", nameof(eventId));
        }
        
        var attendees = await _attendeeRepository.GetByEventIdAsync(eventId);

        return attendees.Select(a => a.ToDto());
    }


    public async Task<AttendeeDto> GetByIdAsync(Guid attendeeId)
    {
        var attendee = await _attendeeRepository.GetByIdAsync(attendeeId);

        if (attendee == null)
        {
            throw new ArgumentException("Attendee does not exist", nameof(attendeeId));

        }

        return attendee.ToDto();
    }

    

}
