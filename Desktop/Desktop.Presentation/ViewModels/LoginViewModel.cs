using Desktop.Presentation.Common.Interfaces;

using Microsoft.Extensions.Logging;

using ReactiveUI;
using System.Windows.Input;

namespace Desktop.Presentation.ViewModels
{
    public class LoginViewModel : NavigationTargetViewModel
    {
        public LoginViewModel( ILogger<LoginViewModel> logger, INavigationService navigationService ) : base( logger, navigationService )
        {
            LoginCommand = ReactiveCommand.CreateFromTask( () => navigationService.NavigateToAsync<HomeViewModel>() );
        }

        public ICommand LoginCommand { get; }
    }
}
