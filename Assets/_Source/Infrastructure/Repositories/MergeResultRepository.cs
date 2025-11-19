using System;
using _Source.ContractInterfaces.Repositories;
using UnityEngine;

namespace _Source.Infrastructure.Repositories
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