using System;

namespace ContractInterfaces.Repositories.Grid
{
    public interface IGridElementRepositoryCollection
    {
        public IGridElementRepository Get(Guid id);
        public bool Has(Guid id);
    }
}