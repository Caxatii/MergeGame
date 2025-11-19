using System;
using System.Collections.Generic;
using _Source.ContractInterfaces.Application;
using _Source.ContractInterfaces.Domain;
using _Source.Domain;
using _Source.Domain.DomainTransfer;
using UnityEngine;

namespace _Source.Application
{
    public class CellStateService : ICellStateService
    {
        private IGridModel _gridModel;
        private ICellPointer _cellPointer;
        private IMergeService _mergeService;
        
        private List<(CellState, Vector2Int)> _cellStates = new List<(CellState, Vector2Int)>();

        public CellStateService(IGridModel gridModel, ICellPointer cellPointer, IMergeService mergeService)
        {
            _gridModel = gridModel;
            _cellPointer = cellPointer;
            _mergeService = mergeService;
        }

        public void Initialize() { }
        
        public void Dispose() { }

        public IReadOnlyList<(CellState, Vector2Int)> GetStates()
        {
            _cellStates.Clear();
            
            foreach ((Vector2Int position, IUnit unit) cell in _gridModel)
            {
                if (cell.position == _cellPointer.Position.Value)
                {
                    _cellStates.Add((CellState.Selected, cell.position));
                    continue;
                }

                if (cell.unit == null)
                {
                    _cellStates.Add((CellState.Default, cell.position));
                    continue;
                }
                
                if(_mergeService.CanMerge(_cellPointer.Position.Value, cell.position))
                {
                    _cellStates.Add((CellState.AbleToMerge, cell.position));
                }
                else
                {
                    _cellStates.Add((CellState.Invalid, cell.position));
                }
            }
            
            return _cellStates;
        }
    }
}