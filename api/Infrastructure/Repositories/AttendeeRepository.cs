using api.Domain.Entities;
using Microsoft.EntityFrameworkCore;

public class AttendeeRepository : IAttendeeRepository
{
    private readonly AppDbContext _context;

    public AttendeeRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<Attendee> GetByIdAsync(Guid attendeeId)
    {
        return await _context.Attendees.Include(e => e.EventAttendees).SingleOrDefaultAsync(x => x.AttendeeId == attendeeId);
    }

    public async Task<IEnumerable<Attendee>> GetAllAsync()
    {
        return await _context.Attendees.ToListAsync();
    }

    public async Task<IEnumerable<Attendee>> GetByEventIdAsync(Guid eventId)
    {
        return await _context.Attendees
            .Where(a => a.EventAttendees.Any(e => e.EventId == eventId))
            .ToListAsync();
    }

    public async Task<Attendee> AddAsync(Attendee attendee)
    {
        var addedAttendee = await _context.Attendees.AddAsync(attendee);
        await _context.SaveChangesAsync();

        return addedAttendee.Entity;
    }

    public async Task UpdateAsync(Attendee attendee)
    {
        _context.Attendees.Update(attendee);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Guid attendeeId)
    {
        var attendee = await GetByIdAsync(attendeeId);
        if (attendee != null)
        {
            _context.Attendees.Remove(attendee);
            await _context.SaveChangesAsync();
        }
    }
}
