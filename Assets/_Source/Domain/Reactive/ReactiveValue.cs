using System;

namespace Domain.Reactive
{
    public class ReactiveValue<T> : IReactiveValue<T> where T : struct
    {
        private T _value;

        public T Value
        {
            get => _value;
            set
            {
                if (_value.Equals(value))
                    return;

                _value = value;
                Changed?.Invoke(value);
            }
        }

        public event Action<T> Changed;
    }
}