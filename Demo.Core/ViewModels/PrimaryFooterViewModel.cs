using CommunityToolkit.Mvvm.ComponentModel;
using Demo.Core.Entities;

namespace Demo.Core.ViewModels
{
    public partial class PrimaryFooterViewModel : BaseObservable
    {
        [ObservableProperty]
        private string _version;

        [ObservableProperty]
        private string _copyright;

        public PrimaryFooterViewModel(string version, string copyright)
        {
            _version = version;
            _copyright = copyright;
        }
    }
}
