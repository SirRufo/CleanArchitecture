
using System;

namespace Desktop.Presentation.Common.Interfaces
{
    public class DialogResult<T>
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

        public bool HasValue { get; }
        public T Value
        {
            get
            {
                if ( !HasValue ) throw new InvalidOperationException();
                return _value;
            }
        }
    }
}
