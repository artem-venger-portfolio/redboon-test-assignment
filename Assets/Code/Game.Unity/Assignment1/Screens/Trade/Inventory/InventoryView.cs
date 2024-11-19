using Game.Assignment1;

namespace Game.Unity.Assignment1
{
    public class InventoryView : InventoryViewBase
    {
        public override void Initialize(IInventoryHolder inventoryHolder, SlotViewBase slotTemplate)
        {
            var items = inventoryHolder.Inventory.GetItems();
            foreach (var currentItem in items)
            {
                var slot = Instantiate(slotTemplate, transform);
                slot.Initialize(currentItem.Item, currentItem.Quantity);
            }
        }
    }
}