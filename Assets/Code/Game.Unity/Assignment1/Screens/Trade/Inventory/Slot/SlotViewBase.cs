using System;
using Game.Assignment1;
using Game.Common;
using UnityEngine;

namespace Game.Unity.Assignment1
{
    public abstract class SlotViewBase : MonoBehaviour
    {
        public abstract Items Item { get; protected set; }
        public abstract event Action<Vector2> ItemDropped;
        public abstract void Initialize(Items item, int price, Transform draggingObjectContainer, IGameLogger logger);
        public abstract void Destroy();
    }
}