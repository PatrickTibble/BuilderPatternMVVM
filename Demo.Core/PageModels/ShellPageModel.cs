using Demo.Abstraction.Constants;
using Demo.Abstraction.Entities;
using Demo.Abstraction.Services;
using Demo.Core.Localization;
using System.ComponentModel;

namespace Demo.Core.PageModels
{
    public partial class ShellPageModel : BuildablePageModel
    {
        private readonly IPlatformService _platformService;

        public ShellPageModel(IPlatformService platformService)
        {
            _platformService = platformService;
        }

        public override Task InitializeAsync(IDictionary<string, object>? initializationParameters, CancellationToken token)
        {
            return base.InitializeAsync(initializationParameters, token);
        }

        protected override IList<INotifyPropertyChanged> CreateOptionalHeaders(IViewModelCollectionBuilder builder)
        {
            return builder
                .AddPrimaryPageHeader(DisplayStrings.AppTitle)
                .Build();
        }

        protected override IList<INotifyPropertyChanged> CreateItems(IViewModelCollectionBuilder builder)
        {
            return builder

                .Build();
        }

        protected override IList<INotifyPropertyChanged> CreateOptionalFooters(IViewModelCollectionBuilder builder)
        {
            return builder
                .AddPrimaryPageFooter(string.Format(FormatStrings.AppVersion, _platformService.PlatformVersion), string.Format(FormatStrings.Copyright, AuthorConstants.Author))
                .Build();
        }
    }
}
