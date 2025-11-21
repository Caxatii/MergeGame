using System;
using System.Collections.Generic;
using System.Linq;
using ContractInterfaces.Repositories.Grid;

namespace Infrastructure.Repositories.Collections.Grid
{
    public class GridElementRepositoryCollection : IGridElementRepositoryCollection
    {
        private readonly Dictionary<Guid, IGridElementRepository> _elementRepositories;

        public GridElementRepositoryCollection(IList<IGridElementRepository> elementRepositories)
        {
            _elementRepositories = elementRepositories.ToDictionary(
                k => k.Id,
                v => v);
        }

        public IGridElementRepository Get(Guid id)
        {
            return _elementRepositories[id];
        }

        public bool Has(Guid id)
        {
            return _elementRepositories.ContainsKey(id);
        }
    }
}