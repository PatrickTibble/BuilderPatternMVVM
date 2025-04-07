using Demo.Abstraction.Entities;
using Demo.Abstraction.Services;
using Demo.Core.PageModels;

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
            
            if (page.BindingContext is IPrepare prep)
            {
                prep.Prepare(null);
            }

            InitializeAndForget(page);

            return new Window(page);
        }

        private async void InitializeAndForget(Page page)
        {
            if (page.BindingContext is IInitialize init)
            {
                await init.InitializeAsync(null, CancellationToken.None);
            }
        }
    }
}