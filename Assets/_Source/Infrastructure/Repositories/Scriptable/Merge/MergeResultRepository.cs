using System;
using ContractInterfaces.Repositories.Merge;
using Infrastructure.Repositories.Scriptable.Grid;
using UnityEngine;

namespace Infrastructure.Repositories.Scriptable.Merge
{
    [CreateAssetMenu(menuName = "Infrastructure/MergeResult")]
    public class MergeResultRepository : ScriptableObject, IMergeResultRepository
    {
        [SerializeField] private GridElementRepository _firstRepository;
        [SerializeField] private GridElementRepository _secondRepository;
        [SerializeField] [Space(15)] private GridElementRepository _resultRepository;

        public Guid FirstId =>
            _firstRepository.Id;

        public Guid SecondId =>
            _secondRepository.Id;

        public Guid ResultId =>
            _resultRepository.Id;
    }
}