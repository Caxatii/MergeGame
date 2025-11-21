using System.Collections.Generic;
using System.Linq;
using ContractInterfaces.Repositories.Grid.Cell;
using Domain.DomainTransfer;
using UnityEngine;

namespace Infrastructure.Repositories.Collections.Grid
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