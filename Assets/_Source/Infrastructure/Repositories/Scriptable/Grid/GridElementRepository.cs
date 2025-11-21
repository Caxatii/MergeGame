using System;
using ContractInterfaces.Repositories.Grid;
using UnityEngine;

namespace Infrastructure.Repositories.Scriptable.Grid
{
    [CreateAssetMenu(fileName = "GridElementRepository", menuName = "Infrastructure/GridElementRepository")]
    public class GridElementRepository : ScriptableObject, IGridElementRepository
    {
        [Tooltip("Editing this field has no effect. This is a preview only.")] [SerializeField]
        private string _id;

        private void Awake()
        {
            Regenerate();
        }

        [ContextMenu("Refresh")]
        private void OnValidate()
        {
            if (Id == Guid.Empty && !string.IsNullOrEmpty(_id))
                Id = Guid.Parse(_id);

            _id = Id.ToString();
        }

        [field: SerializeField] public SpriteRenderer Sprite { get; private set; }

        public Guid Id { get; private set; }

        [ContextMenu("Regenerate ID")]
        private void Regenerate()
        {
            Id = Guid.NewGuid();
            OnValidate();
        }
    }
}