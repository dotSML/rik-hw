using api.Application.DTOs;

namespace api.Domain.Services
{
    public interface IPaymentMethodService
    {
        public Task<IEnumerable<PaymentMethodDto>> GetAllAsync();
    }
}
