using api.Application.DTOs;
using api.Application.Helpers;
using api.Application.Interfaces;
using api.Domain.Models;
using api.Domain.Services;
using Xunit.Sdk;

public class AttendeeService : IAttendeeService
{
    private readonly IAttendeeRepository _attendeeRepository;
    private readonly IEventService _eventService;

    public AttendeeService(IAttendeeRepository attendeeRepository, IEventService eventService)
    {
        _attendeeRepository = attendeeRepository;
        _eventService = eventService;
    }

    public async Task<Guid> CreateAttendeeAsync(CreateAttendeeDto dto)
    {
        var newAttendee = dto.ToModelFromDto();

        var createdAttendee = await _attendeeRepository.AddAsync(newAttendee);


        if (createdAttendee.AttendeeId == Guid.Empty)
        {
            throw new Exception("Failed to create attendee");
        }

        return createdAttendee.AttendeeId ?? Guid.Empty;
    }


    public async Task<IEnumerable<AttendeeDto>> GetAttendeesForEventAsync(Guid eventId)
    {
        try
        {
            var eventDto = await _eventService.GetEventByIdAsync(eventId);

            AssertionHelper.AssertExistsAndOfType<EventDto>(eventDto);

            var attendees = await _attendeeRepository.GetByEventIdAsync(eventId);

            return attendees.Select(a => a.ToDto());
        }
        catch
        {
            return null;
        }
    }


    public async Task<AttendeeDto> GetByIdAsync(Guid attendeeId)
    {
        var attendee = await _attendeeRepository.GetByIdAsync(attendeeId);

        AssertionHelper.AssertExistsAndOfType<Attendee>(attendee);

        return attendee.ToDto();
    }

    public async Task<AttendeeDto> UpdateByIdAsync(Guid attendeeId, UpdateAttendeeDto dto)
    {
        var attendee = await _attendeeRepository.GetByIdAsync(attendeeId);

        AssertionHelper.AssertExistsAndOfType<Attendee>(attendee);


        await _attendeeRepository.UpdateAsync(dto.MergeUpdateDtoIntoEntity(attendee));

        return attendee.ToDto();
    }


    public async Task<Boolean> DeleteByIdAsync(Guid id)
    {
        return await _attendeeRepository.DeleteAsync(id);
    }
}