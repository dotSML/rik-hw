using api.Domain.Models;

namespace api.Domain.Repositories
{
    public interface IPaymentMethodRepository
    {
        Task<IEnumerable<PaymentMethod>> GetPaymentMethodsAsync();
    }
}
