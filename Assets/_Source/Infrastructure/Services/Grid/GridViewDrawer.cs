using System;
using ContractInterfaces.Infrastructure.Services.Grid;
using ContractInterfaces.Infrastructure.View.Grid;
using ContractInterfaces.Presentation.Grid;
using ContractInterfaces.Repositories.Grid;
using UnityEngine;

namespace Infrastructure.View.Grid
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

            elementView.Render(repository.Sprite.sprite, repository.Sprite.color);
        }

        public void Clear(Vector2Int position)
        {
            _gridView.Get(position).Clear();
        }

        public void Initialize() { }

        public void Dispose() { }
    }
}