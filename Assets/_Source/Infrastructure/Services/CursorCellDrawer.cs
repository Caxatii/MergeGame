using ContractInterfaces.Application.Services;
using ContractInterfaces.Infrastructure.Services.Grid;
using ContractInterfaces.Infrastructure.View.Grid;
using ContractInterfaces.Presentation.Grid;
using Presentation;
using UnityEngine;

namespace Infrastructure.Services
{
    public class CursorCellDrawer : ICursorCellDrawer
    {
        private IGridInputReader _gridInputReader;
        private ICursorCellView _cursorCellView;
        private IGridView _gridView;

        private IGridElementView _lastPickedCellView;
        
        private MonoBehaviour _cursorObject;
        
        public CursorCellDrawer(IGridInputReader gridInputReader, IGridView gridView, ICursorCellView cursorCellView)
        {
            _gridInputReader = gridInputReader;
            _gridView = gridView;
            _cursorCellView = cursorCellView;

            _cursorObject = _cursorCellView as MonoBehaviour;
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
            IGridElementView view = _gridView.Get(position);

            if (_lastPickedCellView != null)
            {
                _lastPickedCellView.Show();
                _lastPickedCellView = null;
            }

            if (view.Sprite == null)
            {
                _cursorObject.gameObject.SetActive(false);
                _cursorCellView.Cell.Clear();
                return;
            }

            _cursorCellView.Cell.Render(view.Sprite, view.Color);
            _cursorObject.gameObject.SetActive(true);
            _lastPickedCellView = view;
            _lastPickedCellView.Hide();
            
            _cursorCellView.TranslateFrom(view.WorldPosition);
        }
    }
}