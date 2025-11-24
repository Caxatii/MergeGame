using ContractInterfaces.Application.Services;
using ContractInterfaces.Infrastructure.Services.Grid;
using Domain.Grid.Cells;
using UnityEngine;

namespace Application.Services.Grid
{
    public class GridPointerMoverService : IGridPointerMoverService
    {
        private readonly CellPointer _cellPointer;
        private readonly IGridInputReader _gridInputReader;

        public GridPointerMoverService(CellPointer cellPointer, IGridInputReader gridInputReader)
        {
            _cellPointer = cellPointer;
            _gridInputReader = gridInputReader;
        }

        public void Initialize()
        {
            _gridInputReader.Clicked += OnClicked;
        }

        public void Dispose()
        {
            _gridInputReader.Clicked -= OnClicked;
        }

        private void OnClicked(Vector2Int position)
        {
            _cellPointer.Pointer.Value = position;
        }
    }
}