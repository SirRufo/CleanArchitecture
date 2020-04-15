using MediatR;

namespace Desktop.Presentation.Common.Interfaces
{
    public interface IDialogHandler<in TRequest, TResponse> : IRequestHandler<TRequest, DialogResult<TResponse>>
        where TRequest : IDialog<TResponse>
    { }
}
