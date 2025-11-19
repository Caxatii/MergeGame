using System;
using System.Collections.Generic;
using System.Linq;
using _Source.ContractInterfaces.Repositories;

namespace _Source.Infrastructure.Repositories.Collections
{
    public class MergeRepositoryCollection : IMergeRepositoryCollection
    {
        private readonly Dictionary<UnorderedGuidPair, IMergeResultRepository> _mergeResults;

        public MergeRepositoryCollection(IList<IMergeResultRepository> mergeResults)
        {
            _mergeResults = mergeResults.ToDictionary(
                k => new UnorderedGuidPair(k.FirstId, k.SecondId),
                v => v);
        }

        public bool CanMerge(Guid first, Guid second)
        {
            return _mergeResults.ContainsKey((first, second));
        }

        public bool TryMerge(Guid first, Guid second, out Guid resultId)
        {
            resultId = Guid.Empty;

            if (!_mergeResults.TryGetValue((first, second), out IMergeResultRepository mergeResult))
                return false;

            resultId = mergeResult.ResultId;
            return true;
        }
    }
}