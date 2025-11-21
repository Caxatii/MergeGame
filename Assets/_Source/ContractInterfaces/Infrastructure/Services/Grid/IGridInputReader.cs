using System;
using UnityEngine;

namespace ContractInterfaces.Infrastructure.Services.Grid
{
    public interface IGridInputReader : IDisposable
    {
        public void Initialize();

        public event Action<Vector2Int> Clicked;
    }
}