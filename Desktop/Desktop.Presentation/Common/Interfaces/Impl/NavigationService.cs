using Desktop.Application.Common.Interfaces;
using Desktop.Presentation.ViewModels;

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

using System;
using System.Threading.Tasks;

namespace Desktop.Presentation.Common.Interfaces.Impl
{

    public class NavigationService : INavigationService
    {
        private readonly ILogger<NavigationService> _logger;
        private readonly MainViewModel _mainViewModel;
        private readonly IServiceProvider _serviceProvider;
        private readonly IAuthenticationService _authenticationService;

        public NavigationService( ILogger<NavigationService> logger, MainViewModel mainViewModel, IServiceProvider serviceProvider, IAuthenticationService authenticationService )
        {
            _logger = logger;
            _mainViewModel = mainViewModel;
            _serviceProvider = serviceProvider;
            _authenticationService = authenticationService;
        }
        public Task InitializeAsync()
        {
            if ( _authenticationService.IsAuthenticated )
                return NavigateToAsync<HomeViewModel>();
            else
                return NavigateToAsync<LoginViewModel>();
        }

        public Task NavigateToAsync<TViewModel>() where TViewModel : NavigationTargetViewModel
        {
            return DoNavigateToAsync<TViewModel>();
        }

        public Task NavigateToAsync<TViewModel>( object parameter ) where TViewModel : NavigationTargetViewModel
        {
            if ( parameter is null ) throw new ArgumentNullException( nameof( parameter ) );
            return DoNavigateToAsync<TViewModel>( parameter );
        }

        private Task DoNavigateToAsync<TViewModel>( object parameter = null ) where TViewModel : NavigationTargetViewModel
        {
            _logger.LogDebug( "{method}<{type}({parameter})>", nameof( DoNavigateToAsync ), typeof( TViewModel ).Name, parameter );
            var target = _serviceProvider.GetRequiredService<TViewModel>();
            _mainViewModel.Content = target;
            return target.InitializeAsync( parameter );
        }
    }
}
