using System.ComponentModel;

namespace Demo.Abstraction.Entities
{
    public interface IViewModelCollectionBuilder
    {
        //-- ViewModels
        IViewModelCollectionBuilder AddPrimaryPageHeader(string headerTitle);
        IViewModelCollectionBuilder AddPrimaryPageFooter(string version, string copyright);

        //-- Behaviors
        IViewModelCollectionBuilder WithOneWayBinding<T>(IBindable bindable, string propertyName, Action<T> propertyChanged);
        IViewModelCollectionBuilder WithOneWayToSourceBinding<T>(string propertyName, Action<T> propertyChanged);
        IViewModelCollectionBuilder WithTwoWayBinding<T>(IBindable source, string propertyName, Action<T> sourcePropertyChanged, Action<T> targetPropertyChanged);

        //-- Build
        IList<INotifyPropertyChanged> Build();
    }
}
