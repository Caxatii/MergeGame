using System.Collections.Generic;
using ContractInterfaces.Application.Services;
using ContractInterfaces.Domain;
using ContractInterfaces.Infrastructure.Services.Grid;
using ContractInterfaces.Repositories.Grid.Cell;
using Domain.DomainTransfer;
using Domain.Grid.Cells;
using UnityEngine;

namespace Application.Services.Grid.Cells
{
    public class CellStateRenderService : ICellStateRenderService
    {
        private readonly ICellPointer _cellPointer;
        private readonly ICellStateService _cellStateService;
        private readonly IGridColorizer _colorizer;

        private readonly List<(Color, Vector2Int)> _colors = new List<(Color, Vector2Int)>();
        private readonly ICellColorizeRepositoryCollection _colorizeRepositoryCollection;
        private readonly IGridModel _gridModel;

        public CellStateRenderService(
            ICellStateService cellStateService,
            ICellPointer cellPointer,
            ICellColorizeRepositoryCollection colorizeRepositoryCollection,
            IGridColorizer colorizer,
            IGridModel gridModel)
        {
            _cellStateService = cellStateService;
            _cellPointer = cellPointer;
            _colorizeRepositoryCollection = colorizeRepositoryCollection;
            _colorizer = colorizer;
            _gridModel = gridModel;
        }

        public void Initialize()
        {
            _cellPointer.Position.Changed += OnChanged;
            _gridModel.CellChanged += OnChanged;
        }

        public void Dispose()
        {
            _cellPointer.Position.Changed -= OnChanged;
            _gridModel.CellChanged -= OnChanged;
        }

        private void OnChanged(Vector2Int position)
        {
            _colors.Clear();

            foreach ((CellState state, Vector2Int position) cell in _cellStateService.GetStates())
                _colors.Add((_colorizeRepositoryCollection.GetColor(cell.state), cell.position));

            _colorizer.Render(_colors);
        }
    }
}