using Caliburn.Micro;

namespace Win81CaliburnAutofac
{
    public class MainViewModel
    {
        private readonly INavigationService _navigationService;

        public MainViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
        }

        public void Navigate()
        {
            _navigationService.NavigateToViewModel<ChildViewModel>();
        }
    }
}