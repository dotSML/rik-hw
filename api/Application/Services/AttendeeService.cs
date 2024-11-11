using api.Application.DTOs;
using api.Application.Helpers;
using api.Application.Interfaces;
using api.Domain.Entities;
using api.Domain.Services;

public class AttendeeService : IAttendeeService
{
    private readonly IAttendeeRepository _attendeeRepository;
    private readonly IEventService _eventService;
    private readonly IUnitOfWork _unitOfWork;

    public AttendeeService(IUnitOfWork unitOfWork, IAttendeeRepository attendeeRepository, IEventService eventService)
    {
        _attendeeRepository = attendeeRepository;
        _eventService = eventService;
       _unitOfWork = unitOfWork;
    }

    public async Task<Guid> CreateAttendeeAsync(Guid eventId, CreateAttendeeDto dto)
    {
        await _eventService.EventExistsAsync(eventId);

        await _unitOfWork.BeginTransactionAsync();

        try
        {
            var newAttendee = await _attendeeRepository.AddAsync(dto.ToAttendeeFromCreate());

            await _eventService.AddAttendeeToEventAsync(eventId, newAttendee.AttendeeId);

            await _unitOfWork.CommitTransactionAsync();

            return newAttendee.AttendeeId;
        }
        catch(Exception e)
        {
            await _unitOfWork.RollbackTransactionAsync();
            throw;
        }
    }


    public async Task<IEnumerable<AttendeeDto>?> GetAttendeesForEventAsync(Guid eventId)
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



}
