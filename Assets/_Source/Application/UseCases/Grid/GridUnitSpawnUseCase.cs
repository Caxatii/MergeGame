using System;
using ContractInterfaces.Application.Factories;
using ContractInterfaces.Application.UseCases;
using ContractInterfaces.Domain;
using UnityEngine;

namespace Application.UseCases.Grid
{
    public class GridUnitSpawnUseCase : IGridUnitSpawnUseCase
    {
        private readonly IUnitFactory _factory;
        private readonly IGridModel _gridModel;

        public GridUnitSpawnUseCase(IGridModel gridModel, IUnitFactory factory)
        {
            _gridModel = gridModel;
            _factory = factory;
        }

        public void Create(Vector2Int position, Guid id)
        {
            _gridModel[position] = _factory.Create(id);
        }

        public void Initialize() { }
        
        public void Dispose() { }
    }
}