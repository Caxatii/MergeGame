using UnityEngine;

namespace _Source.ContractInterfaces.Application
{
    public interface IMergeService : IService
    {
        public bool CanMerge(Vector2Int first, Vector2Int second);

        public bool TryMerge(Vector2Int first, Vector2Int second);
    }
}