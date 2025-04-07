using CommunityToolkit.Mvvm.ComponentModel;
using Demo.Abstraction.Entities;
using Demo.Abstraction.Models;

namespace Demo.Core.ViewModels
{
    public partial class TextRowViewModel : SemanticViewModel, IText, ILayoutOptions
    {
        [ObservableProperty]
        private LayoutOptions _layoutOptions;

        [ObservableProperty]
        private string _text = string.Empty;
    }
}
