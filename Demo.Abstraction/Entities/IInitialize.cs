namespace Demo.Abstraction.Entities
{
    public interface IInitialize
    {
        Task InitializeAsync(IDictionary<string, object>? initializationParameters, CancellationToken token);
    }
}
