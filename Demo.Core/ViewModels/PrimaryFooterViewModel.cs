using CommunityToolkit.Mvvm.ComponentModel;
using Demo.Core.Entities;

namespace Demo.Core.ViewModels
{
    public partial class PrimaryFooterViewModel : BaseObservable
    {
        [ObservableProperty]
        private string _version = string.Empty;

        [ObservableProperty]
        private string _copyright = string.Empty;
    }
}
