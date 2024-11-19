using Game.Assignment1;
using Game.Common;
using UnityEngine;

namespace Game.Unity.Assignment1
{
    public class InventoryView : InventoryViewBase
    {
        public override void Initialize(IInventoryHolder inventoryHolder, SlotViewBase slotTemplate,
                                        Transform draggingObjectCOntainer, IGameLogger logger)
        {
            var items = inventoryHolder.Inventory.GetItems();
            foreach (var currentItem in items)
            {
                var slot = Instantiate(slotTemplate, transform);
                slot.Initialize(currentItem.Item, currentItem.Quantity, draggingObjectCOntainer, logger);
            }
        }
    }
}