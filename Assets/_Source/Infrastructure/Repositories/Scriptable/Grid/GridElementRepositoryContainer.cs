using UnityEngine;

namespace Infrastructure.Repositories.Scriptable.Grid
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