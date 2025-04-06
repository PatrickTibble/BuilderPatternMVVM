using System.ComponentModel;

namespace Demo.Abstraction.Services
{
    public interface INavigationService
    {
        Task ShowModalAsync<TPageModel>(IDictionary<string, object>? navigationParameters, CancellationToken token)
            where TPageModel : INotifyPropertyChanged;
        Task DismissModalAsync(CancellationToken token);

        Task PushAsync<TPageModel>(IDictionary<string, object>? navigationParameters, CancellationToken token)
            where TPageModel : INotifyPropertyChanged;
        Task GoBackAsync(CancellationToken token);

    }
}
