namespace Countries.ViewModels
{
    using Countries.Models;
    using Prism.Navigation;



    public class CountryDetailsPageViewModel : ViewModelBase
    {
        private CountryResponse _country;


        public CountryDetailsPageViewModel(INavigationService navigationService) : base(navigationService)
        {
            Title = "Country details";
        }


        public CountryResponse Country
        {
            get => _country;
            set => SetProperty(ref _country, value);
        }


        /// <summary>
        /// Navigate to the page
        /// </summary>
        /// <param name="parameters"></param>
        public override void OnNavigatedTo(INavigationParameters parameters)
        {
            base.OnNavigatedTo(parameters);

            if (parameters.ContainsKey("country"))
            {
                Country = parameters.GetValue<CountryResponse>("country");
                Title = Country.Name;
            }
        }
    }
}