using System;
using Game.Common;
using UnityEngine;

namespace Game.Unity.Assignment1
{
    public abstract class DraggableObjectBase : MonoBehaviour
    {
        public abstract event Action<Vector2> DragEnded;
        public abstract void Initialize(Transform draggingObjectContainer, IGameLogger logger);
    }
}