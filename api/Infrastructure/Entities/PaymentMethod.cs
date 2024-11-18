namespace api.Infrastructure.Entities
{
    public class PaymentMethodEntity
    {
        public Guid Id { get; set; }
        public string Method { get; set; } = string.Empty;
    }


}