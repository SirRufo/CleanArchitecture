using Desktop.Presentation.Common.Interfaces;
using Desktop.Presentation.Dialogs.EditName;
using Desktop.Presentation.Dialogs.SelectFile;

using Microsoft.Extensions.Logging;

using ReactiveUI;

using System.Collections.Generic;
using System.Reactive;
using System.Reactive.Linq;
using System.Windows.Input;

namespace Desktop.Presentation.ViewModels
{
    public class HomeViewModel : NavigationTargetViewModel
    {
        private readonly ReactiveCommand<Unit, DialogResult<string>> _editNameCommand;
        private readonly ObservableAsPropertyHelper<string> _name;
        private readonly ReactiveCommand<Unit, DialogResult<SelectFileResponse>> _selectTextFileCommand;
        private readonly ObservableAsPropertyHelper<string> _textFileName;

        public HomeViewModel( ILogger<HomeViewModel> logger, INavigationService navigationService, IDialogService dialogService ) : base( logger, navigationService )
        {
            LogoutCommand = ReactiveCommand.CreateFromTask( () => navigationService.NavigateToAsync<LoginViewModel>() );

            _editNameCommand = ReactiveCommand.CreateFromTask( () => dialogService.Show( new EditNameDialog { Name = Name, } ) );
            _name = _editNameCommand
                .Where( e => e.HasValue )
                .Select( dr => dr.Value )
                .ToProperty( this, x => x.Name );

            _selectTextFileCommand = ReactiveCommand.CreateFromTask( () => dialogService.Show( new SelectFileDialog { Filter = new List<FilterInfo> { new FilterInfo( "*.txt" ), new FilterInfo( "*.json" ) } } ) );
            _textFileName = _selectTextFileCommand
                .Where( e => e.HasValue )
                .Select( e => e.Value )
                .Select( e => e.FileName )
                .ToProperty( this, x => x.TextFileName );
        }

        public string Name => _name.Value;
        public ICommand EditNameCommand => _editNameCommand;
        public string TextFileName => _textFileName.Value;
        public ICommand SelectTextFileCommand => _selectTextFileCommand;

        public ICommand LogoutCommand { get; }

    }

    public class SimpleClass
    { }
}
