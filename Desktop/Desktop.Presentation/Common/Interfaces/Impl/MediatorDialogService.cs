
using MediatR;
using System.Threading.Tasks;

namespace Desktop.Presentation.Common.Interfaces.Impl
{
    public class MediatorDialogService : IDialogService
    {
        private readonly IMediator _mediator;

        public MediatorDialogService( IMediator mediator )
        {
            _mediator = mediator;
        }
        public Task<DialogResult<TResponse>> Show<TResponse>( IDialog<TResponse> request )
        {
            return _mediator.Send( request );
        }
    }
}
