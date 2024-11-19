using System;
using Game.Common;
using UnityEngine;

namespace Game.Unity.Assignment1
{
    public abstract class DraggableObjectBase : MonoBehaviour
    {
        public abstract event Action DragStarted;
        public abstract event Action DragEnded;
        public abstract void Initialize(IGameLogger logger);
    }
}