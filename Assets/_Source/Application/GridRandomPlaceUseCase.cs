using System;
using _Source.ContractInterfaces.Application;
using _Source.ContractInterfaces.Domain;
using UnityEngine;
using Random = System.Random;

namespace _Source.Application
{
    public class GridRandomPlaceUseCase
    {
        private readonly IGridModel _model;

        private readonly Random _random = new Random();
        private readonly IGridUnitSpawnUseCase _spawnUseCase;

        public GridRandomPlaceUseCase(IGridModel model, IGridUnitSpawnUseCase spawnUseCase)
        {
            _model = model;
            _spawnUseCase = spawnUseCase;
        }

        public void Spawn(Guid id)
        {
            int maxTryCount = _model.Width * _model.Height;
            Vector2Int position = GetRandomPosition();

            while (!_model.IsEmptyAt(position))
            {
                position = GetRandomPosition();
                maxTryCount--;

                if (maxTryCount <= 0)
                    return;
            }

            _spawnUseCase.Create(position, id);
        }

        private Vector2Int GetRandomPosition()
        {
            int x = _random.Next(0, _model.Width);
            int y = _random.Next(0, _model.Height);

            return new Vector2Int(x, y);
        }
    }
}