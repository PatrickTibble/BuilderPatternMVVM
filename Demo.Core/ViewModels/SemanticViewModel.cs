using CommunityToolkit.Mvvm.ComponentModel;
using Demo.Abstraction.Entities;
using Demo.Abstraction.Models;
using Demo.Core.Entities;

namespace Demo.Core.ViewModels
{
    public abstract partial class SemanticViewModel : BaseObservable, ISemanticViewModel
    {
        [ObservableProperty]
        private string _semanticDescription = string.Empty;

        [ObservableProperty]
        private SemanticOptions _semanticLevel = SemanticOptions.Level1;
    }
}
