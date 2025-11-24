using Application.UseCases.Grid;
using ContractInterfaces.Application.Services;
using Infrastructure.Repositories.Scriptable.Grid;
using Infrastructure.Services;
using UnityEngine;
using VContainer;

namespace CompositionRoot
{
    public class RandomSpawner : MonoBehaviour
    {
        [SerializeField] private float _autoSpawnDelay;
        [SerializeField] private GridElementRepository _spawnUnit;
        
        [Inject] private IGridRandomPlaceUseCase _randomPlaceUseCase;

        private void Start()
        {
            SpawnUnit();
            Invoke(nameof(Start), _autoSpawnDelay);
        }

        [ContextMenu("Spawn Unit")]
        private void SpawnUnit()
        {
            _randomPlaceUseCase.Spawn(_spawnUnit.Id);
        }
    }
}