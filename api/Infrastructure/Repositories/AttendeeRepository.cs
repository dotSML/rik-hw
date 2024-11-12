using api.Domain.Models;
using api.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;

namespace api.Infrastructure.Repositories
{
    public class AttendeeRepository : IAttendeeRepository
    {
        private readonly AppDbContext _context;

        public AttendeeRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Attendee>> GetByEventIdAsync(Guid eventId)
        {
            return await _context.Attendees.Where(x => x.EventId == eventId).Select(a => MapToDomainModel(a)).ToListAsync();
        }

        public async Task<Attendee> GetByIdAsync(Guid attendeeId)
        {
            return MapToDomainModel(await _context.Attendees.SingleOrDefaultAsync(x => x.Id == attendeeId));
        }

        public async Task<IEnumerable<Attendee>> GetAllAsync()
        {
            return await _context.Attendees.Select(a => MapToDomainModel(a)).ToListAsync();
        }

        public async Task<Attendee> AddAsync(Attendee attendee)
        {
            var entity = MapToEntity(attendee);
            var addedAttendee = await _context.Attendees.AddAsync(entity);

            await _context.SaveChangesAsync();
            return MapToDomainModel(addedAttendee.Entity);
        }

        public async Task UpdateAsync(Attendee attendee)
        {
            var entity = MapToEntity(attendee);
            _context.Attendees.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid attendeeId)
        {
            var attendee = await GetByIdAsync(attendeeId);
            if (attendee != null)
            {
                var entity = MapToEntity(attendee);
                _context.Attendees.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }

        public static AttendeeEntity MapToEntity(Attendee attendee)
        {
            return attendee switch
            {
                NaturalPersonAttendee naturalPerson => new NaturalPersonAttendeeEntity(naturalPerson.EventId, naturalPerson.Name, naturalPerson.PersonalIdCode, naturalPerson.PaymentMethodId, naturalPerson.AdditionalInfo),
                LegalEntityAttendee legalEntity => new LegalEntityAttendeeEntity(legalEntity.EventId, legalEntity.CompanyName, legalEntity.CompanyRegistrationCode, legalEntity.AttendeeCount, legalEntity.PaymentMethodId, legalEntity.AdditionalInfo, legalEntity.ParticipantRequests),
                _ => throw new ArgumentException("Unknown attendee type")
            };
        }

        public static Attendee MapToDomainModel(AttendeeEntity attendeeEntity)
        {
            return attendeeEntity switch
            {
                NaturalPersonAttendeeEntity naturalPerson => new NaturalPersonAttendee(naturalPerson.EventId, naturalPerson.Name, naturalPerson.PersonalIdCode, naturalPerson.PaymentMethodId, naturalPerson.AdditionalInfo, naturalPerson.Id),
                LegalEntityAttendeeEntity legalEntity => new LegalEntityAttendee(legalEntity.EventId, legalEntity.CompanyName, legalEntity.CompanyRegistrationCode, legalEntity.AttendeeCount, legalEntity.PaymentMethodId, legalEntity.AdditionalInfo, legalEntity.ParticipantRequests, legalEntity.Id),
                _ => throw new ArgumentException("Unknown attendee type")
            };
        }
    }
}