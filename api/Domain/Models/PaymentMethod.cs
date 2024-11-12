namespace api.Domain.Models
{
    public class PaymentMethod
    {
        public Guid PaymentMethodId { get; set; }
        public string Method { get; set; } = string.Empty;

        public PaymentMethod() { }

        public PaymentMethod(Guid id, string method)
        {
            PaymentMethodId = id;
            Method = method;
        }
    }
}
