using Desktop.Presentation.Common.Interfaces;

using System.Windows;

namespace Desktop.WpfApp.Handlers.Dialogs.Internals
{
    internal class DialogPresenter : IDialogPresenter
    {
        private readonly Window _window;

        public DialogPresenter( Window window )
        {
            _window = window;
        }
        public bool? DialogResult
        {
            get => _window.DialogResult;
            set => _window.DialogResult = value;
        }
    }
}
