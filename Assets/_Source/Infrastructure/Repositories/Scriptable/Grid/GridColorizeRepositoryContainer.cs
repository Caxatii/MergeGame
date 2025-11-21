using UnityEngine;

namespace Infrastructure.Repositories.Scriptable.Grid
{
    [CreateAssetMenu(fileName = "GridColorizeRepositoryContainer", 
        menuName = "Infrastructure/Repositories/GridColorizeRepositoryContainer", order = 0)]
    public class GridColorizeRepositoryContainer : ScriptableObject
    {
        [SerializeField] private CellStateColor[] _colors;
        
        public CellStateColor[] Get() => 
            _colors.Clone() as CellStateColor[];
    }
}