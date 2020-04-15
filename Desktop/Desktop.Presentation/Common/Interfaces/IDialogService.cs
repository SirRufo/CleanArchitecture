using System.Threading.Tasks;

namespace Desktop.Presentation.Common.Interfaces
{
    public interface IDialogService
    {
        Task<DialogResult<TResponse>> Show<TResponse>( IDialog<TResponse> request );
    }
}
