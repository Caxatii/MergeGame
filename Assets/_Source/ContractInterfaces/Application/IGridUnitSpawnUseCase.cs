using System;
using UnityEngine;

namespace _Source.ContractInterfaces.Application
{
    public interface IGridUnitSpawnUseCase
    {
        public void Create(Vector2Int position, Guid id);
    }
}