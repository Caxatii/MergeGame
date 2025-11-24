using ContractInterfaces.Presentation.Grid;
using UnityEngine;

namespace Presentation
{
    public interface ICursorCellView
    {
        public IGridElementView Cell { get; }
        public void TranslateFrom(Vector2 position);
    }
}