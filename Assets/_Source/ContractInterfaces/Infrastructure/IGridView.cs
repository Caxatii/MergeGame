using System.Collections.Generic;
using _Source.ContractInterfaces.Presentation;
using UnityEngine;

namespace _Source.ContractInterfaces.Infrastructure
{
    public interface IGridView
    {
        public IGridElementView Get(Vector2Int position);

        public IReadOnlyList<IGridElementView> GetAll();
    }
}