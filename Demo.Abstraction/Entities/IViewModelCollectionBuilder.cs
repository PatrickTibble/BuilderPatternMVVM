using Demo.Abstraction.Models;
using System.ComponentModel;
using System.Windows.Input;

namespace Demo.Abstraction.Entities
{
    public interface IViewModelCollectionBuilder
    {
        //-- ViewModels
        IViewModelCollectionBuilder AddButtonRow(string text, ICommand command);
        IViewModelCollectionBuilder AddImageRow(Images image);
        IViewModelCollectionBuilder AddPrimaryPageHeader(string headerTitle);
        IViewModelCollectionBuilder AddPrimaryPageFooter(string version, string copyright);
        IViewModelCollectionBuilder AddTextRow(string text);

        //-- Behaviors
        IViewModelCollectionBuilder WithOneWayBinding<T>(IBindable bindable, string propertyName, Action<T> propertyChanged);
        IViewModelCollectionBuilder WithOneWayToSourceBinding<T>(string propertyName, Action<T> propertyChanged);
        IViewModelCollectionBuilder WithTwoWayBinding<T>(IBindable source, string propertyName, Action<T> sourcePropertyChanged, Action<T> targetPropertyChanged);

        IViewModelCollectionBuilder WithSemanticProperties(SemanticOptions level, string description);
        IViewModelCollectionBuilder WithLayoutOptions(LayoutOptions layoutOptions);

        //-- Build
        IList<INotifyPropertyChanged> Build();
    }
}
