using _Source.ContractInterfaces.Repositories;
using UnityEngine;

namespace _Source.Infrastructure.Repositories
{
    [CreateAssetMenu(menuName = "Infrastructure/Grid")]
    public class GridRepository : ScriptableObject, IGridRepository
    {
        [field: SerializeField] public int Width { get; private set; }
        [field: SerializeField] public int Height { get; private set; }
    }
}