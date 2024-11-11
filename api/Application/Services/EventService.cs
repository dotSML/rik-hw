using api.Application.DTOs;
using api.Application.Helpers;
using api.Application.Mappers;
using api.Domain.Repositories;
using api.Domain.Services;

namespace api.Application.Services
{
    public class EventService : IEventService
    {
        private readonly IEventRepository _eventRepository;

        public EventService(IEventRepository eventRepository)
        {
            _eventRepository = eventRepository;
        }

        public async Task<Guid> CreateEventAsync(CreateEventDto dto)
        {
            var newEvent = dto.ToEntity();
            await _eventRepository.AddAsync(newEvent);
            return newEvent.EventId;
        }

        public async Task<EventDto?> GetEventByIdAsync(Guid eventId)
        {
            var eventEntity = await _eventRepository.GetByIdAsync(eventId);

            return eventEntity != null ? eventEntity.ToDto() : null;
        }

        public async Task<IEnumerable<EventDto>> GetAllEventsAsync()
        {
            var events = await _eventRepository.GetAllAsync();
            return events.Select(e => e.ToDto()).ToList();
        }

        public async Task AddAttendeeToEventAsync(Guid eventId, Guid attendeeId)
        {
            var eventDto = await GetEventByIdAsync(eventId);

            var validatedEventDto = AssertionHelper.AssertExistsAndOfType<EventDto>(eventDto);

            var eventEntity = validatedEventDto.ToEntity();

            eventEntity?.AddAttendee(attendeeId);


            await _eventRepository.UpdateAsync(eventEntity);
        }

        public async Task<bool> EventExistsAsync(Guid eventId)
        {
            var eventEntity = await _eventRepository.GetByIdAsync(eventId);
            return eventEntity != null;
        }
    }

}