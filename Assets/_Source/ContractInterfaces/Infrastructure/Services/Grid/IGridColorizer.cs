using System.Collections.Generic;
using ContractInterfaces.Application.Services;
using UnityEngine;

namespace ContractInterfaces.Infrastructure.Services.Grid
{
    public interface IGridColorizer : IService
    {
        public void Render(IReadOnlyList<(Color, Vector2Int)> colors);
    }
}