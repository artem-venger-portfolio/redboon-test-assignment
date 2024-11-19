using System;
using Game.Common;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Game.Unity.Assignment1
{
    public class DraggableObject : DraggableObjectBase, IBeginDragHandler, IDragHandler, IEndDragHandler
    {
        private Transform _draggingObjectContainer;
        private Transform _originalParent;
        private Vector3 _startPosition;
        private IGameLogger _logger;

        public override event Action DragStarted;

        public override event Action DragEnded;

        public override void Initialize(Transform draggingObjectContainer, IGameLogger logger)
        {
            _draggingObjectContainer = draggingObjectContainer;
            _logger = logger;

            _originalParent = Parent;
        }

        public void OnDrag(PointerEventData eventData)
        {
            Position = eventData.position;
        }

        public void OnBeginDrag(PointerEventData eventData)
        {
            LogInfo(nameof(OnBeginDrag));
            Parent = _draggingObjectContainer;
            _startPosition = Position;
            DragStarted?.Invoke();
        }

        public void OnEndDrag(PointerEventData eventData)
        {
            LogInfo(nameof(OnEndDrag));
            Position = _startPosition;
            Parent = _originalParent;
            DragEnded?.Invoke();
        }

        private Vector3 Position
        {
            get => transform.position;
            set => transform.position = value;
        }

        private Transform Parent
        {
            get => transform.parent;
            set => transform.SetParent(value, worldPositionStays: true);
        }

        private void LogInfo(string message)
        {
            _logger.Log($"[{nameof(DraggableObject)}] {message}");
        }
    }
}