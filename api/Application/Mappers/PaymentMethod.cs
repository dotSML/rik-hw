using api.Application.DTOs;
using api.Domain.Models;

namespace api.Application.Mappers
{
    public static class PaymentMethodMapper
    {
        public static PaymentMethodDto MapToDto(this PaymentMethod paymentMethod)
        {
            return new PaymentMethodDto
            {
                Id = paymentMethod.PaymentMethodId,
                Method = paymentMethod.Method
            };
        }
    }
}
