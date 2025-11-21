using System;

namespace ContractInterfaces.Repositories.Merge
{
    public interface IMergeRepositoryCollection : IRepository
    {
        public bool CanMerge(Guid first, Guid second);

        public bool TryMerge(Guid first, Guid second, out Guid resultId);
    }
}