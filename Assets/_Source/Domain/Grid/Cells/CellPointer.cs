using Domain.Reactive;
using UnityEngine;

namespace Domain.Grid.Cells
{
    public class CellPointer : ICellPointer
    {
        public readonly ReactiveValue<Vector2Int> Pointer = new ReactiveValue<Vector2Int>();
        public IReactiveValue<Vector2Int> Position => Pointer;
    }
}