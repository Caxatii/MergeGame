using System.Collections.Generic;
using _Source.ContractInterfaces.Infrastructure;
using _Source.ContractInterfaces.Presentation;
using UnityEngine;
using UnityEngine.UI;

namespace _Source.Infrastructure
{
    public class GridViewSpawner : IGridViewSpawner
    {
        private readonly GridLayoutGroup _parent;
        private readonly GridElementViewProvider _prefab;

        public GridViewSpawner(GridLayoutGroup parent, GridElementViewProvider prefab)
        {
            _parent = parent;
            _prefab = prefab;
        }

        public IGridView SpawnGrid(Vector2Int size)
        {
            IList<IGridElementView> cells = new List<IGridElementView>();

            for (int y = 0; y < size.y; y++)
                for (int x = 0; x < size.x; x++)
                    cells.Add(CreateCell(new Vector2Int(x, y)));

            return new GridView(cells);
        }

        private GridElementViewProvider CreateCell(Vector2Int position)
        {
            GridElementViewProvider cell = Object.Instantiate(_prefab, _parent.transform);
            cell.Initialize(position);
            return cell;
        }
    }
}