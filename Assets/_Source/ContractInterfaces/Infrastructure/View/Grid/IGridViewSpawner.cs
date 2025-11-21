using UnityEngine;

namespace ContractInterfaces.Infrastructure.View.Grid
{
    public interface IGridViewSpawner
    {
        public IGridView Create(Vector2Int size);
    }
}