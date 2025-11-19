using UnityEngine;

namespace _Source.Domain
{
    public class CellPointer : ICellPointer
    {
        public readonly ReactiveValue<Vector2Int> Pointer = new ReactiveValue<Vector2Int>();
        public IReactiveValue<Vector2Int> Position => Pointer;
    }
}