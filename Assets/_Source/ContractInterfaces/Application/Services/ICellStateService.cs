using System.Collections.Generic;
using Domain.DomainTransfer;
using UnityEngine;

namespace ContractInterfaces.Application.Services
{
    public interface ICellStateService : IService
    {
        public IReadOnlyList<(CellState, Vector2Int)> GetStates();
    }
}