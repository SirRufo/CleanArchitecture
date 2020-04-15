
using Desktop.Presentation.Dialogs.EditName;
using Microsoft.Extensions.Logging;

using ReactiveUI;
using ReactiveUI.Fody.Helpers;

using System.Threading.Tasks;
using System.Windows.Input;

namespace Desktop.Presentation.ViewModels
{
    public class EditNameDialogViewModel : DialogViewModel<string>
    {
        public EditNameDialogViewModel( ILogger<EditNameDialogViewModel> logger ) : base( logger )
        {
            var canExecuteOkCommand = this.WhenAnyValue(
                e => e.IsInitializing,
                e => e.DialogPresenter,
                e => e.Name,
                ( init, dp, name ) => !init && dp != null && !string.IsNullOrWhiteSpace( name ) );

            OkCommand = ReactiveCommand.Create(
                () => DialogPresenter.DialogResult = true,
                canExecuteOkCommand );

            Title = "Give me the Name ...";
        }

        [Reactive] public string Name { get; set; }
        public ICommand OkCommand { get; }

        public override string GetResponse()
        {
            return Name;
        }

        protected override Task DoInitializeAsync( object parameter )
        {
            switch ( parameter )
            {
                case string name:
                    Name = name;
                    break;
                case EditNameDialog dlg:
                    Name = dlg.Name;
                    break;
                default:
                    break;
            }
            return base.DoInitializeAsync( parameter );
        }
    }
}
