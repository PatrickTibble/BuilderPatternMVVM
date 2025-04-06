namespace Demo.Abstraction.Services
{
    public interface IMainThreadInvoker
    {
        void BeginInvokeOnMainThread(Func<Task> taskFunc);
        Task InvokeOnMainThreadAsync(Func<CancellationToken, Task> taskFunc, CancellationToken cancellationToken);
        Task<T> InvokeOnMainThreadAsync<T>(Func<CancellationToken, Task<T>> taskFunc, CancellationToken cancellationToken);
    }
}
