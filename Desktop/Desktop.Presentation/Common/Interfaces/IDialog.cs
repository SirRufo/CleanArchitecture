using MediatR;

namespace Desktop.Presentation.Common.Interfaces
{
    public interface IDialog<TResponse> : IRequest<DialogResult<TResponse>>
    { }
}
