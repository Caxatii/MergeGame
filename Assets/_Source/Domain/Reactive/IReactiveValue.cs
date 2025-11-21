using System;

namespace Domain.Reactive
{
    public interface IReactiveValue<out T> where T : struct
    {
        T Value { get; }
        event Action<T> Changed;
    }
}