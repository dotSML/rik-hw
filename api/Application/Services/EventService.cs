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
            var newEvent = dto.ToModel();
            await _eventRepository.AddAsync(newEvent);
            return newEvent.EventId;
        }

        public async Task<EventDto?> GetEventByIdAsync(Guid eventId)
        {
            var eventEntity = await _eventRepository.GetByIdAsync(eventId);

            return eventEntity != null ? eventEntity.ToDto() : null;
        }

        public async Task<IEnumerable<EventDto>> GetAllEventsAsync(string? status)
        {
            var events = await _eventRepository.GetAllAsync(status);
            return events.Select(e => e.ToDto()).ToList();
        }

        public async Task<Boolean> EventExistsAsync(Guid eventId)
        {
            var eventEntity = await _eventRepository.GetByIdAsync(eventId);
            return eventEntity != null;
        }

        public Task<Boolean> DeleteEventByIdAsync(Guid eventId)
        {
            return _eventRepository.DeleteByIdAsync(eventId);
        }
    }

}