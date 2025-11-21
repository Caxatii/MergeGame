using ContractInterfaces.Repositories.Grid;
using UnityEngine;

namespace Infrastructure.Repositories.Scriptable.Grid
{
    [CreateAssetMenu(menuName = "Infrastructure/Grid")]
    public class GridRepository : ScriptableObject, IGridRepository
    {
        [field: SerializeField] public int Width { get; private set; }
        [field: SerializeField] public int Height { get; private set; }
    }
}