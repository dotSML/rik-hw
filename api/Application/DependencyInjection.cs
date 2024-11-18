using api.Application.Services;
using api.Domain.Services;

namespace api.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IEventService, EventService>();
            services.AddScoped<IAttendeeService, AttendeeService>();
            services.AddScoped<IPaymentMethodService, PaymentMethodService>();


            return services;
        }
    }
}