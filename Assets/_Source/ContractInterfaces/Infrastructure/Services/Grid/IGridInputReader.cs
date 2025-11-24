using System;
using ContractInterfaces.Application.Services;
using UnityEngine;

namespace ContractInterfaces.Infrastructure.Services.Grid
{
    public interface IGridInputReader : IService
    {
        public event Action<Vector2Int> Clicked;
    }
}