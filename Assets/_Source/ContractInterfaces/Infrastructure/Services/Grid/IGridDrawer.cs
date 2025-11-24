using System;
using ContractInterfaces.Application.Services;
using UnityEngine;

namespace ContractInterfaces.Infrastructure.Services.Grid
{
    public interface IGridDrawer : IService
    {
        public void Render(Guid id, Vector2Int position);

        public void Clear(Vector2Int position);
    }
}