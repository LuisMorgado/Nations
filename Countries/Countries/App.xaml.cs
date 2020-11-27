namespace Countries
{
    using Prism;
    using Prism.Ioc;
    using Countries.ViewModels;
    using Countries.Views;
    using Xamarin.Essentials.Interfaces;
    using Xamarin.Essentials.Implementation;
    using Xamarin.Forms;
    using Countries.Services;


    public partial class App
    {
        public App(IPlatformInitializer initializer)
            : base(initializer)
        {
        }

        protected override async void OnInitialized()
        {
            InitializeComponent();

            await NavigationService.NavigateAsync("NavigationPage/CountriesPage");
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterSingleton<IAppInfo, AppInfoImplementation>();

            containerRegistry.RegisterForNavigation<NavigationPage>();
            containerRegistry.RegisterForNavigation<LoginPage, LoginPageViewModel>();
            containerRegistry.Register<IApiServices, ApiServices>();
            containerRegistry.RegisterForNavigation<CountriesPage, CountriesPageViewModel>();
            containerRegistry.RegisterForNavigation<CountryDetailsPage, CountryDetailsPageViewModel>();
        }
    }
}
