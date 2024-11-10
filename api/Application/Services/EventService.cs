﻿using api.Application.DTOs;
using api.Domain.Entities;
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

        public async Task<IEnumerable<Attendee>> GetAttendeesForEventAsync(Guid eventId)
        {
            var eventEntity = await _eventRepository.GetByIdAsync(eventId);
            return eventEntity.EventAttendees.Select(e => e.Attendee).ToList();
        }

        public async Task<Guid> CreateEventAsync(CreateEventDto dto)
        {
            var newEvent = new Event(dto.Name, dto.Date, dto.Location, dto.AdditionalInfo);
            await _eventRepository.AddAsync(newEvent);
            return newEvent.EventId;
        }

        public async Task<EventDto> GetEventByIdAsync(Guid eventId)
        {
            var eventEntity = await _eventRepository.GetByIdAsync(eventId);
            return new EventDto(eventEntity);
        }

        public async Task<IEnumerable<EventDto>> GetAllEventsAsync()
        {
            var events = await _eventRepository.GetAllAsync();
            return events.Select(e => new EventDto(e)).ToList();
        }

        public async Task AddAttendeeToEventAsync(Guid eventId, Attendee attendee)
        {
            // Retrieve the event from the repository
            var @event = await _eventRepository.GetByIdAsync(eventId);
    if (@event == null)
    {
            throw new ArgumentException("Event does not exist", nameof(eventId));
        }

    // Add the attendee to the event
    @event.AddAttendee(attendee);

    // Save changes to the repositorys
    await _eventRepository.UpdateAsync(@event);
        }

        public async Task<bool> EventExistsAsync(Guid eventId)
        {
            var eventEntity = await _eventRepository.GetByIdAsync(eventId);
            return eventEntity != null;
        }
    }
}