using Caliburn.Micro;

namespace Win81CaliburnAutofac
{
    public class ChildViewModel
    {
        private readonly INavigationService _navigationService;

        public ChildViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
        }

        public void Back()
        {
            _navigationService.NavigateToViewModel<MainViewModel>();
        }
    }
}