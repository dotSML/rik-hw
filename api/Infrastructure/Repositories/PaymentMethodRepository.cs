using api.Domain.Models;
using api.Domain.Repositories;
using api.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;
using System.Net.NetworkInformation;

namespace api.Infrastructure.Repositories
{
    public class PaymentMethodRepository : IPaymentMethodRepository
    {
        private readonly AppDbContext _context;
        public PaymentMethodRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<PaymentMethod>> GetPaymentMethodsAsync()
        {
            return await _context.PaymentMethods.Select(p => MapToDomainModel(p)).ToListAsync();
        }


        public static PaymentMethod MapToDomainModel(PaymentMethodEntity paymentMethodEntity)
        {
            return new PaymentMethod
            {
                PaymentMethodId = paymentMethodEntity.Id,
                Method = paymentMethodEntity.Method,
            };
        }

        public static PaymentMethodEntity MapToEntity(PaymentMethod paymentMethod)
        {
            return new PaymentMethodEntity
            {
                Id = paymentMethod.PaymentMethodId,
                Method = paymentMethod.Method,
            };

        }
    }
}
