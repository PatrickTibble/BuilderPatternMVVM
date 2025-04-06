using System.ComponentModel;

namespace Demo.Abstraction.Entities
{
    public interface IViewModelCollectionBuilder
    {
        IList<INotifyPropertyChanged> Build();
    }
}
