using CommunityToolkit.Mvvm.ComponentModel;
using Demo.Core.Entities;

namespace Demo.Core.ViewModels
{
    public partial class PrimaryHeaderViewModel : BaseObservable
    {
        [ObservableProperty]
        private string _appTitle = string.Empty;
    }
}
