using System.Collections;
using ContractInterfaces.Presentation.Grid;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Presentation
{
    public class CursorCellView : MonoBehaviour, ICursorCellView
    {
        [SerializeField] private float _moveTime;
        [SerializeField] private Vector2 _offset;
        
        private bool _isMoving;
        
        private Transform _transform;
        private Coroutine _coroutine;
        
        public IGridElementView Cell { get; private set; }
        
        private Vector2 _mousePosition => 
            Mouse.current.position.ReadValue();

        private void Awake()
        {
            _transform = transform;
            Cell = GetComponentInChildren<IGridElementView>();
        }

        public void TranslateFrom(Vector2 position)
        {
            if (_coroutine != null)
                StopCoroutine(_coroutine);

            _coroutine = StartCoroutine(MoveRoutine(position));
        }

        private IEnumerator MoveRoutine(Vector2 position)
        {
            _isMoving = true;

            float leftTime = 0;
            _transform.position = position;

            while (leftTime < _moveTime)
            {
                _transform.position = Vector2.Lerp(position, _mousePosition + _offset, leftTime / _moveTime);
                leftTime += Time.deltaTime;
                yield return null;
            }
            
            _isMoving = false;
        }
        
        private void LateUpdate()
        {
            if(_isMoving)
                return;

            _transform.position = _mousePosition + _offset;
        }
    }
}