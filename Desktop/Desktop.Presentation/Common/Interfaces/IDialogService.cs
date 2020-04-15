using MediatR;

using System;
using System.Threading.Tasks;

namespace Desktop.Presentation.Common.Interfaces
{
    public interface IDialogService
    {
        Task<DialogResult<TResponse>> Show<TResponse>( IDialog<TResponse> request );
    }

    public interface IDialog<TResponse> : IRequest<DialogResult<TResponse>>
    { }

    public interface IDialogHandler<in TRequest, TResponse> : IRequestHandler<TRequest, DialogResult<TResponse>>
        where TRequest : IDialog<TResponse>
    { }

    public abstract class DialogResult
    {
        public abstract bool HasValue { get; }
    }

    public class DialogResult<T> : DialogResult
    {
        private readonly T _value;
        public DialogResult()
        {
            HasValue = false;
        }

        public DialogResult( T value )
        {
            HasValue = true;
            _value = value;
        }

        public override bool HasValue { get; }
        public T Value
        {
            get
            {
                if ( !HasValue ) throw new InvalidOperationException();
                return _value;
            }
        }
    }

    public interface IDialogPresenter
    {
        bool? DialogResult { get; set; }
    }
}
