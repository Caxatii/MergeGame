using System.Collections.Generic;
using System.Linq;
using _Source.ContractInterfaces.Infrastructure;
using _Source.ContractInterfaces.Presentation;
using UnityEngine;

namespace _Source.Infrastructure
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