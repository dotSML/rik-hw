﻿using api.Application.Interfaces;
using api.Domain.Entities;

public interface IAttendeeRepository
{
    Task<Attendee> GetByIdAsync(Guid attendeeId);
    Task<IEnumerable<Attendee>> GetAllAsync();
    Task<IEnumerable<Attendee>> GetByEventIdAsync(Guid eventId);
    Task<Attendee> AddAsync(Attendee attendeeEntity);
    Task UpdateAsync(Attendee attendeeEntity);
    Task DeleteAsync(Guid attendeeId);
}
