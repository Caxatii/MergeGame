using _Source.ContractInterfaces.Application;
using _Source.ContractInterfaces.Infrastructure;
using _Source.Domain;
using UnityEngine;

namespace _Source.Application
{
    public class GridPointerMoverService : IService
    {
        private IGridInputReader _gridInputReader;
        private CellPointer _cellPointer;

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