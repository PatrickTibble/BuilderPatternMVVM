using CommunityToolkit.Mvvm.ComponentModel;
using Demo.Abstraction.Entities;

namespace Demo.Core.ViewModels
{
    public partial class TextRowViewModel : SemanticViewModel, IText
    {
        [ObservableProperty]
        private string _text = string.Empty;
    }
}
