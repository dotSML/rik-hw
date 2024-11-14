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
            var attendees = await _context.Attendees.Where(x => x.EventId == eventId).Include(x => x.Event).Include(x => x.PaymentMethod).ToListAsync();
            return attendees.Select(a => MapToDomainModel(a));
        }

        public async Task<Attendee> GetByIdAsync(Guid attendeeId)
        {
            return MapToDomainModel(await _context.Attendees.Include(x => x.Event).Include(x => x.PaymentMethod).SingleOrDefaultAsync(x => x.Id == attendeeId));
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
                NaturalPersonAttendee naturalPerson => new NaturalPersonAttendeeEntity(naturalPerson.EventId, naturalPerson.FirstName, naturalPerson.LastName, naturalPerson.PersonalIdCode, naturalPerson.PaymentMethodId, naturalPerson.AdditionalInfo, naturalPerson.AttendeeId, naturalPerson.Event != null ? EventRepository.MapToEntity(naturalPerson.Event) : null,naturalPerson.PaymentMethod != null ? PaymentMethodRepository.MapToEntity(naturalPerson.PaymentMethod) : null),
                LegalEntityAttendee legalEntity => new LegalEntityAttendeeEntity(legalEntity.EventId, legalEntity.LegalName, legalEntity.CompanyRegistrationCode, legalEntity.AttendeeCount, legalEntity.PaymentMethodId, legalEntity.AdditionalInfo, legalEntity.ParticipantRequests, legalEntity.AttendeeId, legalEntity.Event != null ? EventRepository.MapToEntity(legalEntity.Event) : null, legalEntity.PaymentMethod != null ? PaymentMethodRepository.MapToEntity(legalEntity.PaymentMethod) : null),
                _ => throw new ArgumentException("Unknown attendee type")
            };
        }

        public static Attendee MapToDomainModel(AttendeeEntity attendeeEntity)
        {
            return attendeeEntity switch
            {
                NaturalPersonAttendeeEntity naturalPerson => new NaturalPersonAttendee(naturalPerson.EventId, naturalPerson.FirstName, naturalPerson.LastName, naturalPerson.PersonalIdCode, naturalPerson.PaymentMethodId, naturalPerson.AdditionalInfo, naturalPerson.Id, naturalPerson.Event != null ? EventRepository.MapToDomainModel(naturalPerson.Event) : null, naturalPerson.PaymentMethod != null ? PaymentMethodRepository.MapToDomainModel(naturalPerson.PaymentMethod) : null),
                LegalEntityAttendeeEntity legalEntity => new LegalEntityAttendee(legalEntity.EventId, legalEntity.LegalName, legalEntity.CompanyRegistrationCode, legalEntity.AttendeeCount, legalEntity.PaymentMethodId, legalEntity.AdditionalInfo, legalEntity.ParticipantRequests, legalEntity.Id, legalEntity.Event != null ? EventRepository.MapToDomainModel(legalEntity.Event) : null, legalEntity.PaymentMethod != null ? PaymentMethodRepository.MapToDomainModel(legalEntity.PaymentMethod) : null),
                _ => throw new ArgumentException("Unknown attendee type")
            };
        }
    }
}