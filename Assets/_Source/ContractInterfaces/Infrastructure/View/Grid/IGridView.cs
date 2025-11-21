using System.Collections.Generic;
using UnityEngine;
using ContractInterfaces.Presentation.Grid;

namespace ContractInterfaces.Infrastructure.View.Grid
{
    public interface IGridView
    {
        public IGridElementView Get(Vector2Int position);

        public IReadOnlyList<IGridElementView> GetAll();
    }
}