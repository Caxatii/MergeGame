using System;
using UnityEngine;

namespace _Source.ContractInterfaces.Infrastructure
{
    public interface IGridDrawer
    {
        public void Render(Guid id, Vector2Int position);

        public void Clear(Vector2Int position);
    }
}