using System.Collections.Generic;
using UnityEngine;

namespace ContractInterfaces.Infrastructure.Services.Grid
{
    public interface IGridColorizer
    {
        public void Render(IReadOnlyList<(Color, Vector2Int)> colors);
    }
}