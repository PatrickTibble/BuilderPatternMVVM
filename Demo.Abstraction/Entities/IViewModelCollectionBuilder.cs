using System.ComponentModel;

namespace Demo.Abstraction.Entities
{
    public interface IViewModelCollectionBuilder
    {
        IViewModelCollectionBuilder AddPrimaryPageHeader(string headerTitle);
        IViewModelCollectionBuilder AddPrimaryPageFooter(string version, string copyright);

        //-- Build
        IList<INotifyPropertyChanged> Build();
    }
}
