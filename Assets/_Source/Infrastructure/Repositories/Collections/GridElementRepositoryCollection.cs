using System;
using System.Collections.Generic;
using System.Linq;
using _Source.ContractInterfaces.Repositories;

namespace _Source.Infrastructure.Repositories.Collections
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