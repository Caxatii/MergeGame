using UnityEngine;

namespace _Source.Domain
{
    public interface ICellPointer
    {
        public IReactiveValue<Vector2Int> Position { get; }
    }
}