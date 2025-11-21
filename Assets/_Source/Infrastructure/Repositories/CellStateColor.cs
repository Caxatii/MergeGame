using System;
using Domain.DomainTransfer;
using UnityEngine;

namespace Infrastructure.Repositories
{
    [Serializable]
    public struct CellStateColor
    {
        public CellState State;
        public Color Color;
    }
}