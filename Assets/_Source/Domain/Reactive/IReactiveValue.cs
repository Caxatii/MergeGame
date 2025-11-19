using System;

namespace _Source.Domain
{
    public interface IReactiveValue<out T> where T : struct
    {
        T Value { get; }
        event Action<T> Changed;
    }
}