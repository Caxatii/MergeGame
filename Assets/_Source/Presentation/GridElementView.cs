using System;
using _Source.ContractInterfaces.Presentation;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace _Source.Presentation
{
    public class GridElementView : GridElementViewProvider, IPointerClickHandler
    {
        [SerializeField] private Image _background;
        [SerializeField] private Image _view;
        [field: SerializeField] public override Vector2Int Position { get; protected set; }

        private Color _defaultColor;
        
        private void Awake()
        {
            _defaultColor = _background.color;
            Clear();
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            Clicked?.Invoke(this);
        }

        public override event Action<IGridElementView> Clicked;

        public override void Initialize(Vector2Int position)
        {
            Position = position;
        }

        public override void Render(SpriteRenderer spriteRenderer)
        {
            _view.sprite = spriteRenderer.sprite;
            _view.color = spriteRenderer.color;
        }

        public override void SetBackgroundColor(Color color)
        {
            _background.color = color;
        }

        public override void ResetBackgroundColor()
        {
            _background.color = _defaultColor;
        }

        public override void Clear()
        {
            _view.sprite = null;
            _view.color = Color.clear;
        }
    }
}