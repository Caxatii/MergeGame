using System;

namespace _Source.ContractInterfaces.Repositories
{
    public interface IMergeRepositoryCollection : IRepository
    {
        public bool CanMerge(Guid first, Guid second);

        public bool TryMerge(Guid first, Guid second, out Guid resultId);
    }
}