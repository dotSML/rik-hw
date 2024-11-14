using api.Domain.Services;
using Microsoft.AspNetCore.Mvc;

namespace api.API.Controllers
{
    [ApiController]
    [Route("api/payment-methods")]
    public class PaymentMethodController: ControllerBase
    {
        private readonly IPaymentMethodService _paymentMethodService;
        public PaymentMethodController(IPaymentMethodService paymentMethodService)
        {
            _paymentMethodService = paymentMethodService;
        }



        [HttpGet]
        public async Task<IActionResult> GetAllPaymentMethods()
        {
            var paymentMethods = await _paymentMethodService.GetAllAsync();
            return paymentMethods != null ? Ok(paymentMethods) : NotFound();
        }

        
    }
}
