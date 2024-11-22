using System;
using Game.Assignment1;
using Game.Common;
using UnityEngine;

namespace Game.Unity.Assignment1
{
    public abstract class SlotViewBase : MonoBehaviour
    {
        public abstract event Action<Vector2> ItemDropped;
        public abstract void Initialize(Items item, Transform draggingObjectContainer, IGameLogger logger);
    }
}