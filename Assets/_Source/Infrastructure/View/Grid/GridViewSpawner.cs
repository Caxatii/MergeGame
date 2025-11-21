using System.Collections.Generic;
using ContractInterfaces.Infrastructure.View.Grid;
using ContractInterfaces.Presentation.Grid;
using UnityEngine;
using UnityEngine.UI;

namespace Infrastructure.View.Grid
{
    public class GridViewSpawner : IGridViewSpawner
    {
        private readonly GridLayoutGroup _parent;
        private readonly GridElementViewBase _prefab;

        public GridViewSpawner(GridLayoutGroup parent, GridElementViewBase prefab)
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

        private GridElementViewBase CreateCell(Vector2Int position)
        {
            GridElementViewBase cell = Object.Instantiate(_prefab, _parent.transform);
            cell.Initialize(position);
            return cell;
        }
    }
}