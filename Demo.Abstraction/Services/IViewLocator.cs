using System.ComponentModel;

namespace Demo.Abstraction.Services
{
    public interface IViewLocator<TBaseView>
    {
        TBaseView LocateFor<TObservable>()
            where TObservable : INotifyPropertyChanged;

        void Register<TView, TObservable>()
            where TView : TBaseView
            where TObservable : INotifyPropertyChanged;
    }
}
