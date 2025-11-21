using System;
using UnityEngine;

namespace ContractInterfaces.Application.UseCases
{
    public interface IGridUnitSpawnUseCase
    {
        public void Create(Vector2Int position, Guid id);
    }
}