using Desktop.Presentation.Common.Interfaces;
using Desktop.Presentation.Dialogs.EditName;
using Desktop.Presentation.ViewModels;
using Desktop.WpfApp.Handlers.Dialogs.Internals;
using Desktop.WpfApp.Views;

using MediatR;

using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace Desktop.WpfApp.Handlers.Dialogs.GetName
{
    public class GetNameDialogHandler : IDialogHandler<EditNameDialog, string>
    {
        private readonly EditNameDialogViewModel _dialogViewModel;

        public GetNameDialogHandler( EditNameDialogViewModel dialogViewModel )
        {
            _dialogViewModel = dialogViewModel;
        }
        public async Task<DialogResult<string>> Handle( EditNameDialog request, CancellationToken cancellationToken )
        {
            await Task.Yield();

            var dialog = new DialogWindow
            {
                DataContext = _dialogViewModel,
            };

            var presenter = new DialogPresenter( dialog );

            dialog.IsVisibleChanged += ( s, e ) => _dialogViewModel.DialogPresenter = dialog.IsVisible ? presenter : null;
            dialog.IsVisibleChanged += ( s, e ) =>
            {
                if ( dialog.IsVisible )
                {

                    var w = App.Current.Windows.OfType<Window>().FirstOrDefault();
                    if ( w != null )
                    {
                        dialog.Top = w.Top;
                    }
                }
            };
            dialog.SizeChanged += ( s, e ) =>
            {
                var w = App.Current.Windows.OfType<Window>().FirstOrDefault();
                if ( w != null )
                {
                    dialog.Left = w.Left + w.ActualWidth / 2 - dialog.ActualWidth / 2;
                }
            };

            var inittask = _dialogViewModel.InitializeAsync( request );

            var dialogResult = dialog.ShowDialog();

            await inittask;

            return dialogResult == true
                ? new DialogResult<string>( _dialogViewModel.GetResponse() )
                : new DialogResult<string>();
        }
    }
}
