using Demo.Core.Entities;

namespace Demo.Core.PageModels
{
    public partial class ShellPageModel : BaseObservable
    {
        public override Task InitializeAsync(IDictionary<string, object>? initializationParameters, CancellationToken token)
        {
            return base.InitializeAsync(initializationParameters, token);
        }
    }
}
