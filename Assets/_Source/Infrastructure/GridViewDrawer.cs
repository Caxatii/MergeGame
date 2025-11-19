using System;
using _Source.ContractInterfaces.Infrastructure;
using _Source.ContractInterfaces.Presentation;
using _Source.ContractInterfaces.Repositories;
using UnityEngine;

namespace _Source.Infrastructure
{
    public class GridViewDrawer : IGridDrawer
    {
        private readonly IGridElementRepositoryCollection _elementRepositories;
        private readonly IGridView _gridView;

        public GridViewDrawer(IGridElementRepositoryCollection elementRepositories, IGridView gridView)
        {
            _elementRepositories = elementRepositories;
            _gridView = gridView;
        }

        public void Render(Guid id, Vector2Int position)
        {
            IGridElementRepository repository = _elementRepositories.Get(id);
            IGridElementView elementView = _gridView.Get(position);

            elementView.Render(repository.Sprite);
        }

        public void Clear(Vector2Int position)
        {
            _gridView.Get(position).Clear();
        }
    }
}