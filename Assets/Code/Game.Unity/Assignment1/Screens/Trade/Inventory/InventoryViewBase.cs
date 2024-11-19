using Game.Assignment1;
using Game.Common;
using UnityEngine;

namespace Game.Unity.Assignment1
{
    public abstract class InventoryViewBase : MonoBehaviour
    {
        public abstract void Initialize(IInventoryHolder inventoryHolder, SlotViewBase slotTemplate,
                                        IGameLogger logger);
    }
}