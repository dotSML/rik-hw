using api.Domain.Entities;
using api.Domain.Repositories;
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
            .Include(e => e.EventAttendees).ThenInclude(e => e.Attendee)
            .FirstOrDefaultAsync(e => e.EventId == eventId);
    }

    public async Task<IEnumerable<Event>> GetAllAsync()
    {
        return await _context.Events
            .Include(e => e.EventAttendees)
            .ToListAsync();
    }

    public async Task<IEnumerable<Event>> GetUpcomingEventsAsync()
    {
        return await _context.Events
            .Include(e => e.EventAttendees)
            .Where(e => e.Date > DateTime.Now)
            .ToListAsync();
    }

    public async Task<IEnumerable<Event>> GetPastEventsAsync()
    {
        return await _context.Events
            .Include(e => e.EventAttendees)
            .Where(e => e.Date <= DateTime.Now)
            .ToListAsync();
    }

    public async Task AddAsync(Event eventEntity)
    {
        await _context.Events.AddAsync(eventEntity);
    await _context.SaveChangesAsync();
    }

public async Task UpdateAsync(Event eventEntity)
{
    _context.Events.Update(eventEntity);
    await _context.SaveChangesAsync();
}

public async Task DeleteAsync(Guid eventEntityId)
{
    var eventEntityEntity = await GetByIdAsync(eventEntityId);
    if (eventEntityEntity != null)
        {
        _context.Events.Remove(eventEntityEntity);
        await _context.SaveChangesAsync();
    }
}
}
