using System;
using UnityEngine;

namespace ContractInterfaces.Presentation.Grid
{
    public interface IGridElementView
    {
        public Vector2Int Position { get; }

        public event Action<IGridElementView> Clicked;

        public void Render(SpriteRenderer spriteRenderer);

        public void SetBackgroundColor(Color color);
        public void ResetBackgroundColor();

        public void Clear();
        void Initialize(Vector2Int position);
    }
}