using System.Collections.Generic;
using _Source.ContractInterfaces.Application;
using _Source.ContractInterfaces.Domain;
using _Source.ContractInterfaces.Infrastructure;
using _Source.ContractInterfaces.Repositories;
using _Source.Domain;
using _Source.Domain.DomainTransfer;
using UnityEngine;

namespace _Source.Application
{
    public class CellStateRenderService : IService
    {
        private IGridModel _gridModel;
        private ICellStateService _cellStateService;
        private ICellColorizeRepositoryCollection _colorizeRepositoryCollection;
        private IGridColorizer _colorizer;

        private ICellPointer _cellPointer;

        private List<(Color, Vector2Int)> _colors = new List<(Color, Vector2Int)>();
            
        public CellStateRenderService(ICellStateService cellStateService,
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
            {
                _colors.Add((_colorizeRepositoryCollection.GetColor(cell.state), cell.position));
            }
            
            _colorizer.Render(_colors);
        }
    }
}