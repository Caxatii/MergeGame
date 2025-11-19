using System;
using _Source.ContractInterfaces.Infrastructure;
using _Source.ContractInterfaces.Presentation;
using UnityEngine;

namespace _Source.Infrastructure
{
    public class GridInputReader : IGridInputReader
    {
        private readonly IGridView _gridView;

        public GridInputReader(IGridView gridView)
        {
            _gridView = gridView;
        }

        public event Action<Vector2Int> Clicked;

        public void Initialize()
        {
            foreach (IGridElementView view in _gridView.GetAll())
                view.Clicked += OnCellClicked;
        }

        public void Dispose()
        {
            foreach (IGridElementView view in _gridView.GetAll())
                view.Clicked -= OnCellClicked;
        }

        private void OnCellClicked(IGridElementView view)
        {
            Clicked?.Invoke(view.Position);
        }
    }
}