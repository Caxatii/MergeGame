using System;
using UnityEngine;

namespace ContractInterfaces.Presentation.Grid
{
    public interface IGridElementView
    {
        public Sprite Sprite { get; }
        public Color Color { get; }
        
        public Vector2Int Position { get; }
        
        public Vector2 WorldPosition { get; }

        public event Action<IGridElementView> Clicked;

        public void Initialize(Vector2Int position);
        
        public void Render(Sprite sprite, Color color);

        public void SetBackgroundColor(Color color);
        
        public void ResetBackgroundColor();

        public void Clear();
        
        public void Show();

        public void Hide();
    }
}