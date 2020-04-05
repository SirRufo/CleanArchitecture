
using Microsoft.Extensions.Logging;

using ReactiveUI;
using ReactiveUI.Fody.Helpers;

using System.Threading.Tasks;

namespace Desktop.Presentation.ViewModels
{
    public abstract class ViewModelBase : ReactiveObject
    {
        private readonly ILogger<ViewModelBase> _logger;

        protected ViewModelBase( ILogger<ViewModelBase> logger )
        {
            _logger = logger;
        }

        [Reactive] public bool IsBusy { get; set; }
        [Reactive] public bool IsInitializing { get; set; }
        [Reactive] public bool IsInitialized { get; set; }

        public async Task InitializeAsync( object parameter )
        {
            _logger.LogDebug( "InitializeAsync( parameter: {0} )", parameter );
            IsInitializing = true;
            try
            {
                await DoInitializeAsync( parameter );
                IsInitialized = true;
            }
            finally
            {
                IsInitializing = false;
            }
        }

        virtual protected Task DoInitializeAsync( object parameter )
        {
            return Task.CompletedTask;
        }
    }
}
