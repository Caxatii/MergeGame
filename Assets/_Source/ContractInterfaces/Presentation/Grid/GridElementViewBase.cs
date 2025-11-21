using System;
using UnityEngine;

namespace ContractInterfaces.Presentation.Grid
{
    public abstract class GridElementViewBase : MonoBehaviour, IGridElementView
    {
        public abstract Vector2Int Position { get; protected set; }

        public abstract event Action<IGridElementView> Clicked;

        public abstract void Render(SpriteRenderer spriteRenderer);

        public abstract void SetBackgroundColor(Color color);

        public abstract void ResetBackgroundColor();

        public abstract void Clear();

        public abstract void Initialize(Vector2Int position);
    }
}