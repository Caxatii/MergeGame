using System.Collections.Generic;
using System.Linq;
using ContractInterfaces.Infrastructure.View.Grid;
using ContractInterfaces.Presentation.Grid;
using UnityEngine;

namespace Infrastructure.View.Grid
{
    public class GridView : IGridView
    {
        private readonly Dictionary<Vector2Int, IGridElementView> _elementViews;
        private readonly List<IGridElementView> _views;

        public GridView(IList<IGridElementView> views)
        {
            _views = views.ToList();

            _elementViews = views.ToDictionary(
                k => k.Position,
                v => v);
        }

        public IGridElementView Get(Vector2Int position)
        {
            return _elementViews[position];
        }

        public IReadOnlyList<IGridElementView> GetAll()
        {
            return _views;
        }
    }
}