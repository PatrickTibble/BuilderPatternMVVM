using Demo.Abstraction.Entities;
using Demo.Abstraction.Services;

namespace Demo.Mobile
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
        }

        protected override Window CreateWindow(IActivationState? activationState)
        {
            var locator = Resolver.Resolve<IViewLocator<Page>>();
            var page = locator.LocateFor<ShellPageModel>();
            return new Window(new AppShell());
        }
    }
}