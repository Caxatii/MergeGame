using UnityEngine;

namespace _Source.Infrastructure.Repositories
{
    [CreateAssetMenu(menuName = "Infrastructure/GridElementRepositoryCollection")]
    public class GridElementRepositoryContainer : ScriptableObject
    {
        [SerializeField] private GridElementRepository[] _elementRepositories;

        public GridElementRepository[] Get()
        {
            return _elementRepositories.Clone() as GridElementRepository[];
        }
    }
}