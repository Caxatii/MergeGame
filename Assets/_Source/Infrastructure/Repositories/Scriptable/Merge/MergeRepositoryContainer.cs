using UnityEngine;

namespace Infrastructure.Repositories.Scriptable.Merge
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