using System;

namespace _Source.ContractInterfaces.Repositories
{
    public interface IGridElementRepositoryCollection
    {
        public IGridElementRepository Get(Guid id);
        public bool Has(Guid id);
    }
}