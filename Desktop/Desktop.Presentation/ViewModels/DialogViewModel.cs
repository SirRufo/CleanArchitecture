using Desktop.Presentation.Common.Interfaces;

using Microsoft.Extensions.Logging;

using ReactiveUI;
using ReactiveUI.Fody.Helpers;

using System;
using System.Reactive.Linq;
using System.Windows.Input;

namespace Desktop.Presentation.ViewModels
{
    public abstract class DialogViewModel<TResponse> : ViewModelBase
    {
        protected DialogViewModel( ILogger<DialogViewModel<TResponse>> logger ) : base( logger )
        {
            var canCancelCommand = this
                .WhenAnyValue( e => e.DialogPresenter )
                .Select( presenter => presenter != null );

            CancelCommand = ReactiveCommand.Create( () => DialogPresenter.DialogResult = false, canCancelCommand );

            this.WhenAnyValue( e => e.DialogPresenter )
                .Subscribe( e => logger.LogInformation( "DialogPresenter changed to {presenter}", e ) );
        }

        [Reactive] public IDialogPresenter DialogPresenter { get; set; }
        public ICommand CancelCommand { get; }
        [Reactive] public string Title { get; protected set; }

        public abstract TResponse GetResponse();
    }
}
