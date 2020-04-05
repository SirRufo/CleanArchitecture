
using Microsoft.Extensions.Logging;

using ReactiveUI.Fody.Helpers;

using System.Threading.Tasks;

namespace Desktop.Presentation.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        private readonly ILogger<MainViewModel> _logger;

        public MainViewModel( ILogger<MainViewModel> logger ) : base( logger )
        {
            _logger = logger;
        }

        protected override Task DoInitializeAsync( object parameter )
        {
            _logger.LogDebug( "DoInitializeAsync( parameter: {0} )", parameter );
            return base.DoInitializeAsync( parameter );
        }

        [Reactive] public NavigationTargetViewModel Content { get; internal set; }
    }
}
