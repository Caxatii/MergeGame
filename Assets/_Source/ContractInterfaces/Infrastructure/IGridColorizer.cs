using System.Collections.Generic;
using UnityEngine;

namespace _Source.ContractInterfaces.Infrastructure
{
    public interface IGridColorizer
    {
        public void Render(IReadOnlyList<(Color, Vector2Int)> colors);
    }
}