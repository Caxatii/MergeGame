using System.Collections.Generic;
using ContractInterfaces.Infrastructure.Services.Grid;
using ContractInterfaces.Infrastructure.View.Grid;
using UnityEngine;

namespace Infrastructure.View.Grid
{
    public class GridColorizer : IGridColorizer
    {
        private readonly IGridView _gridView;

        public GridColorizer(IGridView gridView)
        {
            _gridView = gridView;
        }

        public void Render(IReadOnlyList<(Color, Vector2Int)> colors)
        {
            foreach ((Color color, Vector2Int position) cell in colors)
                _gridView.Get(cell.position).SetBackgroundColor(cell.color);
        }

        public void Initialize() { }

        public void Dispose() { }
    }
}