namespace api.Application.Helpers
{
    public static class AssertionHelper
    {
        public static T AssertExistsAndOfType<T>(object? obj) where T : class
        {
            if (obj == null)
            {
                throw new KeyNotFoundException($"{typeof(T).Name} does not exist");
            }

            if (obj is not T validEntity)
            {
                throw new InvalidCastException($"The provided entity is not of type {typeof(T).Name}");
            }

            return validEntity;
        }
    }
}
