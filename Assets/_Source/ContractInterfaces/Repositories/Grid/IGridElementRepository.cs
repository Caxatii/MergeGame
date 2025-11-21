using System;
using UnityEngine;

namespace ContractInterfaces.Repositories.Grid
{
    public interface IGridElementRepository : IRepository
    {
        public Guid Id { get; }
        public SpriteRenderer Sprite { get; }
    }
}