namespace api.Domain.ValueObjects
{
    public class PaymentMethod
    {
        public PaymentMethod() { }
        public string Method { get; private set; } = string.Empty;

        private static readonly List<string> ValidMethods = new List<string> { "BankTransfer", "Cash" };

        public PaymentMethod(string method)
        {
            if (!ValidMethods.Contains(method))
                throw new ArgumentException("Invalid payment method.");

            Method = method;
        }

        public override bool Equals(object obj)
        {
            if (obj is PaymentMethod other)
            {
                return Method == other.Method;
            }
            return false;
        }

        public override int GetHashCode() => Method.GetHashCode();
    }
}