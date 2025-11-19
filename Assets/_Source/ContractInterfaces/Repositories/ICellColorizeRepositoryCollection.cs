using _Source.Domain.DomainTransfer;
using UnityEngine;

namespace _Source.ContractInterfaces.Repositories
{
    public interface ICellColorizeRepositoryCollection : IRepository
    {
        public Color GetColor(CellState state);
    }
}