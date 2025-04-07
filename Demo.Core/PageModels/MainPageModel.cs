using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Demo.Abstraction.Constants;
using Demo.Abstraction.Entities;
using Demo.Abstraction.Models;
using Demo.Abstraction.Services;
using Demo.Core.Localization;
using System.ComponentModel;

namespace Demo.Core.PageModels
{
    public partial class MainPageModel : BuildablePageModel
    {
        private readonly IPlatformService _platformService;

        private int _count;

        [ObservableProperty]
        private string _clickCounter = string.Empty;

        public MainPageModel(IPlatformService platformService)
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
                .AddImageRow(Images.DotNetBot)
                    .WithSemanticProperties(SemanticOptions.Level1, SemanticStrings.DotNetBotDescription)
                .AddTextRow(DisplayStrings.HelloWorld)
                    .WithSemanticProperties(SemanticOptions.Level1, string.Empty)
                .AddTextRow(DisplayStrings.WelcomeToMaui)
                    .WithSemanticProperties(SemanticOptions.Level2, SemanticStrings.WelcomeToDotNetNine)
                .AddButtonRow(DisplayStrings.ClickMe, CounterClickCommand)
                    .WithOneWayBinding<IText>(this, nameof(ClickCounter), vm => vm.Text = ClickCounter)
                    .WithSemanticProperties(SemanticOptions.Level1, SemanticStrings.CounterButtonHint)
                .Build();
        }

        protected override IList<INotifyPropertyChanged> CreateOptionalFooters(IViewModelCollectionBuilder builder)
        {
            return builder
                .AddPrimaryPageFooter(string.Format(FormatStrings.AppVersion, _platformService.PlatformVersion), string.Format(FormatStrings.Copyright, AuthorConstants.Author))
                .Build();
        }

        [RelayCommand]
        private void OnCounterClick()
        {
            ++_count;
            var text = string.Format(FormatStrings.ClickCount, _count);
            ClickCounter = $"{text}{(_count > 1 ? "s" : string.Empty)}";
            System.Diagnostics.Debug.WriteLine(ClickCounter);
        }
    }
}
