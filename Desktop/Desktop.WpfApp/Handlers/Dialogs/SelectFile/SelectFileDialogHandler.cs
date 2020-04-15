using Desktop.Presentation.Common.Interfaces;
using Desktop.Presentation.Dialogs.SelectFile;

using Microsoft.Win32;

using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Desktop.WpfApp.Handlers.Dialogs.SelectFile
{
    public class SelectFileDialogHandler : IDialogHandler<SelectFileDialog, SelectFileResponse>
    {
        public async Task<DialogResult<SelectFileResponse>> Handle( SelectFileDialog request, CancellationToken cancellationToken )
        {
            await Task.Yield();

            var dialog = new OpenFileDialog
            {
            };

            if ( request.Filter != null && request.Filter.Any() )
            {
                var filter = string.Join( "|", request.Filter.Select( e => string.Format( "{0}|{1}", e.Description ?? e.Filter, e.Filter ) ) );

                dialog.Filter = filter;
            }

            var result = dialog.ShowDialog();

            return result == true
                ? new DialogResult<SelectFileResponse>( new SelectFileResponse
                {
                    FileName = dialog.FileName,
                } )
                : new DialogResult<SelectFileResponse>();
        }
    }
}
