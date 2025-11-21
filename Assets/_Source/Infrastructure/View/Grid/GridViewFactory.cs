using System.Collections.Generic;
using ContractInterfaces.Infrastructure.View.Grid;
using ContractInterfaces.Presentation.Grid;
using UnityEngine;
using UnityEngine.UI;

namespace Infrastructure.View.Grid
{
    public class GridViewFactory : IGridViewSpawner
    {
        private readonly GridLayoutGroup _parent;
        private readonly IGridElementView _prefab;

        public GridViewFactory(GridLayoutGroup parent, IGridElementView prefab)
        {
            _parent = parent;
            _prefab = prefab;
        }

        public IGridView Create(Vector2Int size)
        {
            IList<IGridElementView> cells = new List<IGridElementView>();

            for (int y = 0; y < size.y; y++)
            for (int x = 0; x < size.x; x++)
                cells.Add(CreateCell(new Vector2Int(x, y)));

            return new GridView(cells);
        }

        private IGridElementView CreateCell(Vector2Int position)
        {
            var cell = Object.Instantiate(_prefab as MonoBehaviour, _parent.transform).
                GetComponent<IGridElementView>();
            
            cell.Initialize(position);
            return cell;
        }
    }
}