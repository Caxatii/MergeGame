using _Source.ContractInterfaces.Application;
using _Source.ContractInterfaces.Domain;
using _Source.ContractInterfaces.Infrastructure;
using UnityEngine;

namespace _Source.Application
{
    public class GridDrawerService : IService
    {
        private readonly IGridDrawer _drawer;
        private readonly IGridModel _model;

        public GridDrawerService(IGridModel model, IGridDrawer drawer)
        {
            _model = model;
            _drawer = drawer;
        }

        public void Initialize()
        {
            _model.CellChanged += OnCellChanged;
        }

        public void Dispose()
        {
            _model.CellChanged -= OnCellChanged;
        }

        private void OnCellChanged(Vector2Int position)
        {
            if (_model.IsEmptyAt(position))
                _drawer.Clear(position);
            else
                _drawer.Render(_model[position].Id, position);
        }
    }
}