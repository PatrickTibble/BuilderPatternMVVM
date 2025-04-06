using Demo.Abstraction.Services;

namespace Demo.Mobile.Services
{
    public class MainThreadInvoker : IMainThreadInvoker
    {
        public void BeginInvokeOnMainThread(Func<Task> taskFunc)
            => MainThread.BeginInvokeOnMainThread(async() => await taskFunc());

        public Task InvokeOnMainThreadAsync(Func<CancellationToken, Task> taskFunc, CancellationToken cancellationToken)
            => MainThread.InvokeOnMainThreadAsync(async () => await taskFunc(cancellationToken));

        public Task<T> InvokeOnMainThreadAsync<T>(Func<CancellationToken, Task<T>> taskFunc, CancellationToken cancellationToken)
            => MainThread.InvokeOnMainThreadAsync(async() => await taskFunc(cancellationToken));
    }
}
