using System;
using UnityEngine;

namespace _Source.ContractInterfaces.Infrastructure
{
    public interface IGridInputReader : IDisposable
    {
        public void Initialize();

        public event Action<Vector2Int> Clicked;
    }
}