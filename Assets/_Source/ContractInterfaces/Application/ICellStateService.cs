using System.Collections.Generic;
using _Source.ContractInterfaces.Application;
using _Source.Domain.DomainTransfer;
using UnityEngine;

namespace _Source.Application
{
    public interface ICellStateService : IService
    {
        public IReadOnlyList<(CellState, Vector2Int)> GetStates();
    }
}