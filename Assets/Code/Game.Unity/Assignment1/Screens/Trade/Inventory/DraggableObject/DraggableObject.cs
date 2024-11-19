using System;
using Game.Common;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Game.Unity.Assignment1
{
    public class DraggableObject : DraggableObjectBase, IBeginDragHandler, IDragHandler, IEndDragHandler
    {
        private Vector3 _startPosition;
        private IGameLogger _logger;

        public override event Action DragStarted;

        public override event Action DragEnded;

        public override void Initialize(IGameLogger logger)
        {
            _logger = logger;
        }

        public void OnDrag(PointerEventData eventData)
        {
            Position = eventData.position;
        }

        public void OnBeginDrag(PointerEventData eventData)
        {
            LogInfo(nameof(OnBeginDrag));
            _startPosition = Position;
            DragStarted?.Invoke();
        }

        public void OnEndDrag(PointerEventData eventData)
        {
            LogInfo(nameof(OnEndDrag));
            Position = _startPosition;
            _startPosition = Vector3.zero;
            DragEnded?.Invoke();
        }

        private Vector3 Position
        {
            get => transform.position;
            set => transform.position = value;
        }

        private void LogInfo(string message)
        {
            _logger.Log($"[{nameof(DraggableObject)}] {message}");
        }
    }
}