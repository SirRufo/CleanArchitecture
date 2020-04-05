using Desktop.Presentation.Common.Interfaces;

using Microsoft.Extensions.Logging;

namespace Desktop.Presentation.ViewModels
{
    public abstract class NavigationTargetViewModel : ViewModelBase
    {
        protected NavigationTargetViewModel( ILogger<NavigationTargetViewModel> logger, INavigationService navigationService ) : base( logger )
        {
            NavigationService = navigationService;
        }

        public INavigationService NavigationService { get; }
    }
}
