using System;

namespace _Source.ContractInterfaces.Repositories
{
    public interface IMergeResultRepository : IRepository
    {
        public Guid FirstId { get; }
        public Guid SecondId { get; }

        public Guid ResultId { get; }
    }
}