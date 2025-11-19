using System.Collections.Generic;
using _Source.ContractInterfaces.Infrastructure;
using _Source.ContractInterfaces.Presentation;
using UnityEngine;

namespace _Source.Infrastructure
{
    public class GridColorizer : IGridColorizer
    {
        private IGridView _gridView;

        public GridColorizer(IGridView gridView)
        {
            _gridView = gridView;
        }
        
        public void Render(IReadOnlyList<(Color, Vector2Int)> colors)
        {
            foreach ((Color color, Vector2Int position) cell in colors)
            {
                _gridView.Get(cell.position).SetBackgroundColor(cell.color);
            }
        }
    }
}