namespace Countries.ItemViewModels
{
    using Countries.Models;
    using Countries.Views;
    using Prism.Commands;
    using Prism.Navigation;


    public class CountryItemViewModel : CountryResponse
    {
        private readonly INavigationService _navigationService;
        private DelegateCommand _selectCountryCommand;


        public CountryItemViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
        }


        public DelegateCommand SelectCountryCommand => _selectCountryCommand ?? (_selectCountryCommand = new DelegateCommand(SelectCountryAsync));


        private async void SelectCountryAsync()
        {
            //Generate parameters for countryDetailsPage
            NavigationParameters parameters = new NavigationParameters
            {
                {"country", this }
            };

            await _navigationService.NavigateAsync(nameof(CountryDetailsPage), parameters);
        }
    }
}
