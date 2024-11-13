using api.Domain.Models;
using api.Domain.Repositories;
using api.Infrastructure;
using api.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;

namespace api.Infrastructure.Repositories
{
    public class EventRepository : IEventRepository
    {
        private readonly AppDbContext _context;


        public EventRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Event> GetByIdAsync(Guid eventId)
        {
            var eventEntity = await _context.Events
                .FirstOrDefaultAsync(e => e.Id == eventId);

            return MapToDomainModel(eventEntity);
        }

        public async Task<IEnumerable<Event>> GetAllAsync(string? status)
        {
            var query = _context.Events
                .Include(e => e.Attendees)
                .AsQueryable();

            if (status == "upcoming")
            {
                query = query.Where(e => e.Date >= DateTime.Today); 
            }
            else if (status == "past")
            {
                query = query.Where(e => e.Date < DateTime.Today);
            }

            var eventEntities = await query.ToListAsync();
            return eventEntities.Select(e => MapToDomainModel(e));
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

        public static EventEntity MapToEntity(Event eventDomainModel)
        {
            return new EventEntity(eventDomainModel.Name, eventDomainModel.Date, eventDomainModel.Location, eventDomainModel.AdditionalInfo);
        }

        public static Event MapToDomainModel(EventEntity eventEntity)
        {
            var eventDomainModel = new Event(eventEntity.Name, eventEntity.Date, eventEntity.Location, eventEntity.AdditionalInfo, eventEntity.Id);
            return eventDomainModel;
        }
    }
}