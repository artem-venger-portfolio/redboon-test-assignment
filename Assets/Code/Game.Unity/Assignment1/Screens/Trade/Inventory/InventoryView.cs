using Game.Assignment1;
using Game.Common;

namespace Game.Unity.Assignment1
{
    public class InventoryView : InventoryViewBase
    {
        public override void Initialize(IInventoryHolder inventoryHolder, SlotViewBase slotTemplate, IGameLogger logger)
        {
            var items = inventoryHolder.Inventory.GetItems();
            foreach (var currentItem in items)
            {
                var slot = Instantiate(slotTemplate, transform);
                slot.Initialize(currentItem.Item, currentItem.Quantity, logger);
            }
        }
    }
}