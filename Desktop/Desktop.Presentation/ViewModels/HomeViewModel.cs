using Desktop.Presentation.Common.Interfaces;

using Microsoft.Extensions.Logging;

using ReactiveUI;

using System.Windows.Input;

namespace Desktop.Presentation.ViewModels
{
    public class HomeViewModel : NavigationTargetViewModel
    {
        public HomeViewModel( ILogger<HomeViewModel> logger, INavigationService navigationService ) : base( logger, navigationService )
        {
            LogoutCommand = ReactiveCommand.CreateFromTask( () => navigationService.NavigateToAsync<LoginViewModel>() );
        }

        public ICommand LogoutCommand { get; }
    }

    public class SimpleClass
    { }
}
