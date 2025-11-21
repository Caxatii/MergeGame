using System;
using UnityEngine;

namespace ContractInterfaces.Infrastructure.Services.Grid
{
    public interface IGridDrawer
    {
        public void Render(Guid id, Vector2Int position);

        public void Clear(Vector2Int position);
    }
}