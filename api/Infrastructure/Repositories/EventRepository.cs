using api.Domain.Models;
using api.Domain.Repositories;
using api.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;

public class EventRepository : IEventRepository
{
    private readonly AppDbContext _context;


    public EventRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<Event> GetByIdAsync(Guid eventId)
    {
        return await _context.Events
            .Include(e => e.Attendees).Select(e => MapToDomainModel(e))
            .FirstOrDefaultAsync(e => e.EventId == eventId);
    }

    public async Task<IEnumerable<Event>> GetAllAsync()
    {
        return await _context.Events
            .Include(e => e.Attendees).Select(e => MapToDomainModel(e))
            .ToListAsync();
    }

    public async Task<IEnumerable<Event>> GetUpcomingEventsAsync()
    {
        return await _context.Events
            .Include(e => e.Attendees).Select(e => MapToDomainModel(e))
            .Where(e => e.Date > DateTime.Now)
            .ToListAsync();
    }

    public async Task<IEnumerable<Event>> GetPastEventsAsync()
    {
        return await _context.Events
            .Include(e => e.Attendees).Select(e => MapToDomainModel(e))
            .Where(e => e.Date <= DateTime.Now)
            .ToListAsync();
    }

    public async Task AddAsync(Event eventEntity)
    {
        var entity = MapToEntity(eventEntity);
        await _context.Events.AddAsync(entity);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Event eventEntity)
    {
        var entity = MapToEntity(eventEntity);
        _context.Events.Update(entity);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Guid eventEntityId)
    {
        var eventModel = await GetByIdAsync(eventEntityId);
        if (eventModel != null)
        {
            var entity = MapToEntity(eventModel);
            _context.Events.Remove(entity);
            await _context.SaveChangesAsync();
        }
    }

    private EventEntity MapToEntity(Event eventDomainModel)
    {
        return new EventEntity(eventDomainModel.Name, eventDomainModel.Date, eventDomainModel.Location, eventDomainModel.AdditionalInfo);
    }

    private Event MapToDomainModel(EventEntity eventEntity)
    {
        var eventDomainModel = new Event(eventEntity.Name, eventEntity.Date, eventEntity.Location, eventEntity.AdditionalInfo, eventEntity.Id);
        return eventDomainModel;
    }
}
