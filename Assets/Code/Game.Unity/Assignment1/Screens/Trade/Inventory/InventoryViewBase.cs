using System;
using System.Collections.Generic;
using Game.Common;
using UnityEngine;

namespace Game.Unity.Assignment1
{
    public abstract class InventoryViewBase : MonoBehaviour
    {
        public abstract event Action<Vector2> ItemDropped;

        public abstract void Initialize(IList<SlotViewInfo> items, SlotViewBase slotTemplate,
                                        Transform draggingObjectContainer, IGameLogger logger);

        public abstract bool IsWithinBounds(Vector2 position);
    }
}