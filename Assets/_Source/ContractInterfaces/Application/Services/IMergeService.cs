using UnityEngine;

namespace ContractInterfaces.Application.Services
{
    public interface IMergeService : IService
    {
        public bool CanMerge(Vector2Int first, Vector2Int second);

        public bool TryMerge(Vector2Int first, Vector2Int second);
    }
}