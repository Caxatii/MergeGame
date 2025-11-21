using System;
using ContractInterfaces.Presentation;
using ContractInterfaces.Presentation.Grid;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Presentation
{
    public class GridElementView : MonoBehaviour, IGridElementView, IPointerClickHandler
    {
        [SerializeField] private Image _background;
        [SerializeField] private Image _view;
        [field: SerializeField] public Vector2Int Position { get; protected set; }

        private Color _defaultColor;

        public event Action<IGridElementView> Clicked;

        private void Awake()
        {
            _defaultColor = _background.color;
            Clear();
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            Clicked?.Invoke(this);
        }

        public void Initialize(Vector2Int position)
        {
            Position = position;
        }

        public void Render(SpriteRenderer spriteRenderer)
        {
            _view.sprite = spriteRenderer.sprite;
            _view.color = spriteRenderer.color;
        }

        public void SetBackgroundColor(Color color)
        {
            _background.color = color;
        }

        public void ResetBackgroundColor()
        {
            _background.color = _defaultColor;
        }

        public void Clear()
        {
            _view.sprite = null;
            _view.color = Color.clear;
        }
    }
}