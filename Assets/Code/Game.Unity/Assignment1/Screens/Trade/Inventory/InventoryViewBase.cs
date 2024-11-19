using Game.Assignment1;
using UnityEngine;

namespace Game.Unity.Assignment1
{
    public abstract class InventoryViewBase : MonoBehaviour
    {
        public abstract void Initialize(IInventoryHolder inventoryHolder, SlotViewBase slotTemplate);
    }
}