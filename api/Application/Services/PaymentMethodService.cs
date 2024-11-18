using api.Application.DTOs;
using api.Application.Mappers;
using api.Domain.Repositories;
using api.Domain.Services;

namespace api.Application.Services
{
    public class PaymentMethodService : IPaymentMethodService
    {
        private readonly IPaymentMethodRepository _paymentMethodRepository;

        public PaymentMethodService(IPaymentMethodRepository paymentMethodRepository)
        {
            _paymentMethodRepository = paymentMethodRepository;
        }
        public async Task<IEnumerable<PaymentMethodDto>> GetAllAsync()
        {
            var paymentMethods = await _paymentMethodRepository.GetPaymentMethodsAsync();
            return paymentMethods.Select(pm => pm.MapToDto()).ToList();
        }
    }
}