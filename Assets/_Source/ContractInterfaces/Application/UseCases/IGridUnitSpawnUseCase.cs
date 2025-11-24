using System;
using ContractInterfaces.Application.Services;
using UnityEngine;

namespace ContractInterfaces.Application.UseCases
{
    public interface IGridUnitSpawnUseCase : IService
    {
        public void Create(Vector2Int position, Guid id);
    }
}