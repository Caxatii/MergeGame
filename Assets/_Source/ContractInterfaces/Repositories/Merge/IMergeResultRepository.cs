using System;

namespace ContractInterfaces.Repositories.Merge
{
    public interface IMergeResultRepository : IRepository
    {
        public Guid FirstId { get; }
        public Guid SecondId { get; }

        public Guid ResultId { get; }
    }
}