using UnityEngine;

namespace ContractInterfaces.Infrastructure.View.Grid
{
    public interface IGridViewSpawner
    {
        public IGridView SpawnGrid(Vector2Int size);
    }
}