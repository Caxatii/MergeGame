using System;
using System.Collections.Generic;
using UnityEngine;

namespace _Source.ContractInterfaces.Domain
{
    public interface IGridModel : IEnumerable<(Vector2Int, IUnit)>
    {
        public int Width { get; }
        public int Height { get; }

        public IUnit this[Vector2Int position] { get; set; }

        public event Action<Vector2Int> CellChanged;

        public bool IsEmptyAt(Vector2Int position);

        public bool InBounds(Vector2Int position);
    }

    // public interface IGridModel<T> : IGridModel where T : IUnit
    // {
    //     public int Width { get; }
    //     public int Height { get; }
    //
    //     public new T this[Vector2Int position] { get; set; }
    //
    //     public event Action<Vector2Int> CellChanged;
    //
    //     public bool IsEmptyAt(Vector2Int position);
    //
    //     public bool InBounds(Vector2Int position);
    // }
}