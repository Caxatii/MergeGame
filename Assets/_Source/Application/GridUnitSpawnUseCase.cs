using System;
using _Source.ContractInterfaces.Application;
using _Source.ContractInterfaces.Application.Factories;
using _Source.ContractInterfaces.Domain;
using UnityEngine;

namespace _Source.Application
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
    }
}