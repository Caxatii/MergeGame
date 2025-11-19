using System;
using UnityEngine;

namespace _Source.ContractInterfaces.Repositories
{
    public interface IGridElementRepository : IRepository
    {
        public Guid Id { get; }
        public SpriteRenderer Sprite { get; }
    }
}