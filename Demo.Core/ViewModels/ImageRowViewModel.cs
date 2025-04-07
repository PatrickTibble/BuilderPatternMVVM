using CommunityToolkit.Mvvm.ComponentModel;
using Demo.Abstraction.Models;

namespace Demo.Core.ViewModels
{
    public partial class ImageRowViewModel : SemanticViewModel
    {
        [ObservableProperty]
        private Images _source;
    }
}
