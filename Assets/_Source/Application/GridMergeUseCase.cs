using _Source.ContractInterfaces.Application;
using _Source.ContractInterfaces.Domain;
using _Source.Domain;
using UnityEngine;

namespace _Source.Application
{
    public class GridMergeUseCase
    {
        private readonly ICellPointer _cellPointer;
        private readonly IGridModel _gridModel;
        private readonly IMergeService _mergeService;

        private Vector2Int? _selectedCell;

        public GridMergeUseCase(IMergeService mergeService, ICellPointer cellPointer, IGridModel gridModel)
        {
            _mergeService = mergeService;
            _cellPointer = cellPointer;
            _gridModel = gridModel;
        }

        public void Initialize()
        {
            _cellPointer.Position.Changed += OnClicked;
        }

        public void Dispose()
        {
            _cellPointer.Position.Changed -= OnClicked;
        }

        private void OnClicked(Vector2Int position)
        {
            if (_gridModel.IsEmptyAt(position))
            {
                _selectedCell = null;
                return;
            }
            
            if (!_selectedCell.HasValue)
            {
                _selectedCell = position;
                return;
            }

            if (_selectedCell.Value == position)
                return;

            _mergeService.TryMerge(_selectedCell.Value, position);
            _selectedCell = position;
        }
    }
}