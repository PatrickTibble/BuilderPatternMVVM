using CommunityToolkit.Mvvm.ComponentModel;
using Demo.Abstraction.Entities;
using System.Windows.Input;

namespace Demo.Core.ViewModels
{
    public partial class ButtonRowViewModel : SemanticViewModel, IText
    {
        [ObservableProperty]
        private string _text = string.Empty;

        [ObservableProperty]
        private ICommand? _command;
    }
}
