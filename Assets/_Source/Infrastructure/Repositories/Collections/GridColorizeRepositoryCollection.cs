using System.Collections.Generic;
using System.Linq;
using _Source.ContractInterfaces.Repositories;
using _Source.Domain.DomainTransfer;
using UnityEngine;

namespace _Source.Infrastructure.Repositories
{
    public class GridColorizeRepositoryCollection : ICellColorizeRepositoryCollection
    {
        private Dictionary<CellState, Color> _colors;
        
        public GridColorizeRepositoryCollection(CellStateColor[] colors)
        {
            _colors = colors.ToDictionary(k => k.State, v => v.Color);
        }
        
        public Color GetColor(CellState state)
        {
            return _colors[state];
        }
    }
}