using System;
using _Source.Domain.DomainTransfer;
using UnityEngine;

namespace _Source.Infrastructure.Repositories
{
    [Serializable]
    public struct CellStateColor
    {
        public CellState State;
        public Color Color;
    }
}