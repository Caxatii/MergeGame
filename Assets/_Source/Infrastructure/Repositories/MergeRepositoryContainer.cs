using UnityEngine;

namespace _Source.Infrastructure.Repositories
{
    [CreateAssetMenu(menuName = "Infrastructure/MergeRepositoryCollection")]
    public class MergeRepositoryContainer : ScriptableObject
    {
        [SerializeField] private MergeResultRepository[] _mergeResults;

        public MergeResultRepository[] Get()
        {
            return _mergeResults.Clone() as MergeResultRepository[];
        }
    }
}