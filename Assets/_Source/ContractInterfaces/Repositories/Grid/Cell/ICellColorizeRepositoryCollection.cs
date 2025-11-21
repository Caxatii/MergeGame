using Domain.DomainTransfer;
using UnityEngine;

namespace ContractInterfaces.Repositories.Grid.Cell
{
    public interface ICellColorizeRepositoryCollection : IRepository
    {
        public Color GetColor(CellState state);
    }
}