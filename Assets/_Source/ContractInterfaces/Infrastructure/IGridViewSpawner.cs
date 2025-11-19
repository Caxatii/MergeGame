using UnityEngine;

namespace _Source.ContractInterfaces.Infrastructure
{
    public interface IGridViewSpawner
    {
        public IGridView SpawnGrid(Vector2Int size);
    }
}