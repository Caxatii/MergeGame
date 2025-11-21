using System;
using ContractInterfaces.Application.Services;
using ContractInterfaces.Application.UseCases;
using ContractInterfaces.Domain;
using ContractInterfaces.Repositories.Merge;
using UnityEngine;

namespace Application.Services.Grid
{
    public class GridMergeService : IMergeService
    {
        private readonly IGridModel _gridModel;
        private readonly IMergeRepositoryCollection _mergeRepositoryCollection;
        private readonly IGridUnitSpawnUseCase _spawnUseCase;

        public GridMergeService(IGridModel gridModel,
            IMergeRepositoryCollection mergeRepositoryCollection,
            IGridUnitSpawnUseCase spawnUseCase)
        {
            _mergeRepositoryCollection = mergeRepositoryCollection;
            _spawnUseCase = spawnUseCase;
            _gridModel = gridModel;
        }

        public bool CanMerge(Vector2Int first, Vector2Int second)
        {
            if (!InBoundsAndNotEmpty(first, second))
                return false;

            Guid firstId = _gridModel[first].Id;
            Guid secondId = _gridModel[second].Id;

            return _mergeRepositoryCollection.CanMerge(firstId, secondId);
        }

        public bool TryMerge(Vector2Int first, Vector2Int second)
        {
            if (!CanMerge(first, second))
                return false;

            Guid firstId = _gridModel[first].Id;
            Guid secondId = _gridModel[second].Id;

            if (!_mergeRepositoryCollection.TryMerge(firstId, secondId, out Guid resultId))
                return false;

            _gridModel[first] = null;
            _spawnUseCase.Create(second, resultId);

            return true;
        }

        public void Dispose()
        {
        }

        public void Initialize()
        {
        }

        private bool InBoundsAndNotEmpty(Vector2Int first, Vector2Int second)
        {
            return InBounds(first, second) && !HasEmpty(first, second);
        }

        private bool InBounds(Vector2Int first, Vector2Int second)
        {
            return _gridModel.InBounds(first) && _gridModel.InBounds(second);
        }

        private bool HasEmpty(Vector2Int first, Vector2Int second)
        {
            return _gridModel.IsEmptyAt(first) || _gridModel.IsEmptyAt(second);
        }
    }
}