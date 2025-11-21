using Domain.Reactive;
using UnityEngine;

namespace Domain.Grid.Cells
{
    public interface ICellPointer
    {
        public IReactiveValue<Vector2Int> Position { get; }
    }
}