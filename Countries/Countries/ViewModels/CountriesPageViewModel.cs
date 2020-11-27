namespace Countries.ViewModels
{
    using Countries.ItemViewModels;
    using Countries.Models;
    using Countries.Services;
    using Prism.Commands;
    using Prism.Navigation;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq;
    using Xamarin.Essentials;

    public class CountriesPageViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;
        private readonly IApiServices _apiServices;


        private bool _isRunning;
        private string _search;
        private bool _isVisible;
        private bool _activityIsRunning;
        private List<CountryResponse> _myCountries;
        private DelegateCommand _searchCommand;
        private ObservableCollection<CountryItemViewModel> _countries;

        public CountriesPageViewModel(INavigationService navigationService, IApiServices apiServices) : base(navigationService)
        {
            Title = "Countries Page";

            _navigationService = navigationService;
            _apiServices = apiServices;

            LoadCountriesAsync();
        }


        public DelegateCommand SearchCommand => _searchCommand ?? (_searchCommand = new DelegateCommand(ShowCountries));


        public string Search
        {
            get => _search;
            set
            {
                SetProperty(ref _search, value);
                ShowCountries();
            }
        }

        public bool IsRunning
        {
            get => _isRunning;
            set => SetProperty(ref _isRunning, value);
        }

        public bool IsVisible 
        {
            get => _isVisible;
            set => SetProperty(ref _isVisible, value);
        }

        public ObservableCollection<CountryItemViewModel> Countries
        {
            get => _countries;
            set => SetProperty(ref _countries, value);
        }

        public bool ActivityIsRunning 
        {
          get => _activityIsRunning;
          set => SetProperty(ref _activityIsRunning, value);
        }


        private async void LoadCountriesAsync()
        {
            //Check if internet is ok
            if (Connectivity.NetworkAccess != NetworkAccess.Internet)
            {
                await App.Current.MainPage.DisplayAlert("Error", "You have no internet", "OK");
                return;
            }

            //Used for binding on xaml
            IsRunning = true;
            ActivityIsRunning = true;
            IsVisible = false;


            string url = App.Current.Resources["UrlAPI"].ToString();

            //Get all info from API
            Response response = await _apiServices.GetListAsync<CountryResponse>(
                url, "/rest/v2/all");


            //Check if the response is well succded
            if (!response.IsSuccess)
            {
                await App.Current.MainPage.DisplayAlert("Error", response.Message, "OK");
                return;
            }


            _myCountries = (List<CountryResponse>)response.Result;
            ShowCountries();

            IsRunning = false;
            IsVisible = true;
            ActivityIsRunning = false;
        }


        /// <summary>
        /// Show countrie... if search textbox is not empty, just show what client search.
        /// if search textbox is empty show all countries
        /// </summary>
        private void ShowCountries()
        {
            if (string.IsNullOrEmpty(Search))
            {
                Countries = new ObservableCollection<CountryItemViewModel>(_myCountries.Select(p => new CountryItemViewModel(_navigationService)
                {
                    Name = p.Name,
                    TopLevelDomain = p.TopLevelDomain,
                    Alpha2Code = p.Alpha2Code,
                    Alpha3Code = p.Alpha3Code,
                    CallingCodes = p.CallingCodes,
                    Capital = p.Capital,
                    AltSpellings = p.AltSpellings,
                    Region = p.Region,
                    Subregion = p.Subregion,
                    Population = p.Population,
                    Latlng = p.Latlng,
                    Demonym = p.Demonym,
                    Area = p.Area,
                    Gini = p.Gini,
                    Timezones = p.Timezones,
                    Borders = p.Borders,
                    NativeName = p.NativeName,
                    NumericCode = p.NumericCode,
                    Currencies = p.Currencies,
                    Languages = p.Languages,
                    Translations = p.Translations,
                    Flag = p.Flag,
                    RegionalBlocs = p.RegionalBlocs,
                    Cioc = p.Cioc

                }).ToList());
            }
            else
            {
                Countries = new ObservableCollection<CountryItemViewModel>(_myCountries.Select(p => new CountryItemViewModel(_navigationService)
                {
                    Name = p.Name,
                    TopLevelDomain = p.TopLevelDomain,
                    Alpha2Code = p.Alpha2Code,
                    Alpha3Code = p.Alpha3Code,
                    CallingCodes = p.CallingCodes,
                    Capital = p.Capital,
                    AltSpellings = p.AltSpellings,
                    Region = p.Region,
                    Subregion = p.Subregion,
                    Population = p.Population,
                    Latlng = p.Latlng,
                    Demonym = p.Demonym,
                    Area = p.Area,
                    Gini = p.Gini,
                    Timezones = p.Timezones,
                    Borders = p.Borders,
                    NativeName = p.NativeName,
                    NumericCode = p.NumericCode,
                    Currencies = p.Currencies,
                    Languages = p.Languages,
                    Translations = p.Translations,
                    Flag = p.Flag,
                    RegionalBlocs = p.RegionalBlocs,
                    Cioc = p.Cioc

                }).Where(p => p.Name.ToLower().Contains(Search.ToLower())).ToList());
            }
        }
    }
}
