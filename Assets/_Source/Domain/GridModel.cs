using System;
using System.Collections;
using System.Collections.Generic;
using _Source.ContractInterfaces.Domain;
using UnityEngine;

namespace _Source.Domain
{
    public class GridModel<T> : IGridModel where T : IUnit
    {
        private readonly Cell<T>[,] _cells;

        public GridModel(int width, int height)
        {
            Width = width;
            Height = height;

            _cells = new Cell<T>[width, height];
        }

        public int Width { get; }

        public int Height { get; }

        public event Action<Vector2Int> CellChanged;

        public IUnit this[Vector2Int position]
        {
            get => _cells[position.x, position.y].Data;
            set
            {
                _cells[position.x, position.y] = new Cell<T>((T)value);
                CellChanged?.Invoke(position);
            }
        }


        public bool IsEmptyAt(Vector2Int position)
        {
            return InBounds(position) && _cells[position.x, position.y].IsEmpty;
        }

        public bool InBounds(Vector2Int position)
        {
            return position.x >= 0 && position.x < Width &&
                   position.y >= 0 && position.y < Height;
        }

        public IEnumerator<(Vector2Int, IUnit)> GetEnumerator()
        {
            for (int i = 0; i < _cells.GetLength(0); i++)
                for (int j = 0; j < _cells.GetLength(1); j++)
                {
                    yield return (new Vector2Int(i, j), _cells[i, j].Data);
                }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}