using System;
using Game.Assignment1;
using Game.Common;
using UnityEngine;

namespace Game.Unity.Assignment1
{
    public abstract class InventoryViewBase : MonoBehaviour
    {
        public abstract event Action<Vector2> ItemDropped;

        public abstract void Initialize(IInventoryHolder inventoryHolder, SlotViewBase slotTemplate,
                                        Transform draggingObjectContainer, IGameLogger logger);

        public abstract bool IsWithinBounds(Vector2 position);
    }
}